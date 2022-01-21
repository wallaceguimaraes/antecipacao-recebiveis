using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Infrastructure.Context;
using api.Models.ServiceModel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using api.Models.ResultModel;
using api.Models.EntityModel.Queries;
using Microsoft.EntityFrameworkCore;
using api.Models.ViewModels;
using api.Models.EntityModel;


namespace api.Models.ServiceModel
{
    public class TransferService : ITransfer
    {

        // Toda transação aprovada deve gerar parcelas com vencimento a cada 30 dias, 
        // exemplo: Se a transação for de R$100,00 em 2x (duas parcelas)
        /* 
                Nesse exemplo, seriam geradas duas parcelas de R$49,55 cada, sendo esse valor obtido 
                a partir do valor da transação, nesse caso 100 reais, subtraido a taxa fixa, 0,90, e dividido pelo número de parcelas */
        private readonly DataContext _context;
        private readonly IPortion _portionService;

        public TransferService(DataContext context, IPortion portionService)
        {
            _context = context;
            _portionService = portionService;
        }

        public async Task<IActionResult> List()
        {
            try
            {
                var transfers = await _context.Transfers
                                    .OrderById()
                                    .ToListAsync();

                if (transfers == null) return null;

                return new TransferListJson(transfers);
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IActionResult> SaveTransfer(PaymentModel vModel, string status)
        {
            Transfer transfer = new Transfer();
            string lastDigits = vModel.CreditCard.Substring(12, 4);
            transfer.CardDigits = lastDigits;
            transfer.GrossTransferAmount = vModel.ValueTotal;
            transfer.InstallmentAmount = vModel.InstallmentsAmount;

            if (status == "RECUSADA")
            {
                transfer.ConfirmationAcquirer = status;
                transfer.DisapprovalDate = DateTime.Now;
                transfer.Early = false;
                transfer.TransferNetAmount = vModel.ValueTotal;
            }
            else
            {
                transfer.ConfirmationAcquirer = status;
                transfer.ApprovalDate = DateTime.Now;
                transfer.Early = true;
                transfer.TransferNetAmount = transfer.GrossTransferAmount - transfer.FixedRate;
            }


            try
            {
                _context.Add(transfer);

                await _context.SaveChangesAsync();

                if(status == "APROVADA"){
                    await _portionService.SavePortion(transfer);
                }
                

                 //await _context.Transfers.   
                return new TransferJson(transfer);

            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}