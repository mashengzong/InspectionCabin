
using MoranControl;

namespace NucleicAcidSystem.CustomControl
{
    public class Tiptool
    {

        public static void resetColor(TipControl tipControl)
        {
            int[,] colors = new int[8, 12];
            colors = tipControl.fillColor;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    colors[i, j] = 0;
                }
            }
            tipControl.fillColor = colors;
            tipControl.Invalidate();
        }

        /// <summary>
        /// status 0--没有  1-有(3 4 5)  2-异常
        /// </summary>
        /// <param name="tipControl"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="status">status 0--没有  1-有  2-异常</param>
        /// <param name="tipType">tip类型</param>
        public static void updateColor(TipControl tipControl, int i, int j, int status, int tipType)
        {
            switch (tipType)
            {
                case 1://1000
                    if (status == 1)
                    {
                        status = 3;
                    }
                    break;
                case 2://200
                    if (status == 1)
                    {
                        status = 4;
                    }
                    break;
                case 3://50
                    if (status == 1)
                    {
                        status = 5;
                    }
                    break;
                default:
                    break;
            }

            int[,] colors = new int[8, 12];
            colors = tipControl.fillColor;
            colors[i, j] = status;
            tipControl.fillColor = colors;
            tipControl.Invalidate();
        }


        /// <summary>
        /// 更新一次
        /// </summary>
        /// <param name="tipControl"></param>
        /// <param name="allinfo"></param>
        public static void updateQuickColor(TipControl tipControl, int tipType)
        {
            int value = 0;
            switch (tipType)
            {
                case 1://1000
                    value = 3;
                    break;
                case 2://200
                    value = 4;
                    break;
                case 3://50
                    value = 5;
                    break;
                default:
                    break;
            }

            int[,] colors = new int[8, 12];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    colors[i, j] = value;
                }
            }
            tipControl.fillColor = colors;
            tipControl.Invalidate();
        }

        /// <summary>
        /// 设置tip颜色
        /// </summary>
        /// <param name="tipControl"></param>
        /// <param name="allinfo"></param>
        public static void updateAllColor(TipControl tipControl, int[,] colors, int tipType)
        {
            int value = 0;
            switch (tipType)
            {
                case 1://1000
                    value = 3;
                    break;
                case 2://200
                    value = 4;
                    break;
                case 3://50
                    value = 5;
                    break;
                default:
                    break;
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (colors[i, j] == 1)
                    {
                        colors[i, j] = value;
                    }
                }
            }
            tipControl.fillColor = colors;
            tipControl.Invalidate();
        }
    }
}
