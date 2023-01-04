using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace NucleicExtraction.Common
{
    public static class Tool
    {
        /// <summary>
        /// 字符串转16进制加空格
        /// </summary>
        /// <param name="str"></param>
        /// <param name="lenth"></param>
        /// <returns></returns>
        public static string strToBase16(string str, int lenth)
        {
            return Regex.Replace(Convert.ToString(Int32.Parse(str), 16).PadLeft(lenth, '0'), @"(\d{2}(?!$))", "$1 ");
        }

        /// <summary>
        /// 小数
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumeric(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
        }

        /// <summary>
        /// 正小数
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsPositiveNumeric(string value)
        {
            return Regex.IsMatch(value, @"^\d+(\.\d+)?$");
        }

        /// <summary>
        /// 整数
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsInt(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*$");
        }
        /// <summary>
        /// 正整数
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsPositiveInt(string value)
        {
            return Regex.IsMatch(value, @"^\d+$");
        }

        /// <summary>
        /// 非零正整数
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsPositiveIntNoZero(string value)
        {
            return Regex.IsMatch(value, @"^[1-9]\d*$");
        }


        //加密
        public static string Sha1(string str)
        {
            var buffer = Encoding.UTF8.GetBytes(str);
            var data = SHA1.Create().ComputeHash(buffer);

            var sb = new StringBuilder();
            foreach (var t in data)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }

        ////数字
        //Regex reg = new Regex(@"^[0-9]*$");
        ////n位的数字
        //Regex reg = new Regex(@"^\d{n}$");
        ////至少n位的数字
        //Regex reg = new Regex(@"^\d{n,}$");
        ////m-n位的数字
        //Regex reg = new Regex(@"^\d{m,n}$");
        ////零和非零开头的数字
        //Regex reg = new Regex(@"^(0|[1-9][0-9]*)$");
        ////非零开头的最多带两位小数的数字
        //Regex reg = new Regex(@"^([1-9][0-9]*)+(.[0-9]{1,2})?$");
        ////带1-2位小数的正数或负数
        //Regex reg = new Regex(@"^(\-)?\d+(\.\d{1,2})?$");
        ////正数、负数、和小数
        //Regex reg = new Regex(@"^(\-|\+)?\d+(\.\d+)?$");
        ////有两位小数的正实数
        //Regex reg = new Regex(@"^[0-9]+(.[0-9]{2})?$");
        ////有1~3位小数的正实数
        //Regex reg = new Regex(@"^[0-9]+(.[0-9]{1,3})?$");
        ////非零的正整数
        //Regex reg = new Regex(@"^[1-9]\d*$ 或 ^([1-9][0-9]*){1,3}$ 或 ^\+?[1-9][0-9]*$");
        ////非零的负整数
        //Regex reg = new Regex(@"^\-[1-9][]0-9″*$ 或 ^-[1-9]\d*$");
        ////非负整数
        //Regex reg = new Regex(@"^\d+$ 或 ^[1-9]\d*|0$");
        ////非正整数
        //Regex reg = new Regex(@"^-[1-9]\d*|0$ 或 ^((-\d+)|(0+))$");
        ////非负浮点数
        //Regex reg = new Regex(@"^\d+(\.\d+)?$ 或 ^[1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0$");
        ////非正浮点数
        //Regex reg = new Regex(@"^((-\d+(\.\d+)?)|(0+(\.0+)?))$ 或 ^(-([1-9]\d*\.\d*|0\.\d*[1-9]\d*))|0?\.0+|0$");
        ////正浮点数
        //Regex reg = new Regex(@"^[1-9]\d*\.\d*|0\.\d*[1-9]\d*$ 或 ^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$");
        ////负浮点数
        //Regex reg = new Regex(@"^-([1-9]\d*\.\d*|0\.\d*[1-9]\d*)$ 或 ^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$");
        ////浮点数
        //Regex reg = new Regex(@"^(-?\d+)(\.\d+)?$ 或 ^-?([1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0)$");

    }
}
