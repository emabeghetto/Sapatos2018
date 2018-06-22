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

namespace SapatosWPF
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click_NovaVenda(object sender, RoutedEventArgs e)
        {
            WindowNovaVenda window =
              new WindowNovaVenda();
             window.ShowDialog();
        }

        private void MenuItem_Click_Sapato(object sender, RoutedEventArgs e)
        {
            if (sender == MenuNovoSapato)
            {
                WindowSapato window =
              new WindowSapato();
                window.ModoCriacaoSapato = true;
                window.ShowDialog();
            }
             
        }

        private void MenuItem_Click_Cliente(object sender, RoutedEventArgs e)
        {
            WindowCliente window =
              new WindowCliente();
            window.ShowDialog();
        }

        private void MenuItem_Click_Estoque(object sender, RoutedEventArgs e)
        {
            WindowEstoque window =
             new WindowEstoque();
            window.ShowDialog();
        }

         
    }
}
