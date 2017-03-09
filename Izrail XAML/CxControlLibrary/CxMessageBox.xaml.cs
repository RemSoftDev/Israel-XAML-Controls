using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CxControlLibrary
{
    /// <summary>
    /// Interaction logic for CxMessageBox.xaml
    /// </summary>
    public partial class CxMessageBox : Window
    {

        public CxDialogResultEnum DialogResult { get; set; }
        public CxMessageBox()
        {
            InitializeComponent();
        }



        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = CxDialogResultEnum.Cancel;
            MessageBox.Show(DialogResult.ToString());
            this.Close();
        }

        private void MainButton_ButtonClick(object sender, EventArgs e)
        {
            MainButton btn = sender as MainButton;
            if(btn.ContentText == "Yes")
            {
                DialogResult = CxDialogResultEnum.Yes;
            }
            if(btn.ContentText == "No")
            {
                DialogResult = CxDialogResultEnum.No;
            }
            
            MessageBox.Show(DialogResult.ToString());
            this.Close();
        }
    }
}
