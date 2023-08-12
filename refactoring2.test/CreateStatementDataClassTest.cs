using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using refactoring2.Entities;
using Xunit;

namespace refactoring2.test
{
    public class CreateStatementDataClassTest
    {
        private Invoice _invoice;
        private Dictionary<string, Play> _plays;
        private CreateStatementDataClass _createStatementDataClass;

        public CreateStatementDataClassTest()
        {
            var invoicesContent = ReadFileHelper.ReadJsonFile("invoices.json").Result;
            var playsContent = ReadFileHelper.ReadJsonFile("plays.json").Result;
            var invoices = JsonConvert.DeserializeObject<List<Invoice>>(invoicesContent);
            var plays = JsonConvert.DeserializeObject<Dictionary<string, Play>>(playsContent);
            
            if (invoices is null) throw new ArgumentNullException("plays.json file is empty!");

            _invoice = invoices.FirstOrDefault();
            _plays = plays;
            _createStatementDataClass = new CreateStatementDataClass();
        }
        
        [Fact]
        public Task CreateStatementDataTest()
        {
            var createStatementData = _createStatementDataClass.CreateStatementData(_invoice, _plays);
            Assert.NotNull(createStatementData);
            
            return Task.CompletedTask;
        }
    }
}