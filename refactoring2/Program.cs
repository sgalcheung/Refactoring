// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using refactoring2;
using refactoring2.Entities;

#region 顶级程序

// private static readonly IServiceProvider ServiceProvider;

// Console.WriteLine("Hello, World!");


const string jsonDirName = "json";

var invoicesPath = Path.Combine(jsonDirName, "invoices.json");
var playPath = Path.Combine(jsonDirName, "plays.json");

var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(invoicesPath, optional: false, reloadOnChange: false)
    .AddJsonFile(playPath, optional: false, reloadOnChange: false);
// .AddEnvironmentVariables();
var configuration = builder.Build();

var serviceCollection = new ServiceCollection();
serviceCollection.AddOptions();
serviceCollection.Configure<Invoice>(configuration.GetSection(nameof(Invoice)));
serviceCollection.AddSingleton<Invoice>(sp => sp.GetRequiredService<IOptions<Invoice>>().Value);
serviceCollection.AddSingleton<Test>();
var invoice = new Invoice();
configuration.Bind(invoice);
// Console.WriteLine(invoice.Performances.First().Audience);
var play = new Play();
// configuration.Bind(play);
// play.Plays.Add(nameof(play.Hamlet).ToLower(), play.Hamlet);
// play.Plays.Add(nameof(play.As_like).ToLower(), play.As_like);
// play.Plays.Add(nameof(play.Othello).ToLower(), play.Othello);

play.Plays = configuration.Get<Dictionary<string, Play>>();


// Console.WriteLine(play.As_like.Name);

// serviceCollection.AddScoped<Test>();

// var serviceProvider = serviceCollection.BuildServiceProvider();

// RegisterHelper.RegisterConfigurationInjectionsAutoFac(serviceProvider, new ContainerBuilder());

// new RegisterHelper();

// new Test().a();
// var str = configuration.GetSection(nameof(Invoice)).GetSection("0").Get<Invoice>();
// Console.Write(str.Performances.First().Audience);
// Console.WriteLine(str);

var printBill = new PrintBill();
var result = printBill.Statement(invoice, play.Plays);
Console.WriteLine(result);

var htmlResult = printBill.HtmlStatement(invoice, play.Plays);
Console.WriteLine(htmlResult);


#endregion

namespace refactoring2
{
    public class Program
    {
        /// <summary>
        /// The 'void refactoring2.Program.Main(string[])' method will not be used as an entry point because compilation unit with top-level statements was found.
        /// 如果顶级程序存在，不会作为程序的 入口点 执行
        /// 我这里只是供 UnintTest 调用
        /// </summary>
        public static void Main()
        {
            const string jsonDirName = "json";

            var invoicesPath = Path.Combine(jsonDirName, "invoices.json");
            var playPath = Path.Combine(jsonDirName, "plays.json");

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(invoicesPath, optional: false, reloadOnChange: false)
                .AddJsonFile(playPath, optional: false, reloadOnChange: false);
            // .AddEnvironmentVariables();
            var configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddOptions();
            serviceCollection.Configure<Invoice>(configuration.GetSection(nameof(Invoice)));
            serviceCollection.AddSingleton<Invoice>(sp => sp.GetRequiredService<IOptions<Invoice>>().Value);
            serviceCollection.AddSingleton<Test>(); // or serviceCollection.AddSingleton(typeof(Test));
            
            var invoice = new Invoice();
            configuration.Bind(invoice);
            // Console.WriteLine(invoice.Performances.First().Audience);
            var play = new Play();
            // configuration.Bind(play);
            // play.Plays.Add(nameof(play.Hamlet).ToLower(), play.Hamlet);
            // play.Plays.Add(nameof(play.As_like).ToLower(), play.As_like);
            // play.Plays.Add(nameof(play.Othello).ToLower(), play.Othello);

            play.Plays = configuration.Get<Dictionary<string, Play>>();


            // Console.WriteLine(play.As_like.Name);

            // serviceCollection.AddScoped<Test>();

            // var serviceProvider = serviceCollection.BuildServiceProvider();

            // RegisterHelper.RegisterConfigurationInjectionsAutoFac(serviceProvider, new ContainerBuilder());

            // new RegisterHelper();

            // new Test().a();
            // var str = configuration.GetSection(nameof(Invoice)).GetSection("0").Get<Invoice>();
            // Console.Write(str.Performances.First().Audience);
            // Console.WriteLine(str);

            var result = new PrintBill().Statement(invoice, play.Plays);
            Console.WriteLine(result);
        }
    }
}

