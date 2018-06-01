using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginsSPKL2
{

    [CrmPluginRegistration(MessageNameEnum.Update, "account", StageEnum.PreOperation, ExecutionModeEnum.Synchronous, "", "PreUpdate Account", 1, IsolationModeEnum.Sandbox)]
    [CrmPluginRegistration(MessageNameEnum.Create, "account", StageEnum.PreOperation, ExecutionModeEnum.Synchronous, "", "PreCreate Account", 1, IsolationModeEnum.Sandbox)]

    public class AccountPlugin : IPlugin
    {
        
        public void Execute(IServiceProvider serviceProvider)
        {
            
            ITracingService tracer = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            Entity entity = (Entity)context.InputParameters["Target"];
            String entityName = entity.LogicalName;
            Guid entityId = entity.Id;
            
            entity["telephone1"] = "01-234-567";
            entity["fax"] = "01-234-567";
            
            context.InputParameters["Target"] = entity;


        }
    }
}
