using System;
using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using refactoring2.Entities;

namespace refactoring2
{
    public class RegisterHelper
    {
        // public RegisterHelper(Test test)
        // {
        //     // test.ToString();
        // }
        
        public static void RegisterConfigurationInjectionsAutoFac(IServiceProvider serviceProvider, ContainerBuilder builder)
        {
            builder.Register(context => serviceProvider.GetService<IOptions<Invoice>>());
        }

    }
}