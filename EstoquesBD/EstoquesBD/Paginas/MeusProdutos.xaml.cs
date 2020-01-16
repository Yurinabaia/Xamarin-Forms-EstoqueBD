using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstoquesBD.Modelos;
using EstoquesBD.Banco;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EstoquesBD.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeusProdutos : ContentPage
    {
        List<Produtos> listando { get; set; }

        public MeusProdutos()
        {
            InitializeComponent();
            ConsultaProduto();
        }
        private void ConsultaProduto()
        {
            AcessandoBancoDeDados banco = new AcessandoBancoDeDados();
            listando = banco.Consultar();
            LISTAPRODUTO.ItemsSource = listando;
            LBLproduto.Text = "Quantidade de vagas " + listando.Count.ToString();
        }
        public void EditarProduto(object sender, EventArgs args) //Todo botão possuir um object sender, EventArgs args
        {
            Label lblEditar = (Label)sender;
            TapGestureRecognizer tapgest = (TapGestureRecognizer)lblEditar.GestureRecognizers[0];//Aqui estamos pegando o toque na label
            Produtos POD = tapgest.CommandParameter as Produtos;//Aqui estamos pegando a propriedade dela que e uma Vagas e colocando para ser um botão
            Navigation.PushAsync(new EditarProduto(POD));//Aqui estamos fazendo a ação do GestureRecognizer
        }
        public void ExcluirProduto(object sender, EventArgs args) //Todo botão possuir um object sender, EventArgs args
        {
            Label lblExcluir = (Label)sender;
            TapGestureRecognizer tapgest = (TapGestureRecognizer)lblExcluir.GestureRecognizers[0];//Aqui estamos pegando o toque na label
            Produtos POD = tapgest.CommandParameter as Produtos;//Aqui estamos pegando a propriedade dela que e uma Vagas e colocando para ser um botão
            AcessandoBancoDeDados banco = new AcessandoBancoDeDados();
            banco.Exclusao(POD);
            ConsultaProduto();
        }
        public void IrPaginaInicial(object sender, EventArgs args) //Todo botão possuir um object sender, EventArgs args
        {
            Navigation.PopAsync();//Para de poder voltar as paginas
            Navigation.PushAsync(new PaginaInicial());//Vai para pagina incial
        }
        public void FiltrarProduto(object sender, TextChangedEventArgs args) //Todo TextChanged="FiltraVaga"  
                                                                         //possuir um object sender, TextChangedEventArgs args;
        {
            LISTAPRODUTO.ItemsSource = listando.Where(x => x.NomeProduto.Contains(args.NewTextValue)).ToList();
        }
    }
}