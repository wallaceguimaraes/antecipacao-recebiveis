using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.ServiceModel
{
    public class AdvanceRequest
    {
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

        1° - Não é permitido incluir em uma NOVA SOLICITAÇÃO DE ANTECIPAÇÃO de transações solicitadas anteriormente;
        Para realização de uma nova solicitação de antecipação, é necessário que a solicitação atual já tenha sido FINALIZADA;

        2° - A data de finalização da análise deve ser preenchida quando todas as transações da antecipação forem resolvidas 
        como aprovadas ou reprovadas;

        3° - Aplicar taxa de 3.8% em cada parcela de transação antecipada, considerando o valor líquido da parcela. Esse valor deve 
        ser armazenado no campo "Valor antecipado" da parcela da transação em questão;


        4° - Caso a transação seja aprovada na antecipação, ao finalizar a solicitação, deve ter o campo "Data em que a parcela 
        foi repassada", da entidade "Parcela", preenchida com a data atual.


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
        2° Endpoint -> Solicitar antecipação a partir de uma lista de transações;
        3° Endpoint -> Iniciar o atendimento da antecipação;
        4° Endpoint -> Aprovar ou reprovar uma ou mais transações da antecipação (quando todas as transações forem finalizadas, 
        a antecipação será finalizada);
        5° Endpoint -> Consultar histórico de antecipações com filtro por status (pendente, em análise, finalizada).

        */

    }
}