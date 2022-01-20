using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterGame
{
    internal class Score
    {
        public char Letter { get; set; }
        public int TimeScore { get; set; }  

        public Score(char letter,int score)
        {
            Letter = letter;
            TimeScore = score;
        }

        public override string ToString()
        {
            return $"{Letter}: {TimeScore}";
        } 
    }
}
