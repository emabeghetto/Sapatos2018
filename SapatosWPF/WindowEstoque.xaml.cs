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
    /// Lógica interna para WindowEstoque.xaml
    /// </summary>
    public partial class WindowEstoque : Window
    {
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


        private Estoque EstoqueSelecionado
        {
            get =>_EstoqueSelecionado;
            set
            {
                _EstoqueSelecionado = value;
                this.NotifyPropertyChanged("EstoqueSelecionado");
            }
        }

        public ICollection<Estoque> Estoques
        {
            get { return _Estoques; }
            set
            {
                _Estoques = value;
                this.NotifyPropertyChanged("Estoques");
            }
        }

        public Boolean ModoCriacaoEstoque { get; set; } = false;

        public ICollection<ModeloSapato> ModeloSapatos
        {
            get
            {
                return _ModeloSapatos;
            }

            set
            {
                _ModeloSapatos = value;
                this.NotifyPropertyChanged("Modelo Sapatos");
            }
        }

        public Visibility VisibilidadeDataGrid
        {
            get
            {
                if (ModoCriacaoEstoque)
                {
                    return Visibility.Hidden;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }

        //contexto e iniciadores

        private BancoContext ctx = new BancoContext();
        private Estoque _EstoqueSelecionado;
        private ICollection<Estoque> _Estoques;
        private ICollection<ModeloSapato> _ModeloSapatos;



        public WindowEstoque()
        {
            InitializeComponent();

            this.Estoques = ctx.Estoques.ToList();
            this.ModeloSapatos = ctx.ModeloSapatos.ToList();
            if (!ModoCriacaoEstoque)
            {
                this.EstoqueSelecionado = this.Estoques.FirstOrDefault();
            }
            this.DataContext = this;
        }

        private void SalvarEstoqueButton_Click(object sender, RoutedEventArgs e)
        {
            if (ModoCriacaoEstoque)
            {
                if (this.EstoqueSelecionado.Id <= 0)
                {
                    ctx.Estoques.Add(this.EstoqueSelecionado);
                }
            }
            ctx.SaveChanges();
            MessageBox.Show("Estoque Atualizados");
            this.Close();
        }


        private void CancelarEstoqueButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void EstoqueDataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Estoque item in e.RemovedItems)
            {
                ctx.Estoques.Remove(item);
            }
        }
    }
}
