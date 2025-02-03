﻿using AcademiaCRUD.banco;
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
    public partial class inicial : ContentPage
    {
        public inicial()
        {
            InitializeComponent();
            btn_enviar.Clicked += cadastrar;



        }

        public void cadastrar(object sender, EventArgs args)
        {

            string nome = txt_nome.Text;
            string ende = txt_ende.Text;
            string fone = txt_fone.Text;
            string idade = txt_idade.Text;
            string modalidade = picker_modalidade.SelectedIndex != -1 ? picker_modalidade.Items[picker_modalidade.SelectedIndex] : null;

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(ende) || string.IsNullOrEmpty(fone) || string.IsNullOrEmpty(idade) || modalidade == null)
            {
                DisplayAlert("Erro", "Por favor, preencha todos os campos!", "OK");
                return;
            }


            Banco_funcoes dbf = new Banco_funcoes();
            dbf.CriarBancoDeDados();
            dbf.InserirAluno(modalidade, nome, ende, fone, idade);
            DisplayAlert("Mensagem", "Registro gravado com Sucesso!", "OK");
        }
    }
}