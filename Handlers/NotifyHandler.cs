using System.Collections.Generic;
using System.Threading.Tasks;
using Camunda.Worker;

namespace camundaWorker.Handlers
{
    [HandlerTopics("notify")]
    public class NotifyHandler : ExternalTaskHandler
    {
        public override async Task<IExecutionResult> Process(ExternalTask externalTask)
        {
            await Task.Delay(1000);
            Dictionary<string, Variable> Variables = new Dictionary<string, Variable>();
            
            Variables["NotifyMesssage"] = Variable.String("Placeholder - staff notified, initiating meltdown");
            
            var compRes = new CompleteResult(Variables);
            return compRes;        
        }
    }
}