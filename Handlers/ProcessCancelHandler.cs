using System.Collections.Generic;
using System.Threading.Tasks;
using Camunda.Worker;

namespace camundaWorker.Handlers
{
    [HandlerTopics("processCancel")]
    public class ProcessCancelHandler : ExternalTaskHandler
    {
        public override async Task<IExecutionResult> Process(ExternalTask externalTask)
        {
            await Task.Delay(1000);
            Dictionary<string, Variable> Variables = new Dictionary<string, Variable>();
            
            Variables["ProcessMessage"] = Variable.String("placeholder message - all work completed");
            
            var compRes = new CompleteResult(Variables);
            return compRes;        

        }
    }
}