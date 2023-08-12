using System;
using System.Collections.Generic;

namespace refactoring2.Entities
{
    public class Invoice
    {
        public string Customer = "BigCo";

        public List<Performance> Performances { get; set; }
        
        // public void ToString()
        // {
        //     Console.WriteLine(Customer);
        // }
    }

    public class Performance
    {
        public string PlayId { get; set; }

        public int Audience { get; set; }

        // must be initialized
        public Play Play { get; set; } = new Play();

        public int Amount { get; set; }

        public double VolumeCredits { get; set; }
    }
}