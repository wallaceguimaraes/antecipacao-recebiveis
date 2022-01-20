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

namespace api.Models.ServiceModel
{
    public class Transfer : ITransfer
    {

       // Toda transação aprovada deve gerar parcelas com vencimento a cada 30 dias, 
        // exemplo: Se a transação for de R$100,00 em 2x (duas parcelas)
/* 
        Nesse exemplo, seriam geradas duas parcelas de R$49,55 cada, sendo esse valor obtido 
        a partir do valor da transação, nesse caso 100 reais, subtraido a taxa fixa, 0,90, e dividido pelo número de parcelas */
        private readonly DataContext _context;

        public Transfer(DataContext context)
        {
            _context = context;
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
    }
}