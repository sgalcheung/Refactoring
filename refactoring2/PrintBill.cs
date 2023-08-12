using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using refactoring2.Entities;

namespace refactoring2
{
    // public class StatementData
    // {
    //     public string Customer { get; set; }
    //
    //     public List<Performance> Performances { get; set; }
    //
    //     public int TotalAmount { get; set; }
    //
    //     public double TotalVolumeCredits { get; set; }
    // }
    
    public class PrintBill
    {
        // public T CreateFromObjects<T>(params T[] sources)
        //     where T : new()
        // {
        //     var ret = new T();
        //     MergeObjects(ret, sources);
        //
        //     return ret;
        // }
        //
        // public void MergeObjects<T>(T target, params T[] sources)
        // {
        //     Func<PropertyInfo, T, bool> predicate = (p, s) =>
        //     {
        //         if (p.GetValue(s)!.Equals(GetDefault(p.PropertyType)))
        //         {
        //             return false;
        //         }
        //
        //         return true;
        //     };
        //
        //     MergeObjects(target, predicate, sources);
        // }
        //
        // public void MergeObjects<T>(T target, Func<PropertyInfo, T, bool> predicate, params T[] sources)
        // {
        //     foreach (var propertyInfo in typeof(T).GetProperties().Where(prop => prop.CanRead && prop.CanWrite))
        //     {
        //         foreach (var source in sources)
        //         {
        //             if (predicate(propertyInfo, source))
        //             {
        //                 propertyInfo.SetValue(target, propertyInfo.GetValue(source));
        //             }
        //         }
        //     }
        // }
        //
        // private static object GetDefault(Type type)
        // {
        //     if (type.IsValueType)
        //     {
        //         return Activator.CreateInstance(type);
        //     }
        //     return null;
        // }

        private CreateStatementDataClass _createStatementDataClass;
        
