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
using System.Windows.Shapes;

namespace SapatosWPF
{
    /// <summary>
    /// Lógica interna para WindowNovaVenda.xaml
    /// </summary>
    public partial class WindowNovaVenda : Window
    {
        public WindowNovaVenda()
        {
            InitializeComponent();
        }

        private void SalvarvendaButton_Click(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void CancelarVendaButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
