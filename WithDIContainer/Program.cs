using Autofac;
using DependencyInversionPrincipleDemo;

#region 無Container

//SecurityService securityService=new SecurityService(new LoginService()); 
//SecurityService securityService = new SecurityService(new EncyptLoginService());

#endregion


#region 使用Container
Autofac.ContainerBuilder containerBuilder = new Autofac.ContainerBuilder();
containerBuilder.RegisterType<EncyptLoginService>().As<ILoginService>();
containerBuilder.RegisterType<SecurityService>().As<SecurityService>();
var container = containerBuilder.Build();

SecurityService securityService = container.Resolve<SecurityService>();
#endregion


if (securityService.LoginUser("Stanley", "3554436"))
    Console.WriteLine("登入成功");
else Console.WriteLine("登入失敗");

