namespace Office.HumanResource.Infrastructure.Modules
{
    using Autofac;
    using Office.HumanResource.Application;

    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in Office.HumanResource.Application
            //
            builder.RegisterAssemblyTypes(typeof(ApplicationException).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
