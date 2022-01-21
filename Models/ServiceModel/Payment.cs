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
            await _transferService.SaveTransfer(vModel, "APROVADA");

          
       

            /*    

            5° - O vencimento de cada parcela deverá ser obtido através da MULTIPLICAÇÃO do número da parcela por 30, conforme 
            exemplificado acima;
            O valor LÍQUIDO da parcela deverá ser obtido a partir do valor BRUTO da TRANSAÇÃO subtraído a TAXA FIXA, 
            dividido pelo número de parcelas (já citado em exemplo).
            */

            /*
            6° - DIVIDIR VALOR TOTAL SUBTRAIDO (TAXA FIXA) POR QUANTIDADE DE PARCELAS


            SALVAR NO BANCO TABELA (PORTION)
            
            Nesse exemplo, seriam geradas duas parcelas de R$49,55 cada, sendo esse valor obtido 
            a partir do valor da transação, nesse caso 100 reais, subtraido a taxa fixa, 0,90, e 
            dividido pelo número de parcelas, no exemplo 2x. Sobre a data de recebimento das parcelas, 
            ainda nesse exemplo, a primeira teria seu repasse realizado com 30 dias após a data de realização da 
            venda e a segunda parcela com 60 dias a partir da mesma data de referência.

            ROTAS A CRIAR

            1° Endpoint ->  Efetuar pagamento com cartão de crédito (make-payment);
            2° Endpoint -> Consultar uma transação e suas parcelas a partir do  (consult-transaction)
           

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