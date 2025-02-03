using AcademiaCRUD.banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AcademiaCRUD.paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class lista : ContentPage
    {
        public lista()
        {
            InitializeComponent();
            btn_recarregar.Clicked += listar;
        }
        public void listar(object sender, EventArgs args)
        {
            Banco_funcoes dbf = new Banco_funcoes();
            dbf.CriarBancoDeDados();
            List<Academia> listaAlunos = new List<Academia>();
            listaAlunos = dbf.GetAlunos();

            if (listaAlunos == null || listaAlunos.Count == 0)
            {
                DisplayAlert("Atenção", "Nenhum aluno encontrado", "OK");
                return;
            }

            var array = listaAlunos.ToArray();
            List<Academia> lista = new List<Academia>();
            for (int c = 0; c < array.Length; c++)
            {
                lista.Add(new Academia
                {   Id = array[c].Id,
                    Nome = array[c].Nome.ToString(),
                    Ende = array[c].Ende.ToString(),
                    Fone = array[c].Fone.ToString(),
                    Idade = array[c].Idade,
                    modalidade = array[c].modalidade,
                });
            }
            ls_alunos.ItemsSource = lista;
        }
    }
}