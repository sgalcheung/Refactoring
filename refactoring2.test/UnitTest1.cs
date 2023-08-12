using System;
using System.IO;
using System.Text.Json.Nodes;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using refactoring2.Entities;
using Xunit;

namespace refactoring2.test
{
    public class UnitTest1
    {
        private const string Expected = @"Statement for BigCo
Hamlet: $650.00 (55 seats)
As You Like It: $580.00 (35 seats)
Othello: $500.00 (40 seats)
Amount owed is $1,730.00
You earned 47 credits

";

        [Fact]
        public void Test1()
        {
        var invoicesPath = Path.Combine(Directory.GetCurrentDirectory(), "json", "invoices.json"); // error
        var playsPath = Path.Combine(Directory.GetCurrentDirectory(), "json", "plays.json");
        using (StreamReader reader = File.OpenText(playsPath))
        {
            using (JsonTextReader jsonTextReader = new JsonTextReader(reader))
            {
                JObject jsonObject = (JObject) JToken.ReadFrom(jsonTextReader);
            }
        }
        // StreamReader reader = File.OpenText(invoicesPath);
        // JsonTextReader jsonTextReader = new JsonTextReader(reader);
        // JObject jsonObject = (JObject)JToken.ReadFrom(jsonTextReader);
        // JObject jsonobject = (JObject) JToken.ReadFrom(jsonTextReader);
        
        
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                refactoring2.Program.Main();

                var result = sw.ToString();
                Assert.Equal(Expected, result, true, true, true);
            }
        }

        [Theory]
        [InlineData("o1", "data2")]
        public void Test(string data1, string data2)
        {
            var a = new Invoice()
            {
                Customer = "a"
            };
            var b = new Invoice()
            {
                Customer = "b"
            };
            
            // Assert.Equal(a, b);
            // Assert.True(a == b);
            a.Should().BeEquivalentTo(b);
        }
    }
}