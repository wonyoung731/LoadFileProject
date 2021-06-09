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
using Microsoft.Win32;
using System.IO;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.BtnOpen.Click += BtnOpen_Click;
        }

        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFile();
        }
        private void OpenFile()
        {
            OpenFileDialog open = new OpenFileDialog()
            {
                Title = "Open Your File",
                Filter = "Text Document (*.txt) | *.txt",
                FileName = " "
            };

            if (open.ShowDialog() == true)
            {
                StreamReader sr = new StreamReader(File.OpenRead(open.FileName));
                TxtBody.Text = sr.ReadToEnd();
                sr.Dispose();
                
            }
            FileName.Text = "Filename:" + " " + System.IO.Path.GetFileNameWithoutExtension(open.FileName);
            charCount();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            charCount();
        }
        private void charCount()
        {

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }

        private void SaveFile()
        {
            SaveFileDialog save = new SaveFileDialog()
            {
                Title = "Save Your File",
                Filter = "Text Document (*.txt) | *.txt",
                FileName = " "
            };

            if (save.ShowDialog() == true)
            {
                StreamWriter sw = new StreamWriter(File.Create(save.FileName));
                sw.Write(save.FileName);
                sw.Dispose();
            }
            FileName.Text = "Filename: " + " " + System.IO.Path.GetFileNameWithoutExtension(save.FileName);
            charCount();
        }
    }
}
