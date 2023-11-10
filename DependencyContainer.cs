using Autofac;

public class DependencyContainer
{
    public static void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterType<Account>().As<IAccount>();
    }
}