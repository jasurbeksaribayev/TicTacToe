using System.Windows;
using System.Windows.Controls;


namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool turnGamers = true;
        private Button[,] buttons = new Button[3, 3];
        
        public MainWindow()
        {
            InitializeComponent();

            buttons[0, 0] = Btn00;
            buttons[0, 1] = Btn01;
            buttons[0, 2] = Btn02;
            buttons[1, 0] = Btn10;
            buttons[1, 1] = Btn11;
            buttons[1, 2] = Btn12;
            buttons[2, 0] = Btn20;
            buttons[2, 1] = Btn21;
            buttons[2, 2] = Btn22;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string symbol = "";

            int countArrayElements = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (buttons[i, j].Content != null)
                    {
                        countArrayElements++;
                    }
                    else { break; }
                }
            }

            if (button.Content != null) { return; }
            
            
            if (turnGamers )
                {
                symbol = "X";
                turnGamers = false;
                }
                else
                {
                symbol = "O";
                turnGamers = true;
                }

            button.Content = symbol;

            if (CheckWinner())
            {
                MessageBox.Show("Congratulation '" + symbol + "' won 🥇 ");
                ResetGame();
                return;
            }
            if(!CheckWinner() & CountArrayElements() == 9)
            {
                MessageBox.Show("Noone won 🙃 ");
                ResetGame();
            }
        }

       
        private bool CheckWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (buttons[0, i].Content != null & buttons[0, i].Content == buttons[1, i].Content & buttons[1, i].Content == buttons[2, i].Content)
                {
                    
                    return true;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (buttons[i, 0].Content != null & buttons[i, 0].Content == buttons[i, 1].Content & buttons[i, 1].Content == buttons[i, 2].Content)
                {
                    

                    return true;
                }
            }

            if (buttons[0, 0].Content != null & buttons[0, 0].Content == buttons[1, 1].Content & buttons[1, 1].Content == buttons[2, 2].Content)
            {
                return true;
            }

            if (buttons[0, 2].Content != null & buttons[0, 2].Content == buttons[1, 1].Content & buttons[1, 1].Content == buttons[2, 0].Content)
            {
                return true;
            }

            return false; 
        }
        
        private int CountArrayElements()
        {
            int count = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (buttons[i, j].Content != null)
                    {
                        count++;
                    }
                    else { break; }
                }
            }
            return count;
        }
        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetGame();
        }
        
        private void ResetGame()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i,j].Content = null;
                }
            }
            turnGamers = true;
        }
    }
}
