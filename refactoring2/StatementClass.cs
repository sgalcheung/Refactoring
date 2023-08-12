using refactoring2.Entities;

namespace refactoring2
{
    public class StatementClass
    {
        public string Statement(Invoice invoice, Dictionary<string, Play> plays)
        {
            return RenderPlainText(new CreateStatementDataClass().CreateStatementData(invoice, plays));
        }

        public string RenderPlainText(CreateStatementDataClass dataClass)
        {
            var result = $"Statement for {dataClass.Customer}\n";
            foreach (var performance in dataClass.Performances)
            {
                result +=
                    $"{performance.Play.Name}: ${Usd(performance.Amount)} ({performance.Audience} seats)\n";
            }

            result += $"Amount owed is ${Usd(dataClass.TotalAmount)}\n";
            result += $"You earned {dataClass.TotalVolumeCredits} credits\n";
            return result;
        }
        
        public string HtmlStatement(Invoice invoice, Dictionary<string, Play> plays)
        {
            return RenderHtml(new CreateStatementDataClass().CreateStatementData(invoice, plays));
        }
        
        public string RenderHtml(CreateStatementDataClass dataClass) {
            var result = $"<h1>Statement for {dataClass.Customer}</h1>\n";
            result += "<table>\n";
            result += "<tr><th>play</th><th>seats</th><th>cost</th></tr>";
            foreach (var performance in dataClass.Performances)
            {
                result += $"<tr><td>{performance.Play.Name}</td><td>${performance.Audience}</td>";
                result += $"<td>{Usd(performance.Amount)}</td></tr>\n";
            }
            result += "</table>\n";
            result += $"<p>Amount owed is <em>${Usd(dataClass.TotalAmount)}</em></p>\n";
            result += $"<p>You earned <em>${dataClass.TotalVolumeCredits}</em> credits</p>\n";
            return result;
        }
        
        string Usd(decimal aNumber)
        {
            return CurrencyHelper.ConvertCurrency(aNumber / 100);
        }
    }
}