        public string Statement(Invoice invoice, Dictionary<string, Play> plays)
        {
            // var totalAmount = 0;
            // var volumeCredits = 0d;
            // var result = $"Statement for {invoice.Customer}\n";
            // var format = string.Format("{0:C2}", fmoney);
            
            // foreach (var performance in invoice.Performances)
            // {
                // var play = plays.GetType().GetProperty(nameof(performance.PlayId));
                // var play = plays.Plays[performance.PlayId];

                // var play = PlayFor(performance);
                
                // var thisAmount = AmountFor(performance, PlayFor(performance));

                // switch (play.Type)
                // {
                //     case "tragedy":
                //         thisAmount = 40000;
                //         if (performance.Audience > 30)
                //         {
                //             thisAmount += 1000 * (performance.Audience - 30);
                //         }
                //
                //         break;
                //     case "comedy":
                //         thisAmount = 30000;
                //         if (performance.Audience > 20)
                //         {
                //             thisAmount += 10000 + 500 * (performance.Audience - 20);
                //         }
                //
                //         thisAmount += 300 * performance.Audience;
                //         break;
                //     default:
                //         throw new Exception($"unknown type: ${play.Type}");
                //         break;
                // }

                // add volume credits
                
                // volumeCredits += Math.Max(performance.Audience - 30, 0);
                // // add extra credit for every ten comedy attendees
                // if ("comedy" == PlayFor(performance).Type) volumeCredits += Math.Floor(performance.Audience / 5.0);
                // volumeCredits += VolumeCreditsFor(performance);

                // print line for this order
                // result +=
                //     $"{PlayFor(performance).Name}: ${Usd(AmountFor(performance))} ({performance.Audience} seats)\n";
                // totalAmount += AmountFor(performance);
            // }

            // var volumeCredits = 0d;
            // foreach (var performance in invoice.Performances)
            // {
            //     volumeCredits += VolumeCreditsFor(performance);
            // }
            // var volumeCredits = TotalVolumeCredits();

            // result += $"Amount owed is ${Usd(TotalAmount())}\n";
            // result += $"You earned {TotalVolumeCredits()} credits\n";
            // return result;
            // var statementData = new StatementData()
            // {
            //     Customer = invoice.Customer,
            //     Performances = invoice.Performances.Select(EnrichPerformance).ToList(),
            // };
            // statementData.TotalAmount = TotalAmount(statementData);
            // statementData.TotalVolumeCredits = TotalVolumeCredits(statementData);
            
            
            // return RenderPlainText(statementData, plays);
            return RenderPlainText(_createStatementDataClass.CreateStatementData(invoice, plays));
            
            
            
            // int TotalAmount(StatementData data)
            // {
            //     // var result = 0;
            //     // foreach (var performance in data.Performances)
            //     // {
            //     //     result += performance.Amount;
            //     // }
            //     //
            //     // return result;
            //     
            //     return data.Performances.Sum(performance => performance.Amount);
            // }
            
            // double TotalVolumeCredits(StatementData data)
            // {
            //     // var result = 0d;
            //     // foreach (var performance in data.Performances)
            //     // {
            //     //     result += performance.VolumeCredits;
            //     // }
            //     //
            //     // return result;
            //     
            //     return data.Performances.Sum(performance => performance.VolumeCredits);
            // }
            
            // double VolumeCreditsFor(Performance aPerformance)
            // {
            //     var result = 0d;
            //     result += Math.Max(aPerformance.Audience - 30, 0);
            //     if ("comedy" == aPerformance.Play.Type)
            //         result += Math.Floor(aPerformance.Audience / 5.0);
            //     return result;
            // }
            
            // int AmountFor(Performance aPerformance)
            // {
            //     var result = 0;
            //     switch (aPerformance.Play.Type)
            //     {
            //         case "tragedy":
            //             result = 40000;
            //             if (aPerformance.Audience > 30)
            //             {
            //                 result += 1000 * (aPerformance.Audience - 30);
            //             }
            //
            //             break;
            //         case "comedy":
            //             result = 30000;
            //             if (aPerformance.Audience > 20)
            //             {
            //                 result += 10000 + 500 * (aPerformance.Audience - 20);
            //             }
            //
            //             result += 300 * aPerformance.Audience;
            //             break;
            //         default:
            //             throw new Exception($"unknown type: ${aPerformance.Play.Type}");
            //             break;
            //     }
            //
            //     return result;
            // }

            // Play PlayFor(Performance aPerformance)
            // {
            //     return plays.Plays[aPerformance.PlayId];
            // }

            // Performance EnrichPerformance(Performance aPerformance)
            // {
            //     var result = CreateFromObjects(aPerformance);
            //     result.Play = PlayFor(result);
            //     result.Amount = AmountFor(result);
            //     result.VolumeCredits = VolumeCreditsFor(result);
            //     return result;
            // }
            


            // int TotalAmount()
            // {
            //     var result = 0;
            //     foreach (var performance in invoice.Performances)
            //     {
            //         result += AmountFor(performance);
            //     }
            //
            //     return result;
            // }
            //
            // double TotalVolumeCredits()
            // {
            //     var result = 0d;
            //     foreach (var performance in invoice.Performances)
            //     {
            //         result += VolumeCreditsFor(performance);
            //     }
            //
            //     return result;
            // }
            //
            // double VolumeCreditsFor(Performance aPerformance)
            // {
            //     var result = 0d;
            //     result += Math.Max(aPerformance.Audience - 30, 0);
            //     if ("comedy" == PlayFor(aPerformance).Type)
            //         result += Math.Floor(aPerformance.Audience / 5.0);
            //     return result;
            // }
            //
            // string Usd(decimal aNumber)
            // {
            //     return CurrencyHelper.ConvertCurrency(aNumber / 100);
            // }
            //
            // Play PlayFor(Performance aPerformance)
            // {
            //     return plays.Plays[aPerformance.PlayId];
            // }
            //
            // // int AmountFor(Performance aPerformance, Play Play)
            // int AmountFor(Performance aPerformance)
            // {
            //     var result = 0;
            //     switch (PlayFor(aPerformance).Type)
            //     {
            //         case "tragedy":
            //             result = 40000;
            //             if (aPerformance.Audience > 30)
            //             {
            //                 result += 1000 * (aPerformance.Audience - 30);
            //             }
            //
            //             break;
            //         case "comedy":
            //             result = 30000;
            //             if (aPerformance.Audience > 20)
            //             {
            //                 result += 10000 + 500 * (aPerformance.Audience - 20);
            //             }
            //
            //             result += 300 * aPerformance.Audience;
            //             break;
            //         default:
            //             throw new Exception($"unknown type: ${PlayFor(aPerformance).Type}");
            //             break;
            //     }
            //
            //     return result;
            // }

        }

