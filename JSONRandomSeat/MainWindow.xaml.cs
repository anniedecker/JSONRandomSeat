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
        List<string> StudentNames = new List<string>();
        List<string> Workstations = new List<string>();
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

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    if (File.Exists(txtFile.Text) == true)
        //    {

        //        var lines = File.ReadAllLines(txtFile.Text);
        //        //List<int> seatNumbers = new List<int>();
        //        //Random random = new Random();
        //        //int row = 0;

        //        for (int i =0; i<lines.Length; i++)
        //        {
        //            int number;

        //            var line = lines[i];
        //            var column = line.Split(',');
        //            string name = column[0];
        //        }
                
        //    }
            
        //    if (File.Exists(txtFile2.Text) == true)
        //    {

        //        var lines = File.ReadAllLines(txtFile2.Text);
        //         for (int i =0; i<lines.Length; i++)
        //         {
        //            int number;

        //            var line = lines[i];
        //            var column = line.Split(',');
        //            string name = column[0];

        //         }
                
        //    }
        //}

        private void txtFile_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnPopulate_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(txtFile.Text) == true)
            {

                var lines = File.ReadAllLines(txtFile.Text);
                //List<int> seatNumbers = new List<int>();
                //Random random = new Random();
                //int row = 0;
                
                for (int i = 0; i < lines.Length; i++)
                {
                    int number;
                    var line = lines[i];
                    var column = line.Split(',');
                    string name = column[0];
                    comboStudentSit1.Items.Add(name);
                    comboStudentSit2.Items.Add(name);
                    comboStudentRequired.Items.Add(name);
                    StudentNames.Add(name);
                }

            }
            if (File.Exists(txtFile2.Text) == true)
            {
                
                var lines = File.ReadAllLines(txtFile2.Text);
                for (int i = 0; i < lines.Length; i++)
                {
                    int number;
                    var line = lines[i];
                    var column = line.Split(',');
                    string seat = column[0];
                    comboSeatRequired.Items.Add(seat);
                    comboBrokenSeat.Items.Add(seat);
                    Workstations.Add(seat);
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            btnPopulate_Click(sender, e);
            if  (comboStudentSit1.Text == String.Empty && comboStudentSit2.Text == String.Empty)
            {
                 if (comboStudentRequired.Text == String.Empty && comboSeatRequired.Text == String.Empty)
                {

                }
                else if (comboStudentRequired.Text == String.Empty && comboSeatRequired.Text == String.Empty)
                {

                }
                 else
                {
                    lstSeatArrangement.Items.Add("Both of the combo boxes for the student name and required workstation must be blank or filled.");
                }
            }
            else if (comboStudentSit1.Text != String.Empty && comboStudentSit2.Text != String.Empty)
            {
                if (comboStudentRequired.Text == String.Empty && comboSeatRequired.Text == String.Empty)
                {

                }
                else if (comboStudentRequired.Text == String.Empty && comboSeatRequired.Text == String.Empty)
                {

                }
                else
                {
                    lstSeatArrangement.Items.Add("Both of the combo boxes for the student name and required workstation must be blank or filled.");
                }
            }
            var random1 = new Random();
            var result1 = StudentNames.OrderBy(item => random1.Next()).ToList();
            for (int i = 0; i < Workstations.Count; i++)
            {
                    lstSeatArrangement.Items.Add(StudentNames[i] + Workstations[i]);
            }

            string StudentSit1 = comboStudentSit1.Text;
            string StudentSit2 = comboStudentSit2.Text;
        }
    }
}
