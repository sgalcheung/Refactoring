using refactoring2.Entities;

namespace refactoring2.Calculator
{
    public abstract class PerformanceCalculator
    {
        private readonly Performance _performance;
        public readonly Play Play;

        public virtual int Amount
        {
            get
            {
                throw new Exception("subclass responsibility");
                
                // var result = 0;
                // switch (Play.Type)
                // {
                //     case "tragedy":
                //         throw new Exception("bad thing");
                //
                //         break;
                //     case "comedy":
                //         result = 30000;
                //         if (_performance.Audience > 20)
                //         {
                //             result += 10000 + 500 * (_performance.Audience - 20);
                //         }
                //
                //         result += 300 * _performance.Audience;
                //
                //         return result;
                //         break;
                //     default:
                //         throw new Exception($"unknown type: ${Play.Type}");
                //         break;
                // }
                //
                // return result;
            }
        }
        
        public virtual double VolumeCredits => Math.Max(_performance.Audience - 30, 0);

        public PerformanceCalculator(Performance aPerformance, Play aPlay)
        {
            _performance = aPerformance;
            Play = aPlay;
        }

        
    }
}