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
using Newtonsoft.Json;
using System.IO;

namespace JSONRandomSeat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRollSheet_Click(object sender, RoutedEventArgs e)
        {
            //read in *only* JSON files
            //students
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "JSON files (*.json) | *.json";
            var result = dlg.ShowDialog();
            txtFile.Text = dlg.FileName;

        }

        private void BtnWorkstation_Click(object sender, RoutedEventArgs e)
        {
            //read in *only* JSON files
            //workstations
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "JSON files (*.json) | *.json";
            var result = dlg.ShowDialog();
            txtFile2.Text = dlg.FileName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(txtFile.Text) == true)
            {

                var lines = File.ReadAllLines(txtFile.Text);
                //List<int> seatNumbers = new List<int>();
                //Random random = new Random();
                //int row = 0;

                for (int i =0; i<lines.Length; i++)
                {
                    int number;

                    var line = lines[i];
                    var column = line.Split(',');
                    string name = column[0];
                }
                
            }
            
            if (File.Exists(txtFile2.Text) == true)
            {

                var lines = File.ReadAllLines(txtFile2.Text);
                 for (int i =0; i<lines.Length; i++)
                 {
                    int number;

                    var line = lines[i];
                    var column = line.Split(',');
                    string name = column[0];

                 }
                
            }
        }
    }
}
