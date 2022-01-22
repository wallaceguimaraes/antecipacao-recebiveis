using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Infrastructure.Context;
using api.Models.EntityModel;
using api.Models.EntityModel.Queries;
using api.Models.ResultModel;
using api.Models.ServiceModel.Interfaces;
using api.Models.Validations;
using api.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Models.ServiceModel
{
    public class AdvanceRequestService : IAdvanceRequest
    {
        private readonly DataContext _context;
        private readonly IPortion _portionService;
        private readonly IRequestedAdvance _requestedAdvanceService;
        private readonly ITransfer _transferService;
        private readonly IRequestSituation _requestSituation;

        public AdvanceRequestService(DataContext context, IPortion portionService,
                                    IRequestedAdvance requestedAdvanceService,
                                    ITransfer transferService,
                                    IRequestSituation requestSituation)
        {
            _context = context;
            _portionService = portionService;
            _requestedAdvanceService = requestedAdvanceService;
            _transferService = transferService;
            _requestSituation = requestSituation;

        }

        /*
        TABELA PORTION -> AnticipatedValue
        Valor antecipado (Esse campo só deve ser preenchido se a transação for aprovada pela análise 
        do financeiro, na solicitação de antecipação);

        Data em que a parcela foi repassada (Esse campo só deve ser preenchido se a transação for 
        aprovada pela análise do financeiro, na solicitação de antecipação).



        SOLICITAÇÕES DE ANTECIPAÇÃO SÃO DOCUMENTOS EMITIDOS PELO LOJISTA/VENDEDOR ATRAVÉS DO
        NOSSO SERVIÇO DE REPASSE ANTECIPADO DE  VALORES. A antecipação de uma transação tem um 
        CUSTO de 3.8% APLICADO em CADA PARCELA da TRANSAÇÃO, se APROVADA pela análise do financeiro, 
        sendo automaticamente debitado no seu repasse. Considerando o exemplo da transação citado na 
        fase 1, se cada parcela da transação tem valor líquido de 49,55, o valor antecipado da parcela 
        seria obtido a partir desse valor líquido, debitado a taxa de 3.8%.

        CRITÉRIOS DE ACEITAÇÃO
          
            OBS: Para realização de uma nova solicitação de antecipação, é necessário que a solicitação atual já tenha sido FINALIZADA;
            
        */


        public async Task<IActionResult> AdvanceRequest(AdvanceRequestModel vModel)
        {
            foreach (var transfer in vModel.Transfers)
            {
                var list = await _requestedAdvanceService.getRequestedAdvance(transfer.TransferId);
                //1° - Não é permitido incluir em uma NOVA SOLICITAÇÃO DE ANTECIPAÇÃO, transações solicitadas anteriormente;
                if (list != null)
                {
                    return new PreviouslyRequestedTransactionError(transfer.TransferId);
                }
            }
            decimal netValue = 0;
            AdvanceRequest advanceRequest = new AdvanceRequest();

            foreach (var transfer in vModel.Transfers)
            {
                netValue = netValue + transfer.TransferNetAmount;
            }

            advanceRequest.AmountRequestedAdvance = netValue;

            _context.Add(advanceRequest);

            await _context.SaveChangesAsync();
            await _requestedAdvanceService.SaveRequestedTransaction(advanceRequest, vModel);

            //SItuationId => 1 PENDENTE
            await _requestSituation.SaveSituation(advanceRequest.AdvanceRequestId, 1);

            return new AdvanceRequestJson(advanceRequest);

        }

        /*       public async Task<IActionResult> StartAnticipationService(AdvanceRequestModel vModel){


              }
       */

        /*
      FLUXO DO PROCESSO

      5° - O trâmite de uma solicitação de antecipação progride através das seguintes etapas:

      Aguardando análise (PENDENTE): O lojista solicitou antecipação, mas ainda não foi INICIADO a análise pela equipe 
      financeira da Pagcerto;

      EM ANÁLISE: A equipe financeira iniciou a análise da antecipação, podendo aprovar ou reprovar UMA ou MAIS 
      TRANSAÇÕES contidas na SOLICITAÇÃO;

      FINALIZADA: Quando a análise da solicitação é encerrada, a antecipação pode assumir um dos seguintes resultados: 
      aprovada (todas as transações aprovadas), 
      aprovada parcialmente (quando existe ao menos uma transação aprovada e uma transação reprovada na análise) 
      ou reprovada (todas as transações reprovadas).




       2° - A data de finalização da análise deve ser preenchida quando todas as transações da antecipação forem resolvidas 
      como aprovadas ou reprovadas;


      3° - Aplicar taxa de 3.8% em cada parcela de transação antecipada, considerando o valor líquido da parcela. Esse valor deve 
      ser armazenado no campo "Valor antecipado" da parcela da transação em questão; flag Early  da transacao recebe TRUE, AnticipatedValue

      4° - Caso a transação seja aprovada na antecipação, ao finalizar a solicitação, deve ter o campo "Data em que a parcela 
      foi repassada", da entidade "Parcela", preenchida com a data atual. Campo TransferDate (PORTION)

      ROTAS

      1° Endpoint -> Consultar transações disponíveis para solicitar antecipação (não é necessário filtros);
      2° Endpoint -> Solicitar antecipação a partir de uma lista de transações ( Passar no corpo da requisição uma lista de transacoes ID);
      3° Endpoint -> Iniciar o atendimento da antecipação;
      4° Endpoint -> Aprovar ou reprovar uma ou mais transações da antecipação (quando todas as transações forem finalizadas, 
      a antecipação será finalizada);
      5° Endpoint -> Consultar histórico de antecipações com filtro por status (pendente, em análise, finalizada).

      */


        public async Task<IActionResult> ConsultAvailableTransactions()
        {
            //Verificar na tabela RequestedAdvance

            var list = await _requestedAdvanceService.ConsultAvailableTransactions();

            return list;
        }

    }
}