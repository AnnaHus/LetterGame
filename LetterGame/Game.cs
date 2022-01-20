using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace LetterGame
{
    internal class Game
    {
        int Rounds;
        int Iteration;
        SoundPlayer errorSound;
        SoundPlayer correctSound;
        Stopwatch stopwatch;
        public Letter ActiveLetter { get; set; }
        public Score[] GameScore { get; set; }

        public Game()
        {
            Rounds = 2;
            Iteration = 0;
            errorSound = new SoundPlayer(Properties.Resources.error);
            correctSound = new SoundPlayer(Properties.Resources.win);
            stopwatch = new Stopwatch();
            GameScore = new Score[Rounds];
        }

        public void NewLetter()
        {
            if (Iteration < Rounds)
            {
                ActiveLetter = new Letter();
                Iteration++;
            }
            else ActiveLetter = null;
        }

        public bool ValidKey(string Key)
        {
            if (ActiveLetter.CorrectKey(Convert.ToChar(Key.ToUpperInvariant())))
            {
                StopTimer();
                correctSound.Play();
                return true;
            }
            else
            {
                errorSound.Play();
                return false;
            }
        }

        public void StartTimer()
        {
            stopwatch.Reset();
            stopwatch.Start();
        }

        public void StopTimer()
        {
            stopwatch.Stop();
            TimeSpan stopwatchElapsed = stopwatch.Elapsed;
            GameScore[Iteration-1] = new Score(ActiveLetter.LetterChar, stopwatchElapsed.Seconds);
        }
    }
}
