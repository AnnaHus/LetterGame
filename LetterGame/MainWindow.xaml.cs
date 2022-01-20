using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LetterGame
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Label letterLabel;
        private Game game;
        public MainWindow()
        {
            InitializeComponent();
            this.letterLabel = CreateLetterLbl();
        }
        internal void RenderLetter(Letter letter)
        {
            letterLabel.Content = letter.LetterChar;
            letterLabel.Foreground = new SolidColorBrush(letter.FrtCol);
            this.Background = new SolidColorBrush(letter.BckCol);
            game.StartTimer();
        }

        private void ResetLetter(object sender, TextCompositionEventArgs e)
        {
            Console.WriteLine(e.Text);
           if (game.ValidKey(e.Text))
            {
                game.NewLetter();
                if(game.ActiveLetter != null)
                {
                    RenderLetter(game.ActiveLetter);
                }
                else
                {
                    this.PreviewTextInput -= ResetLetter;
                    CreateScoreGui();
                }
            }
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            CreateGameUI();         
            game = new Game();
            game.NewLetter();
            RenderLetter(game.ActiveLetter);
        }

        private void CreateGameUI()
        {
            Grid.Children.Clear();
            Grid.SetRow(letterLabel, 1);
            Grid.Children.Add(letterLabel);
            this.PreviewTextInput += ResetLetter;
        }

        private void CreateScoreGui()
        {
            this.Background = new SolidColorBrush(Color.FromRgb(194, 234, 189));
            DataGrid dataGrid = new DataGrid();
            dataGrid.ItemsSource = game.GameScore;
            dataGrid.VerticalAlignment = VerticalAlignment.Center;
            dataGrid.HorizontalAlignment = HorizontalAlignment.Center;
            StartBtn.VerticalAlignment = VerticalAlignment.Bottom;
            StartBtn.HorizontalAlignment = HorizontalAlignment.Right;
            StartBtn.Margin = new Thickness(20, 20, 20, 20);
            Grid.Children.Remove(letterLabel);
            Grid.SetRow(dataGrid, 0);
            Grid.SetRow(StartBtn, 1);
            Grid.Children.Add(dataGrid);
            Grid.Children.Add(StartBtn);

        }

        private Label CreateLetterLbl()
        {
            Label label = new Label();
            label.FontSize = 350;
            label.FontFamily = new FontFamily("Segoe UI Black");
            label.FontWeight = FontWeights.Bold;
            label.VerticalAlignment = VerticalAlignment.Center;
            label.HorizontalAlignment = HorizontalAlignment.Center;
            return label;
        }
    }
}
