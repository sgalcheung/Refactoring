using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using refactoring2.Entities;
using Xunit;
using Xunit.Abstractions;

namespace refactoring2.test
{
    public class StatementClassTest
    {
        private readonly ITestOutputHelper _outputHelper;
        private Invoice _invoice;
        private Dictionary<string, Play> _plays;
        private StatementClass _statementClass;

        public StatementClassTest(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            var invoicesContent = ReadFileHelper.ReadJsonFile("invoices.json").Result;
            // var invoicesContent2 = ReadFileHelper.ReadJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "JSON"), "invoices2.json").Result;
            var playsContent = ReadFileHelper.ReadJsonFile("plays.json").Result;
            var invoices = JsonConvert.DeserializeObject<List<Invoice>>(invoicesContent);
            var plays = JsonConvert.DeserializeObject<Dictionary<string, Play>>(playsContent);

            if (invoices is null) throw new ArgumentNullException("plays.json file is empty!");
            
            _invoice = invoices.FirstOrDefault();
            _plays = plays;
            _statementClass = new StatementClass();
        }
        
        [Fact]
        public void StatementTest()
        {
            var actual = _statementClass.Statement(_invoice, _plays);
            _outputHelper.WriteLine(actual);
            
            var expected = @"Statement for BigCo
Hamlet: $650.00 (55 seats)
As You Like It: $580.00 (35 seats)
Othello: $500.00 (40 seats)
Amount owed is $1,730.00
You earned 47 credits

";
            Assert.NotStrictEqual(expected, actual);
        }
    }
}