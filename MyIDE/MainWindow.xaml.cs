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

using System.IO;

namespace MyIDE
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : System.Windows.Controls.Ribbon.RibbonWindow
    {      
        Microsoft.Win32.OpenFileDialog w32OpenDlg = new Microsoft.Win32.OpenFileDialog();
        Microsoft.Win32.SaveFileDialog w32SaveDlg = new Microsoft.Win32.SaveFileDialog();

        String strContents;
        String strFileName;
        
        public MainWindow()
        {
            InitializeComponent();
        }
        
        public void SetvOpenFileDialog()
        {
            w32OpenDlg.InitialDirectory = "E:\\"; //Default directory
            w32OpenDlg.FilterIndex = 0;
            w32OpenDlg.FileName = "Document"; // Default file name
            w32OpenDlg.DefaultExt = ".txt"; // Default file extension
            w32OpenDlg.Filter = // Filter files by extension 
                "Text documents (.txt)|*.txt| C++ documents (.cpp)|*.cpp| All files|*.*"; 
        }

        public void SetvSavevFileDialog()
        {
            w32OpenDlg.InitialDirectory = "E:\\"; //Default directory
            w32OpenDlg.FilterIndex = 0;
            w32SaveDlg.FileName = "Document"; // Default file name
            w32SaveDlg.DefaultExt = ".txt"; // Default file extension
            w32SaveDlg.Filter = // Filter files by extension 
                "Text documents (.txt)|*.txt| C++ documents (.cpp)|*.cpp| All files|*.*"; 
        }

        public String ReadstrFile(String strFileName)
        {
            String strContents;
            if (File.Exists(strFileName) == true)
            {
                StreamReader srReader;
                srReader = new StreamReader(strFileName);
                strContents = srReader.ReadToEnd();
                srReader.Close();
            }
            else
            {
                strContents = "";
                MessageBox.Show("File Not Exist");
            }
            return strContents;
        }

        public void WritevFile(String strContents)
        {
            if (System.IO.File.Exists(strFileName) == true)
            {
                FileStream fs = new FileStream(strFileName, FileMode.Truncate, FileAccess.Write);
                StreamWriter objWrite = new StreamWriter(fs);
                objWrite.Write(strContents);
                objWrite.Close();
            }
            else
            {
                FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write);
                StreamWriter objWrite = new StreamWriter(fs);
                objWrite.Write(strContents);
                objWrite.Close();
            }
        }

        private void OpenvClick(object sender, RoutedEventArgs e)
        {
            //rwWindowRoot.Background = new SolidColorBrush(Colors.Blue);
            //tbEditRegion.Text="sdfsdaf";

            SetvOpenFileDialog();
            // Show open file dialog box
            Nullable<bool> result = w32OpenDlg.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                // Open document
                strFileName = w32OpenDlg.FileName;
                tbEditRegion.Text = ReadstrFile(strFileName);
                //strContents = ;
            }
        }

        private void SavevClick(object sender, RoutedEventArgs e)
        {
            //rwWindowRoot.Background = new SolidColorBrush(Colors.White);
            SetvSavevFileDialog();
            strContents = tbEditRegion.Text;
            if (w32SaveDlg.ShowDialog().Value)
            {
                strFileName = w32SaveDlg.FileName;
                WritevFile(strContents);
            }

        }

    }
}
