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
    /// Lógica interna para WindowSapato.xaml
    /// </summary>
    public partial class WindowSapato : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string Property)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(
                    Property));
            }
        }

        //--- contexto ----

        private BancoContext ctx = new BancoContext();
        private ModeloSapato _SapatoSelecionado = new ModeloSapato();
        private ICollection<ModeloSapato> _ModeloSapatos;
        

        public WindowSapato()
        {
            InitializeComponent();
            this.ModeloSapatos = ctx.ModeloSapatos.ToList();

            if (ModoCriacaoSapato == false)
            {
                this.SapatoSelecionado = this.ModeloSapatos.FirstOrDefault();
            }
            this.DataContext = this;

        }


        // --- classes
       


       
        public ModeloSapato SapatoSelecionado
        {
            get => _SapatoSelecionado;
            set
            {
                _SapatoSelecionado = value;
                this.NotifyPropertyChanged("SapatoSelecionado");
            }

        }

       


        public Boolean ModoCriacaoSapato { get; set; } = false;



        public Visibility VisibilidadeDataGrid
        {
            get
            {
                if (ModoCriacaoSapato)
                {
                    return Visibility.Hidden;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }

      

        public ICollection<ModeloSapato> ModeloSapatos
        {
            get { return _ModeloSapatos; }
            set
            {
                _ModeloSapatos = value;
                this.NotifyPropertyChanged("ModeloSapatos");
            }
        }

        public ICollection<ModeloSapato> ObterSapatos()
        {
            return ctx.ModeloSapatos.ToList();
        }

        



        // ---- Botões -----

        private void SalvarButton_Click(object sender, RoutedEventArgs e)
        {
              if (ModoCriacaoSapato == true)

                {
                
                if(this.SapatoSelecionado.Id <= 0)
                {
                    ctx.ModeloSapatos.Add(SapatoSelecionado);
                    MessageBox.Show("Novo Sapato salvo com Sucesso!");

              }

            }
                ctx.SaveChanges();
                MessageBox.Show("Salvo com Sucesso!");           

        }


        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
        private void SapatosDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // foreach (ModeloSapato item in e.RemovedItems)
            //{
              //  ctx.ModeloSapatos.Remove(item);
           // }
        }

        
    }
}
