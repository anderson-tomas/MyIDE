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

namespace MyIDE
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : System.Windows.Controls.Ribbon.RibbonWindow
    {
        TextBlock textBlock1 = new TextBlock();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Background = new SolidColorBrush(Colors.Blue);
            //textBlock1.Text = "asd";
            //MainFrame.AddChild(textBlock1);
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Background = new SolidColorBrush(Colors.White);
        }

    }
}
