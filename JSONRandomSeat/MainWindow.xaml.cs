﻿using System;
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
            //read in student JSON file
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "JSON files (*.json) | *.json";
            var result = dlg.ShowDialog();
            txtFile.Text = dlg.FileName;

        }

        private void BtnWorkstation_Click(object sender, RoutedEventArgs e)
        {
            //read in workstations JSON file
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "JSON files (*.json) | *.json";
            var result = dlg.ShowDialog();
            txtFile2.Text = dlg.FileName;
        }
         

        private void txtFile_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnPopulate_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(txtFile.Text) == true)
            {

                var lines = File.ReadAllLines(txtFile.Text);
                
                for (int i = 0; i < lines.Length; i++)
                {
                    //int number;
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
                   // int number;
                    var line = lines[i];
                    var column = line.Split(',');
                    string seat = column[0];
                    comboSeatRequired.Items.Add(seat);
                    comboBrokenSeat.Items.Add(seat);
                    Workstations.Add(seat);
                }

            }
        }


        private void btnSkipSeats_Click(object sender, RoutedEventArgs e)
        {
            btnPopulate_Click(sender, e);
            //IF Q1 IS EMPTY
            if (comboStudentSit1.Text == String.Empty && comboStudentSit2.Text == String.Empty)
            {
                //IF Q2 IS EMPTY
                if (comboStudentRequired.Text == String.Empty && comboSeatRequired.Text == String.Empty)
                {
                    //IF Q3 IS EMPTY
                    if (comboBrokenSeat.Text == String.Empty)
                    {
                        var random1 = new Random();
                        var result1 = StudentNames.OrderBy(item => random1.Next()).ToList();
                        for (int i = 0; i < result1.Count; i++)
                        {
                            lstSeatArrangement.Items.Add($"{result1[i]} - {Workstations[i]}");
                        }
                    }
                    //IF Q3 IS NOT EMPTY
                    else
                    {
                        var random1 = new Random();
                        var result1 = StudentNames.OrderBy(item => random1.Next()).ToList();

                        for (int i = 0; i < result1.Count; i++)
                        {
                            if (i != comboBrokenSeat.SelectedIndex)
                            {
                                lstSeatArrangement.Items.Add(result1[i] + Workstations[i]);
                            }
                            else
                            {
                                Workstations.RemoveRange(comboBrokenSeat.SelectedIndex, 1);
                            }

                        }
                    }
                }
                //IF Q2 IS NOT EMPTY
                else if (comboStudentRequired.Text != String.Empty && comboSeatRequired.Text != String.Empty)
                {
                    List<string> ExcludeStudentNames = new List<string>();
                    foreach (var student in StudentNames)
                    {
                        if (student != comboStudentRequired.Text)
                        {
                            ExcludeStudentNames.Add(student);
                        }

                    }
                    List<string> ExcludeWorkstations = new List<string>();
                    foreach (var station in Workstations)
                    {
                        if (station != comboSeatRequired.Text)
                        {
                            ExcludeWorkstations.Add(station);
                        }

                    }
                    //comboSeatRequired.SelectedIndex == comboStudentRequired.SelectedIndex;
                    //IF Q3 IS EMPTY
                    if (comboBrokenSeat.Text == String.Empty)
                    {
                        var random1 = new Random();
                        var result1 = ExcludeStudentNames.OrderBy(item => random1.Next()).ToList();
                        for (int i = 0; i < result1.Count; i++)
                        {
                            lstSeatArrangement.Items.Add($"{result1[i]} - {ExcludeWorkstations[i]}");
                        }
                    }
                    //IF Q3 IS NOT EMPTY
                    else
                    {
                        var random1 = new Random();
                        var result1 = ExcludeStudentNames.OrderBy(item => random1.Next()).ToList();
                        for (int i = 0; i < Workstations.Count; i++)
                        {
                            lstSeatArrangement.Items.Add($"{result1[i]} - {ExcludeWorkstations[i]}");
                        }
                    }
                    lstSeatArrangement.Items.Add($"{comboStudentRequired.Text} - {comboSeatRequired.Text}");
                }
                //IF ONLY HALF OF Q2 IS FILLED
                else
                {
                    lstSeatArrangement.Items.Add("Both of the combo boxes for the student name and required workstation must be blank or filled.");
                }
            }
            //IF Q1 IS FILLED
            else if (comboStudentSit1.Text != String.Empty && comboStudentSit2.Text != String.Empty)
            {
                //IF Q2 IS EMPTY
                if (comboStudentRequired.Text == String.Empty && comboSeatRequired.Text == String.Empty)
                {
                    //IF Q3 IS EMPTY
                    if (comboBrokenSeat.Text == String.Empty)
                    {
                        var random1 = new Random();
                        var result1 = StudentNames.OrderBy(item => random1.Next()).ToList();
                        for (int i = 0; i < result1.Count; i++)
                        {
                            lstSeatArrangement.Items.Add($"{result1[i]} - {Workstations[i]}");
                        }
                    }
                    //IF Q3 IS FILLED
                    else
                    {
                        var random1 = new Random();
                        var result1 = StudentNames.OrderBy(item => random1.Next()).ToList();
                        for (int i = 0; i < Workstations.Count; i++)
                        {
                            lstSeatArrangement.Items.Add(StudentNames[i] + Workstations[i]);
                        }
                    }
                }
                //IF Q2 IS FILLED 
                else if (comboStudentRequired.Text != String.Empty && comboSeatRequired.Text != String.Empty)
                {
                    //IF Q3 IS EMPTY
                    if (comboBrokenSeat.Text == String.Empty)
                        if (comboBrokenSeat.Text == String.Empty)
                        {
                            var random1 = new Random();
                            var result1 = StudentNames.OrderBy(item => random1.Next()).ToList();
                            for (int i = 0; i < result1.Count; i++)
                            {
                                lstSeatArrangement.Items.Add($"{result1[i]} - {Workstations[i]}");
                            }
                        }
                        //IF Q3 IS FILLED
                        else
                        {
                            var random1 = new Random();
                            var result1 = StudentNames.OrderBy(item => random1.Next()).ToList();
                            for (int i = 0; i < Workstations.Count; i++)
                            {
                                lstSeatArrangement.Items.Add(StudentNames[i] + Workstations[i]);
                            }
                        }
                }
                //IF HALF OF Q1 IS FILLED
                else
                {
                    lstSeatArrangement.Items.Add("Both of the combo boxes for the student names that cannot sit next to each other should be blank or filled");
                }
            }


            string StudentSit1 = comboStudentSit1.Text;
            string StudentSit2 = comboStudentSit2.Text;
        }

        private void btnAssignConsecutive_Click(object sender, RoutedEventArgs e)
        {
            btnPopulate_Click(sender, e);
            //IF Q1 IS EMPTY
            if (comboStudentSit1.Text == String.Empty && comboStudentSit2.Text == String.Empty)
            {
                //IF Q2 IS EMPTY
                if (comboStudentRequired.Text == String.Empty && comboSeatRequired.Text == String.Empty)
                {
                    //IF Q3 IS EMPTY
                    if (comboBrokenSeat.Text == String.Empty)
                    {
                        var random1 = new Random();
                        var result1 = StudentNames.OrderBy(item => random1.Next()).ToList();
                        for (int i = 0; i < result1.Count; i++)
                        {
                            lstSeatArrangement.Items.Add($"{result1[i]} - {Workstations[i]}");
                        }
                    }
                    //IF Q3 IS NOT EMPTY
                    else
                    {
                        var random1 = new Random();
                        var result1 = StudentNames.OrderBy(item => random1.Next()).ToList();
                        for (int i = 0; i < result1.Count; i++)
                        {
                            if (i != comboBrokenSeat.SelectedIndex)
                            {
                                lstSeatArrangement.Items.Add(result1[i] + Workstations[i]);
                            }
                            else
                            {
                                Workstations.RemoveAt(comboBrokenSeat.SelectedIndex);
                            }
                        }
                    }
                }
                //IF Q2 IS NOT EMPTY
                else if (comboStudentRequired.Text != String.Empty && comboSeatRequired.Text != String.Empty)
                {
                    //comboSeatRequired.SelectedIndex == comboStudentRequired.SelectedIndex;
                    //IF Q3 IS EMPTY
                    if (comboBrokenSeat.Text == String.Empty)
                    {
                        var random1 = new Random();
                        var result1 = StudentNames.OrderBy(item => random1.Next()).ToList();
                        for (int i = 0; i < result1.Count; i++)
                        {
                            lstSeatArrangement.Items.Add($"{result1[i]} - {Workstations[i]}");
                        }
                    }
                    //IF Q3 IS NOT EMPTY
                    else
                    {
                        var random1 = new Random();
                        var result1 = StudentNames.OrderBy(item => random1.Next()).ToList();
                        for (int i = 0; i < Workstations.Count; i++)
                        {
                            lstSeatArrangement.Items.Add(StudentNames[i] + Workstations[i]);
                        }
                    }
                }
                //IF ONLY HALF OF Q2 IS FILLED
                else
                {
                    lstSeatArrangement.Items.Add("Both of the combo boxes for the student name and required workstation must be blank or filled.");
                }
            }
            //IF Q1 IS FILLED
            else if (comboStudentSit1.Text != String.Empty && comboStudentSit2.Text != String.Empty)
            {
                //IF Q2 IS EMPTY
                if (comboStudentRequired.Text == String.Empty && comboSeatRequired.Text == String.Empty)
                {
                    //IF Q3 IS EMPTY
                    if (comboBrokenSeat.Text == String.Empty)
                    {
                        var random1 = new Random();
                        var result1 = StudentNames.OrderBy(item => random1.Next()).ToList();
                        for (int i = 0; i < result1.Count; i++)
                        {
                            lstSeatArrangement.Items.Add($"{result1[i]} - {Workstations[i]}");
                        }
                    }
                    //IF Q3 IS FILLED
                    else
                    {
                        var random1 = new Random();
                        var result1 = StudentNames.OrderBy(item => random1.Next()).ToList();
                        for (int i = 0; i < Workstations.Count; i++)
                        {
                            lstSeatArrangement.Items.Add(StudentNames[i] + Workstations[i]);
                        }
                    }
                }
                //IF Q2 IS FILLED 
                else if (comboStudentRequired.Text != String.Empty && comboSeatRequired.Text != String.Empty)
                {
                    //IF Q3 IS EMPTY
                    if (comboBrokenSeat.Text == String.Empty)
                        if (comboBrokenSeat.Text == String.Empty)
                        {
                            var random1 = new Random();
                            var result1 = StudentNames.OrderBy(item => random1.Next()).ToList();
                            for (int i = 0; i < result1.Count; i++)
                            {
                                lstSeatArrangement.Items.Add($"{result1[i]} - {Workstations[i]}");
                            }
                        }
                        //IF Q3 IS FILLED
                        else
                        {
                            var random1 = new Random();
                            var result1 = StudentNames.OrderBy(item => random1.Next()).ToList();
                            for (int i = 0; i < Workstations.Count; i++)
                            {
                                lstSeatArrangement.Items.Add(StudentNames[i] + Workstations[i]);
                            }
                        }
                }
                //IF HALF OF Q1 IS FILLED
                else
                {
                    lstSeatArrangement.Items.Add("Both of the combo boxes for the student names that cannot sit next to each other should be blank or filled");
                }
            }


            string StudentSit1 = comboStudentSit1.Text;
            string StudentSit2 = comboStudentSit2.Text;
        }
    }
}
