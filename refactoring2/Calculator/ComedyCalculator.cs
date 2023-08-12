using refactoring2.Entities;

namespace refactoring2.Calculator
{
    public class ComedyCalculator : PerformanceCalculator
    {
        private readonly Performance _performance;
        private readonly Play _play;

        public ComedyCalculator(Performance aPerformance, Play aPlay) : base(aPerformance, aPlay)
        {
            _performance = aPerformance;
            _play = aPlay;
        }

        public override int Amount
        {
            get
            {
                var result = 30000;
                if (_performance.Audience > 20)
                {
                    result += 10000 + 500 * (_performance.Audience - 20);
                }

                result += 300 * _performance.Audience;

                return result;
            }
        }

        public override double VolumeCredits =>
            // var result = 0d;
            // result += Math.Max(_performance.Audience - 30, 0);
            // if ("comedy" == _performance.Play.Type)
            //     result += Math.Floor(_performance.Audience / 5.0);
            // return result;
            base.VolumeCredits + Math.Floor(_performance.Audience / 5.0);
    }
}