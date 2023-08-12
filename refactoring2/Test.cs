using System.Linq;
using Microsoft.Extensions.Options;
using refactoring2.Entities;

namespace refactoring2
{
    public class Test
    {
        
        private readonly IOptions<Invoice> _invoiceOptions;
        private readonly Invoice _invoice;

        public Test()
        {
            
        }
        
        public Test(IOptions<Invoice> invoiceOptions,
            Invoice invoice)
        {
            _invoiceOptions = invoiceOptions;
            _invoice = invoice;
        }

        public void a()
        {
            var a = _invoiceOptions.Value.Performances.FirstOrDefault().Audience;
        }
    }
}