        // public StatementData CreateStatementData(Invoice invoice, Play plays)
        // {
        //     var statementData = new StatementData();
        //     statementData.Customer = invoice.Customer;
        //     statementData.Performances = invoice.Performances.Select(EnrichPerformance).ToList();
        //     statementData.TotalAmount = TotalAmount(statementData);
        //     statementData.TotalVolumeCredits = TotalVolumeCredits(statementData);
        //     return statementData;
        // }

        // public string RenderPlainText(StatementData data, Play plays)
        public string RenderPlainText(CreateStatementDataClass dataClass)
        {
            var result = $"Statement for {dataClass.Customer}\n";
            foreach (var performance in dataClass.Performances)
            {
                result +=
                    $"{performance.Play.Name}: ${Usd(performance.Amount)} ({performance.Audience} seats)\n";
            }
            result += $"Amount owed is ${Usd(dataClass.TotalAmount)}\n";
            result += $"You earned {dataClass.TotalVolumeCredits} credits\n";
            return result;
            
            
            // int TotalAmount()
            // {
            //     var result = 0;
            //     foreach (var performance in data.Performances)
            //     {
            //         result += performance.Amount;
            //     }
            //
            //     return result;
            // }

            // double TotalVolumeCredits()
            // {
            //     var result = 0d;
            //     foreach (var performance in data.Performances)
            //     {
            //         result += performance.VolumeCredits;
            //     }
            //
            //     return result;
            // }
            
            // double VolumeCreditsFor(Performance aPerformance)
            // {
            //     var result = 0d;
            //     result += Math.Max(aPerformance.Audience - 30, 0);
            //     if ("comedy" == aPerformance.Play.Type)
            //         result += Math.Floor(aPerformance.Audience / 5.0);
            //     return result;
            // }

            // string Usd(decimal aNumber)
            // {
            //     return CurrencyHelper.ConvertCurrency(aNumber / 100);
            // }
            
            // Play PlayFor(Performance aPerformance)
            // {
            //     return plays.Plays[aPerformance.PlayId];
            // }
            
            // int AmountFor(Performance aPerformance, Play Play)
            // int AmountFor(Performance aPerformance)
            // {
            //     var result = 0;
            //     switch (aPerformance.Play.Type)
            //     {
            //         case "tragedy":
            //             result = 40000;
            //             if (aPerformance.Audience > 30)
            //             {
            //                 result += 1000 * (aPerformance.Audience - 30);
            //             }
            //
            //             break;
            //         case "comedy":
            //             result = 30000;
            //             if (aPerformance.Audience > 20)
            //             {
            //                 result += 10000 + 500 * (aPerformance.Audience - 20);
            //             }
            //
            //             result += 300 * aPerformance.Audience;
            //             break;
            //         default:
            //             throw new Exception($"unknown type: ${aPerformance.Play.Type}");
            //             break;
            //     }
            //
            //     return result;
            // }
        }
        
        string Usd(decimal aNumber)
        {
            return CurrencyHelper.ConvertCurrency(aNumber / 100);
        }

        public string HtmlStatement(Invoice invoice, Dictionary<string, Play> plays)
        {
            return RenderHtml(_createStatementDataClass.CreateStatementData(invoice, plays));
        }
        
        public string RenderHtml(CreateStatementDataClass dataClass) {
            var result = $"<h1>Statement for {dataClass.Customer}</h1>\n";
            result += "<table>\n";
            result += "<tr><th>play</th><th>seats</th><th>cost</th></tr>";
            // for (let perf of data.performances) {
            //     result += ` <tr><td>${perf.play.name}</td><td>${perf.audience}</td>`;
            //     result += `<td>${usd(perf.amount)}</td></tr>\n`;
            // }
            foreach (var performance in dataClass.Performances)
            {
                result += $"<tr><td>{performance.Play.Name}</td><td>${performance.Audience}</td>";
                result += $"<td>{Usd(performance.Amount)}</td></tr>\n";
            }
            result += "</table>\n";
            result += $"<p>Amount owed is <em>${Usd(dataClass.TotalAmount)}</em></p>\n";
            result += $"<p>You earned <em>${dataClass.TotalVolumeCredits}</em> credits</p>\n";
            return result;
        }
    }
}