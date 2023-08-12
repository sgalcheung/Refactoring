using System.Globalization;

namespace refactoring2
{
    public class CurrencyHelper
    {
        ///  
        /// 输入Double格式数字，将其转换为货币表达方式 
        ///  
        /// 货币表达类型：0=带￥的货币表达方式；1=不带￥的货币表达方式；其它=带￥的货币表达方式 
        /// 传入的int数字 
        /// 返回转换的货币表达形式 
        public static string Rmoney(int ftype, double fmoney)
        {
            string _rmoney;
            try
            {
                switch (ftype)
                {
                    case 0:
                        _rmoney = string.Format("{0:C2}", fmoney);
                        break;
                    case 1:
                        _rmoney = string.Format("{0:N2}", fmoney);
                        break;
                    default:
                        _rmoney = string.Format("{0:C2}", fmoney);
                        break;
                }
            }
            catch
            {
                _rmoney = "";
            }

            return _rmoney;
        }

        ///  
        /// 输入Decimal格式数字，将其转换为货币表达方式 
        ///  
        /// 货币表达类型：0=人民币；1=港币；2=美钞；3=英镑；4=不带货币;其它=不带货币表达方式 
        /// 传入的int数字 
        /// 返回转换的货币表达形式 
        public static string ConvertCurrency(decimal fmoney)
        {
            CultureInfo cul = null;
            int ftype = 4;
            string _rmoney = string.Empty;
            try
            {
                switch (ftype)
                {
                    case 0:
                        cul = new CultureInfo("zh-CN"); //中国大陆 
                        _rmoney = fmoney.ToString("c", cul);
                        break;
                    case 1:
                        cul = new CultureInfo("zh-HK"); //香港 
                        _rmoney = fmoney.ToString("c", cul);
                        break;
                    case 2:
                        cul = new CultureInfo("en-US"); //美国 
                        _rmoney = fmoney.ToString("c", cul);
                        break;
                    case 3:
                        cul = new CultureInfo("en-GB"); //英国 
                        _rmoney = fmoney.ToString("c", cul);
                        break;
                    case 4:
                        _rmoney = string.Format("{0:n}", fmoney); //没有货币符号 
                        break;

                    default:
                        _rmoney = string.Format("{0:n}", fmoney);
                        break;
                }
            }
            catch
            {
                _rmoney = "";
            }

            return _rmoney;
        }
    }
}