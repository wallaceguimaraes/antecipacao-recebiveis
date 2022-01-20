using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Infrastructure.Context;
using api.Models.EntityModel.Queries;
using api.Models.ResultModel;
using api.Models.ServiceModel.Interfaces;
using api.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Models.ServiceModel.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly DataContext _context;

        public PaymentService(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> MakePayment(PaymentModel vModel)
        {
            /*
            Toda transação aprovada deve gerar parcelas com vencimento a cada 30 dias, 
            exemplo: Se a transação for de R$100,00 em 2x (duas parcelas), deve ser criado o 
            registro de transação (entidade FORTE), conforme os critérios acima, e uma lista de 
            parcelas associadas a essa transação (entidade FRACA). 



            Nesse exemplo, seriam geradas duas parcelas de R$49,55 cada, sendo esse valor obtido 
            a partir do valor da transação, nesse caso 100 reais, subtraido a taxa fixa, 0,90, e 
            dividido pelo número de parcelas, no exemplo 2x. Sobre a data de recebimento das parcelas, 
            ainda nesse exemplo, a primeira teria seu repasse realizado com 30 dias após a data de realização da 
            venda e a segunda parcela com 60 dias a partir da mesma data de referência.
            */




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

    }
}