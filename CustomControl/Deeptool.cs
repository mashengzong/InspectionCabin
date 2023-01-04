
using MoranControl;

namespace NucleicAcidSystem.CustomControl
{
    public class Deeptool
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


        public static void updateColor(DeepControl deepControl, int i, int j, int type)
        {
            int[,] colors = new int[8, 12];
            colors = deepControl.fillColor;
            colors[i, j] = type;
            deepControl.fillColor = colors;
            deepControl.Invalidate();
        }
        public static void updateQuickColor(DeepControl deepControl, int[,] alldeep)
        {
            deepControl.fillColor = alldeep;
            deepControl.Invalidate();
        }
    }
}
