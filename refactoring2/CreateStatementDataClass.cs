using System;
using System.Collections.Generic;
using System.Linq;
using refactoring2.Calculator;
using refactoring2.Entities;

namespace refactoring2
{
    public class CreateStatementDataClass
    {
        public string Customer { get; set; }

        public List<Performance> Performances { get; set; }

        public int TotalAmount { get; set; }

        public double TotalVolumeCredits { get; set; }
        
        
        public CreateStatementDataClass CreateStatementData(Invoice invoice, Dictionary<string, Play> plays)
        {
            var result = new CreateStatementDataClass();
            result.Customer = invoice.Customer;
            result.Performances = invoice.Performances.Select(EnrichPerformance).ToList();
            result.TotalAmount = TotalAmount(result);
            result.TotalVolumeCredits = TotalVolumeCredits(result);
            return result;
            
            Performance EnrichPerformance(Performance aPerformance)
            {
                // var calculator = new PerformanceCalculator(aPerformance, PlayFor(aPerformance));
                var calculator = CreatePerformanceCalculator(aPerformance, PlayFor(aPerformance));
                var result = AssignHelper.CreateFromObjects(aPerformance);
                // result.Play = PlayFor(result);
                result.Play = calculator.Play;
                result.Amount = calculator.Amount;
                result.VolumeCredits = calculator.VolumeCredits;
                return result;
            }
        
            Play PlayFor(Performance aPerformance)
            {
                return plays[aPerformance.PlayId];
            }
            
            // int AmountFor(Performance aPerformance)
            // {
            //     // var result = 0;
            //     // switch (aPerformance.Play.Type)
            //     // {
            //     //     case "tragedy":
            //     //         result = 40000;
            //     //         if (aPerformance.Audience > 30)
            //     //         {
            //     //             result += 1000 * (aPerformance.Audience - 30);
            //     //         }
            //     //
            //     //         break;
            //     //     case "comedy":
            //     //         result = 30000;
            //     //         if (aPerformance.Audience > 20)
            //     //         {
            //     //             result += 10000 + 500 * (aPerformance.Audience - 20);
            //     //         }
            //     //
            //     //         result += 300 * aPerformance.Audience;
            //     //         break;
            //     //     default:
            //     //         throw new Exception($"unknown type: ${aPerformance.Play.Type}");
            //     //         break;
            //     // }
            //     //
            //     // return result;
            //     return new PerformanceCalculator(aPerformance, PlayFor(aPerformance)).Amount;
            // }
            
            // double VolumeCreditsFor(Performance aPerformance)
            // {
            //     // var result = 0d;
            //     // result += Math.Max(aPerformance.Audience - 30, 0);
            //     // if ("comedy" == aPerformance.Play.Type)
            //     //     result += Math.Floor(aPerformance.Audience / 5.0);
            //     // return result;
            //     return new PerformanceCalculator(aPerformance, PlayFor(aPerformance)).VolumeCredits;
            // }
            
            int TotalAmount(CreateStatementDataClass data)
            {
                return data.Performances.Sum(performance => performance.Amount);
            }
            
            double TotalVolumeCredits(CreateStatementDataClass data)
            {
                return data.Performances.Sum(performance => performance.VolumeCredits);
            }
        }
        
        public PerformanceCalculator CreatePerformanceCalculator(Performance aPerformance, Play aPlay)
        {
            // return new PerformanceCalculator(aPerformance, aPlay);
            switch (aPlay.Type)
            {
                case "tragedy":
                    return new TragedyCalculator(aPerformance, aPlay);
                    break;
                case "comedy":
                    return new ComedyCalculator(aPerformance, aPlay);
                    break;
                default:
                    throw new Exception($"unknown type: ${aPlay.Type}");
                    break;
            }
        }
    }
}