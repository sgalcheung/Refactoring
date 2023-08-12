using refactoring2.Calculator;
using refactoring2.Entities;

namespace refactoring2
{
    public class PerformanceCalculatorFactory
    {
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