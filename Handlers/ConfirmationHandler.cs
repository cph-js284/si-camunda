using System.Collections.Generic;
using System.Threading.Tasks;
using Camunda.Worker;

namespace camundaWorker.Handlers
{
    [HandlerTopics("confirmation")]
    public class ConfirmationHandler : ExternalTaskHandler
    {
        public override async Task<IExecutionResult> Process(ExternalTask externalTask)
        {
            await Task.Delay(1000);
            Dictionary<string, Variable> Variables = new Dictionary<string, Variable>();
            
            Variables["updateSucces"] = Variable.String("Placeholder - email sent to confirmation email sent to client");
            
            var compRes = new CompleteResult(Variables);
            return compRes;        
        }
    }
}