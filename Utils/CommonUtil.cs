using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SampleProcessingSystem.Utils
{
    public static class CommonUtil
    {
        /// <summary>
        /// 字符串转16进制字符
        /// </summary>
        /// <param name="_str">字符串</param>
        /// <param name="encode">编码格式</param>
        /// <returns></returns>
        public static string StringToHexString(string _str, Encoding encode)
        {
            //去掉空格
            _str = _str.Replace(" ", "");
            //将字符串转换成字节数组。
            byte[] buffer = encode.GetBytes(_str);
            //定义一个string类型的变量，用于存储转换后的值。
            string result = string.Empty;
            for (int i = 0; i < buffer.Length; i++)
            {
                //将每一个字节数组转换成16进制的字符串，以空格相隔开。
                result += Convert.ToString(buffer[i], 16);
            }
            return result;
        }

        /// <summary>
        /// 16进制字符转字符串
        /// </summary>
        /// <param name="hex">16进制字符</param>
        /// <param name="encode">编码格式</param>
        /// <returns></returns>
        public static string HexStringToString(string hex, Encoding encode)
        {
            byte[] buffer = new byte[hex.Length / 2];
            string result = string.Empty;
            for (int i = 0; i < hex.Length / 2; i++)
            {
                result = hex.Substring(i * 2, 2);
                buffer[i] = Convert.ToByte(result, 16);
            }
            //返回指定编码格式的字符串
            return encode.GetString(buffer);
        }

        /// <summary>
        /// 字符串 10进制转16进制加空格
        /// </summary>
        /// <param name="decString"></param>
        /// <param name="lenth"></param>
        /// <returns></returns>
        public static string DecStringToHex(string decString, int lenth)
        {
            return Regex.Replace(Convert.ToString(Int32.Parse(decString), 16).PadLeft(lenth, '0'), @"(\d{2}(?!$))", "$1 ");
        }

        /// <summary>
        /// int 10进制转16进制加空格
        /// </summary>
        /// <param name="decNum"></param>
        /// <param name="lenth"></param>
        /// <returns></returns>
        public static string DecToHex(int decNum, int lenth)
        {
            return Regex.Replace(Convert.ToString(decNum, 16).PadLeft(lenth, '0'), @"(\d{2}(?!$))", "$1 ");
        }

        /// <summary>
        /// int 16进制转10进制
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static int HexStringToDec(string hexString)
        {
            return Convert.ToInt32(hexString, 16);
        }

        /// <summary>
        /// 字符串 2进制转16进制加空格
        /// </summary>
        /// <param name="binaryString"></param>
        /// <param name="lenth"></param>
        /// <returns></returns>
        public static string BinaryStringToHex(string binaryString, int lenth)
        {
            return Regex.Replace(string.Format("{0:X}", Convert.ToInt32(binaryString, 2)).PadLeft(lenth, '0'), @"(\d{2}(?!$))", "$1 ");
        }

        /// <summary>
        /// 字符串 16进制转2进制
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static string HexStringToBinary(string hexString, int length)
        {
            string result = string.Empty;
            foreach (char c in hexString)
            {
                int v = Convert.ToInt32(c.ToString(), 16);
                int v2 = int.Parse(Convert.ToString(v, 2));
                // 去掉格式串中的空格，即可去掉每个4位二进制数之间的空格
                result += string.Format("{0:d4}", v2);
            }
            return result.PadLeft(length, '0');
        }


        /// <summary>
        /// 字符串 16进制转2进制
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static string HexStringToBinary(string hexString)
        {
            string result = string.Empty;
            foreach (char c in hexString)
            {
                int v = Convert.ToInt32(c.ToString(), 16);
                int v2 = int.Parse(Convert.ToString(v, 2));
                // 去掉格式串中的空格，即可去掉每个4位二进制数之间的空格
                result += string.Format("{0:d4}", v2);
            }
            return result;
        }

        /// <summary>
        /// 负数转十六进制
        /// </summary>
        /// <param name="iNumber"></param>
        /// <returns></returns>
        public static string NegativeToHexString(int iNumber)
        {
            string strResult = string.Empty;

            if (iNumber < 0)
            {
                iNumber = -iNumber;//转为正数
            }

            string strNegate = string.Empty;

            char[] binChar = Convert.ToString(iNumber, 2).PadLeft(8, '0').ToArray();//把iNumber转换成2进制，从左侧用0填充达到总长度

            foreach (char ch in binChar)
            {
                if (Convert.ToInt32(ch) == 48)
                {
                    strNegate += "1";
                }
                else
                {
                    strNegate += "0";
                }
            }

            int iComplement = Convert.ToInt32(strNegate, 2) + 1;//strNegt由2进制转为10进制

            strResult = Convert.ToString(iComplement, 16).ToUpper();//iComplement由十进制转为16进制

            return Regex.Replace(strResult, @"(?<=[0-9A-F]{2})[0-9A-F]{2}", " $0");//将字符串用空格隔开
        }

        // <summary>
        /// 负数转十六进制
        /// </summary>
        /// <param name="iNumber"></param>
        /// <returns></returns>
        public static string NegativeToHexString(int iNumber, int lenth)
        {
            string strResult = string.Empty;
            if (iNumber > 0)
            {
                iNumber = -iNumber;
                if (iNumber < 0)
                {
                    iNumber = -iNumber;//转为正数
                    string strNegt = string.Empty;
                    char[] binChar = Convert.ToString(iNumber, 2).PadLeft(32, '0').ToArray();//把iNumber转换成2进制，从左侧用0填充达到总长度
                    foreach (char ch in binChar)
                    {
                        if (Convert.ToInt32(ch) == 48)
                        {
                            strNegt += "1";
                        }
                        else
                        {
                            strNegt += "0";
                        }
                    }
                    int iComplement = Convert.ToInt32(strNegt, 2) + 1;//strNegt由2进制转为10进制
                    strResult = Convert.ToString(iComplement, 16).ToUpper();//iComplement由十进制转为16进制
                }
            }
            return Regex.Replace(strResult.PadLeft(lenth, 'F'), @"(?<=[0-9A-F]{2})[0-9A-F]{2}", " $0");//将字符串用空格隔开
        }

        /// <summary>
        /// 16进制取负数
        /// </summary>
        /// <param name="strNumber"></param>
        /// <returns></returns>
        public static int HexToNegative(string strNumber)
        {
            int iNegt = 0;
            int iNumber = Convert.ToInt32(strNumber, 16);//把strNumber由16进制转换为十进制
            if (iNumber > 127)
            {
                int num = iNumber - 1;
                string strNegt = string.Empty;
                char[] binChar = Convert.ToString(num, 2).PadLeft(8, '0').ToArray();//把num转换成2进制，从左侧用0填充达到八个总长度
                foreach (char ch in binChar)
                {
                    if (Convert.ToInt32(ch) == 48)
                    {
                        strNegt += "1";
                    }
                    else
                    {
                        strNegt += "0";
                    }
                }
                iNegt = -Convert.ToInt32(strNegt, 2);
            }
            return iNegt;
        }

        /// <summary>
        /// 增加校验
        /// </summary>
        /// <param name="order">待校验的指令</param>
        /// <returns></returns>
        public static string Check(string order)
        {
            string old = order.Replace(" ", "");

            string allorder = "";
            for (int i = 0; i < old.Length; i++)
            {
                if (i < (old.Length / 2))
                {
                    string splitvalue = old.Substring(i * 2, 2);
                    allorder += splitvalue + " ";
                }
            }

            int total = 0;
            string[] Nums = allorder.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string num in Nums)
            {
                total += Convert.ToByte(num, 16);
            }
            int lg = total.ToString("X").Length;
            if (lg > 1)
            {
                return allorder + " " + total.ToString("X").Substring(lg - 2, 2);
            }
            else
            {
                return allorder + " 0" + total.ToString("X");
            }
        }

        /// <summary>
        /// 版本号显示
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string GetVersion(string param)
        {
            param = param.Replace(" ", "");
            string[] m = System.Text.RegularExpressions.Regex.Split(param, @"(?<=\G.{2})(?!$)");
            string version = "";
            for (int i = 0; i < m.Length; i++)
            {
                if (i == m.Length - 1)
                    version = version + m[i].Substring(1, 1);
                else
                    version = version + m[i].Substring(1, 1) + ".";
            }
            return version;
        }

        /// <summary>  
        /// 秒转时分秒 
        /// </summary>  
        /// <param name="time"></param>  
        /// <returns></returns>  
        public static string SecondToHour(int time)
        {
            StringBuilder str = new StringBuilder();
            int hour = 0;
            int minute = 0;
            int second = 0;
            second = time;

            if (second > 60)
            {
                minute = second / 60;
                second = second % 60;
            }
            if (minute > 60)
            {
                hour = minute / 60;
                minute = minute % 60;
            }
            if (hour > 0 && hour < 10)
            {
                str.Append("0" + hour);
            }
            else if (hour >= 10)
            {
                str.Append(hour);
            }
            else
            {
                str.Append("00");
            }
            str.Append(":");
            if (minute > 0 && minute < 10)
            {
                str.Append("0" + minute);
            }
            else if (minute >= 10)
            {
                str.Append(minute);
            }
            else
            {
                str.Append("00");
            }
            str.Append(":");
            if (second > 0 && second < 10)
            {
                str.Append("0" + second);
            }
            else if (second >= 10)
            {
                str.Append(second);
            }
            else
            {
                str.Append("00");
            }
            return str.ToString();
        }
    }
}