using BibliotecaModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Lógica interna para WindowCliente.xaml
    /// </summary>
    public partial class WindowCliente : Window
    {
        private BancoContext ctx = new BancoContext();


        #region "NotifyPropertyChanged"
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string Property)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(
                    Property));
            }
        }
        #endregion
        private ClientePF _ClientePFSelecionado;
        private ClientePF ClientePFSelecionado
        {
            get => _ClientePFSelecionado;
            set
            {
                _ClientePFSelecionado = value;
                this.NotifyPropertyChanged("ClientePFSelecionado");
            }
        }

        private ClientePJ _ClientePJSelecionado;
        private ClientePJ ClientePJSelecionado
        {
            get => _ClientePJSelecionado;
            set
            {
                _ClientePJSelecionado = value;
                this.NotifyPropertyChanged("ClientePJSelecionado");
            }
        }


        public WindowCliente()
        {
            InitializeComponent();
        }

        private void SalvarPFButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.ClientePFSelecionado.Id <= 0)
            {
                ctx.ClientePFs.Add(this.ClientePFSelecionado);
            }

            ctx.SaveChanges();
            MessageBox.Show("Salvo com Sucesso");
            this.Close();
        }

        private void SalvarPJButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.ClientePJSelecionado.Id <= 0)
            {
                ctx.ClientePJs.Add(this.ClientePJSelecionado);
            }

            ctx.SaveChanges();
            MessageBox.Show("Salvo com Sucesso");
            this.Close();
        }

        private void CancelarClienteButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
