using System;
using System.Text;

namespace SampleProcessingSystem.Utils
{
    class CommonDataUtil
    {
        public const String DataHeader = "EA 00";
        public const String DataEnd = "00 00 00 00";

        public static StringBuilder sb_Barcode1 = new StringBuilder();
        public static StringBuilder sb_Barcode2 = new StringBuilder();
        public static StringBuilder sb_Barcode3 = new StringBuilder();
        public static StringBuilder sb_Barcode4 = new StringBuilder();
    }
}
