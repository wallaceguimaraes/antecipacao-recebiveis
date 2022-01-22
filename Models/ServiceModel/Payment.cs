using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using api.Infrastructure.Context;
using api.Models.EntityModel.Queries;
using api.Models.ResultModel;
using api.Models.ServiceModel.Interfaces;
using api.Models.Validations;
using api.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Models.ServiceModel
{
    public class Payment : IPayment
    {
        private readonly DataContext _context;
        private readonly ITransfer _transferService;

        public Payment(DataContext context, ITransfer transferService)
        {
            _context = context;
            _transferService = transferService;
        }

        public async Task<IActionResult> MakePayment(PaymentModel vModel)
        {
            /*
            * CRITÉRIOS DE ACEITAÇÃO
            */
            string[] cardNumber = vModel.CreditCard.Split(' ');
            // 1° - Cobrar taxa fixa de 0,90 nas transações aprovadas;
            // Na requisição de transação (efetuar pagamento), o número do cartão deve conter 16 caracteres numéricos, sem espaços;
            if (cardNumber.Length > 1)
            {
                return new InvalidCard();
            }
            /*
            * 2° - Caso o número do cartão inicie com "5999", deve ter a transação REPROVADA ao EFETUAR PAGAMENTO, nos demais casos 
            * válidos a transação deverá ser aprovada; GERAR PARCELAS apenas em TRANSAÇÕES APROVADAS;
            */
            if (vModel.CreditCard.Substring(0, 4) == "5999")
            {
                await _transferService.SaveTransfer(vModel, "RECUSADA");

                return new FailedTransfer();
            }
            
            //3° - GERAR TRANSAÇÃO APROVADA E SUAS PARCELAS
            return await _transferService.SaveTransfer(vModel, "APROVADA");

        }

    }
}