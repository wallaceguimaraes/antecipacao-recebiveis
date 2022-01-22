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

namespace api.Models.ServiceModel
{
    public class AdvanceRequestService
    {
        private readonly DataContext _context;
        private readonly IPortion _portionService;

        private readonly IRequestedAdvance _requestedAdvance;

        public AdvanceRequestService(DataContext context, IPortion portionService, IRequestedAdvance requestedAdvance)
        {
            _context = context;
            _portionService = portionService;
            _requestedAdvance = requestedAdvance;
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

        1° - Não é permitido incluir em uma NOVA SOLICITAÇÃO DE ANTECIPAÇÃO, transações solicitadas anteriormente;
          
            Para realização de uma nova solicitação de antecipação, é necessário que a solicitação atual já tenha sido FINALIZADA;

            Verificar se alguma transacao ARRAY LIST ja foi incluida numa solicitacao de antecipacao, não permitindo uma nova solicitacao
            Verificar 

            
        */


        public async Task<IActionResult> AdvanceRequest(AdvanceRequestModel vModel)
        {
            //var list = null;

            foreach (var transfer in vModel.Transfers)
            {
               var list = await _requestedAdvance.getRequestedAdvance(transfer.TransferId);

            }



            return await _requestedAdvance.getRequestedAdvance(2);

        }


        public async Task<IActionResult> ConsultAvailableTransactions()
        {

            //Verificar na nova tabela de transacoes solicitadas
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




        /*

        2° - A data de finalização da análise deve ser preenchida quando todas as transações da antecipação forem resolvidas 
        como aprovadas ou reprovadas;

        3° - Aplicar taxa de 3.8% em cada parcela de transação antecipada, considerando o valor líquido da parcela. Esse valor deve 
        ser armazenado no campo "Valor antecipado" da parcela da transação em questão; flag Early  da transacao recebe TRUE


        4° - Caso a transação seja aprovada na antecipação, ao finalizar a solicitação, deve ter o campo "Data em que a parcela 
        foi repassada", da entidade "Parcela", preenchida com a data atual. Campo TransferDate (PORTION)


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

        ROTAS

        1° Endpoint -> Consultar transações disponíveis para solicitar antecipação (não é necessário filtros);
        2° Endpoint -> Solicitar antecipação a partir de uma lista de transações ( Passar no corpo da requisição uma lista de transacoes ID);
        3° Endpoint -> Iniciar o atendimento da antecipação;
        4° Endpoint -> Aprovar ou reprovar uma ou mais transações da antecipação (quando todas as transações forem finalizadas, 
        a antecipação será finalizada);
        5° Endpoint -> Consultar histórico de antecipações com filtro por status (pendente, em análise, finalizada).

        */

    }
}