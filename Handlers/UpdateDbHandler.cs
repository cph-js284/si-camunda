using System.Collections.Generic;
using System.Threading.Tasks;
using Camunda.Worker;

namespace camundaWorker.Handlers
{
    [HandlerTopics("updateDb")]
    public class UpdateDbHandler : ExternalTaskHandler
    {
        public override async Task<IExecutionResult> Process(ExternalTask externalTask)
        {
            await Task.Delay(1000);
            Dictionary<string, Variable> Variables = new Dictionary<string, Variable>();
            
            Variables["updateSucces"] = Variable.String("true");
            
            var compRes = new CompleteResult(Variables);
            return compRes;        
        }
    }
}