using GraMemory.Model;
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

namespace GraMemory
{
    /// <summary>
    /// Interaction logic for Mem.xaml
    /// </summary>
    public partial class Mem : UserControl
    {
        private int no = -1;

        public MemPossition Possition { get; set; }

        public bool isActive;

        public bool isVisible { get { return this.Visibility == Visibility.Visible ? true : false; }
            set { this.Visibility = value == true ? Visibility.Visible : Visibility.Collapsed; }
        }

        private Grid MemBody;

        public Mem(MemPossition possition,int no)
        {           
            InitializeComponent();
            this.no = no;
            Grid.SetRow(this, possition.memY);
            Grid.SetColumn(this, possition.memX);
            Possition = possition;
            isActive = false;
            isVisible = false;
            if (GameHandler.GameType == GameType.number)
            {
                Numer.Text = no.ToString();
            }           
        }

        private async void Color_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {         
            if(isActive)
            {
                this.isActive = false;
                this.isVisible = false;
                await GameHandler.CheckOrder(Possition);            
            }
        }

        
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            MemBody = sender as Grid;
            switch (GameHandler.GameType)
            {
                case GameType.memory:
                    MemBody.Background = new SolidColorBrush(GameHandler.ColorsList[no]);
                    break;
                case GameType.number:
                    Random rand = new Random();
                    byte r = (byte)rand.Next(0, 256);
                    byte g = (byte)rand.Next(0, 256);
                    byte b = (byte)rand.Next(0, 256);
                    MemBody.Background = new SolidColorBrush(Color.FromArgb(255, r,g,b));
                    break;
                case GameType.colors:
                    //int singl = (255 / (32))-5;
                    int singl = (255 / (App.GamePage.VM.Level * 3 + 4))-2;
                    MemBody.Background = new SolidColorBrush(Color.FromArgb(255, 90,Convert.ToByte(singl*no),210));
                    //MemBody.Background = new SolidColorBrush(Color.FromArgb(255, Convert.ToByte(singl * no), Convert.ToByte(singl * no), Convert.ToByte(singl * no)));
                    break;
                default:
                    break;
            }
            
        }
    }
}
