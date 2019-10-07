using System.Collections.Generic;
using System.Threading.Tasks;
using Camunda.Worker;

namespace camundaWorker.Handlers
{
    [HandlerTopics("carSearch")]
    [HandlerVariables("cartype")]
    public class CarSearchHandler : ExternalTaskHandler
    {
        public override async Task<IExecutionResult> Process(ExternalTask externalTask)
        {
            if(!externalTask.Variables.TryGetValue("cartype", out var cartypeVar)){
                throw new System.Exception("error bleh");
            }

            var carType = cartypeVar.Value;

            await Task.Delay(1000);

            Dictionary<string, Variable> Variables = new Dictionary<string, Variable>();
            
            if ((string)carType == "a" || (string)carType == "b" || (string)carType == "c" ){
                Variables["AvailCars"] = Variable.Integer(5);

            }else{
                Variables["AvailCars"] = Variable.Integer(0);
            }
            
            var compRes = new CompleteResult(Variables);
            return compRes;        
        }
    }
}