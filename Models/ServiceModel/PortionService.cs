using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Infrastructure.Context;
using api.Models.EntityModel.Queries;
using api.Models.ServiceModel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models.ResultModel;
using api.Models.EntityModel;

namespace api.Models.ServiceModel
{
    public class PortionService : IPortion
    {
        private readonly DataContext _context;

        public PortionService(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> EndDate(int transferId)
        {
            ICollection<Portion> portions = _context.Portions.GetByTransferId(transferId).ToList();
            
            foreach(var portion in portions){
                 portion.TransferDate = DateTime.Now;
                _context.Update(portion);

                await _context.SaveChangesAsync();
                
            }
            return null;

        }

        public async Task<IActionResult> List()
        {
            try
            {
                var portions = await _context.Portions
                                    .OrderById()
                                    .ToListAsync();

                if (portions == null) return null;

                return new PortionListJson(portions);
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IActionResult> SavePortion(Transfer transfer)
        {
            /*
             GERAR PARCELAS (Portion)

             4° - Toda transação aprovada deve gerar parcelas com vencimento a cada 30 dias, 
             exemplo: Se a transação for de R$100,00 em 2x (duas parcelas), deve ser criado o 
             registro de transação (entidade FORTE), conforme os critérios acima, e uma lista de 
             parcelas associadas a essa transação (entidade FRACA). 

             CALCULAR QUANTIDADE DE PARCELAS POR 30 PARA GERAR VENCIMENTO DE CADA PARCELA
             EX: PARCELA 1 VENCE COM 30 DIAS, POIS 1 X 30 = 30
                 PARCELA 2 VENCE COM 60 DIAS, POIS 2 X 30 = 60
                 PARCELA 3 VENCE COM 90 DIAS, POIS 3 X 30 = 90   
             */

            //DateTime today = DateTime.Now;

            decimal grossValue = transfer.GrossTransferAmount / transfer.InstallmentAmount;
            decimal netValue = (transfer.TransferNetAmount - transfer.FixedRate ) / transfer.InstallmentAmount;

            for (int installmentNumber = 1; installmentNumber <= transfer.InstallmentAmount;installmentNumber ++)
            {

                Portion portion = new Portion();
                DateTime expectedDateReceipt = transfer.DateTransferMade.AddDays(installmentNumber * 30);
                portion.ExpectedDateReceipt = expectedDateReceipt;
                portion.TransferId = transfer.TransferId;
                portion.GrossValue = grossValue;
                portion.NetValue = netValue;
                portion.InstallmentNumber = installmentNumber;

                try
                {
                    _context.Add(portion);

                    await _context.SaveChangesAsync();
                }
                catch (System.Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

             var portions = _context.Portions.OrderById().GetByTransferId(transfer.TransferId);

            return new PortionListJson(portions);

        }

        public async Task<IActionResult> UpdatePortion(int transferId, decimal netValue )
        {
           
            ICollection<Portion> portions = _context.Portions.GetByTransferId(transferId).ToList();

            
            foreach(var portion in portions){
                 
                 decimal rate =portion.NetValue * 0.38m;
                 portion.AnticipatedValue = portion.NetValue - rate;

                _context.Update(portion);

                await _context.SaveChangesAsync();
            }

            return null;
        }


        
    }
}