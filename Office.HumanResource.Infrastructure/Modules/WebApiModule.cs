namespace Office.HumanResource.Infrastructure.Modules
{
    using Autofac;
    using System;

    public class WebApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in Office.HumanResource.WebApi
            //

            Type startup = Type.GetType("Office.HumanResource.WebApi.Startup, Office.HumanResource.WebApi");

            builder.RegisterAssemblyTypes(startup.Assembly)
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}
