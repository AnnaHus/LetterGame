using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace LetterGame
{
    internal class Letter
    {
        Random random = new Random();
        Color[][] colors = new Color[][]
        {
            new Color[]{Color.FromRgb(148, 147, 152), Color.FromRgb(244, 223, 78)},
            new Color[]{Color.FromRgb(255, 101, 80), Color.FromRgb(91, 132, 177)},
            new Color[]{Color.FromRgb(0, 0, 0), Color.FromRgb(255, 255, 255)},
            new Color[]{Color.FromRgb(0, 32, 63), Color.FromRgb(173, 239, 209)},
            new Color[]{Color.FromRgb(96, 96, 96), Color.FromRgb(214, 237, 23)},
            new Color[]{Color.FromRgb(44, 95, 45), Color.FromRgb(151, 188, 98)},
            new Color[]{Color.FromRgb(0, 83, 156), Color.FromRgb(238, 164, 127)},
            new Color[]{Color.FromRgb(0, 99, 178), Color.FromRgb(156, 195, 213)},
            new Color[]{Color.FromRgb(16, 24, 32), Color.FromRgb(242, 170, 76)},
            new Color[]{Color.FromRgb(25, 81, 144), Color.FromRgb(162, 162, 161)},
            new Color[]{Color.FromRgb(96, 63, 131), Color.FromRgb(199, 211, 212)},
            new Color[]{Color.FromRgb(43, 174, 102), Color.FromRgb(252, 246, 245)},
            new Color[]{Color.FromRgb(218, 160, 61), Color.FromRgb(97, 98, 71)},
            new Color[]{Color.FromRgb(153, 0, 17), Color.FromRgb(252, 246, 245)},
            new Color[]{Color.FromRgb(203, 206, 145), Color.FromRgb(118, 82, 139)},
            new Color[]{Color.FromRgb(250, 235, 239), Color.FromRgb(51, 61, 121)},
            new Color[]{Color.FromRgb(249, 56, 34), Color.FromRgb(253, 210, 14)},
            new Color[]{Color.FromRgb(242, 237, 215), Color.FromRgb(117, 81, 57)},
            new Color[]{Color.FromRgb(0, 107, 56), Color.FromRgb(16, 24, 32)},
            new Color[]{Color.FromRgb(249, 87, 0), Color.FromRgb(255, 255, 255)},
            new Color[]{Color.FromRgb(255, 214, 98), Color.FromRgb(0, 83, 156)},
            new Color[]{Color.FromRgb(252, 249, 81), Color.FromRgb(66, 32, 87)},
            new Color[]{Color.FromRgb(0, 177, 210), Color.FromRgb(253, 219, 39)},
            new Color[]{Color.FromRgb(0, 35, 156), Color.FromRgb(225, 6, 0)},
            new Color[]{Color.FromRgb(249, 161, 46), Color.FromRgb(155, 74, 151)},
            new Color[]{Color.FromRgb(255, 62, 165), Color.FromRgb(237, 255, 0)}
        };
        char[] pattern = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        public char LetterChar { get; }
        public Color BckCol { get; }
        public Color FrtCol { get; }
        public Letter()
        {
            int rnd = random.Next(0, pattern.Length);
            LetterChar = GenerateLetter(rnd);
            BckCol = GenerateBckColor(rnd);
            FrtCol = GenerateFrtColor(rnd);
        }
        private char GenerateLetter(int rnd)
        {            
            return pattern[rnd];
        }

        private Color GenerateBckColor(int rnd)
        {
            return colors[rnd][0];
        }
        private Color GenerateFrtColor(int rnd)
        {
            return colors[rnd][1];
        }

        public bool CorrectKey(char key)
        {
            return (key == LetterChar);
        }
    }
}
