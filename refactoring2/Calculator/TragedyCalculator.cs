using refactoring2.Entities;

namespace refactoring2.Calculator
{
    public class TragedyCalculator : PerformanceCalculator
    {
        private readonly Performance _performance;
        private readonly Play _play;

        public TragedyCalculator(Performance aPerformance, Play aPlay) : base(aPerformance, aPlay)
        {
            _performance = aPerformance;
            _play = aPlay;
        }

        public override int Amount
        {
            get
            {
                var result = 40000;
                if (_performance.Audience > 30)
                {
                    result += 1000 * (_performance.Audience - 30);
                }

                return result;
            }
        }
        
    }
}