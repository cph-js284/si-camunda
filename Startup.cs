using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Camunda.Worker;
using Camunda.Worker.Extensions;
using camundaWorker.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace camundaWorker
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // setting up the camunda client for incomming tasks
            // task accepted are the handlers listed below 
            // other tasks not pulled from camunda
            services.AddCamundaWorker(options =>{
                options.WorkerId="mormorid";
                options.WorkerCount=1;
                //instead of linking to localhost, the link point to the container running camunda
                options.BaseUri=new Uri("http://camunda:8080/engine-rest");
            })
            .AddHandler<CarSearchHandler>()
            .AddHandler<ConfirmationHandler>()
            .AddHandler<NotifyHandler>()
            .AddHandler<ProcessCancelHandler>()
            .AddHandler<ProcessPaymentHandler>()
            .AddHandler<UpdateDbHandler>()
            .ConfigurePipeline(pipeline =>{
                pipeline.Use(next => async context => {
                    System.Console.WriteLine("alarm Alarm ALARM!!!");
                    await next(context);
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }
    }
}
