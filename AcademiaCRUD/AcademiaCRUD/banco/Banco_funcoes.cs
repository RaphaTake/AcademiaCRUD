using SQLite;
using System;
using System.Collections.Generic;

namespace AcademiaCRUD.banco
{
    class Banco_funcoes
    {
        private SQLiteConnection conexao;
        string pasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        // Método para criar o banco de dados
        public void CriarBancoDeDados()
        {
            string dbPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Academia.db3");
            conexao = new SQLiteConnection(dbPath);
            conexao.CreateTable<Academia>();
        }

        // Método para inserir um aluno no banco de dados
        public void InserirAluno(string modalidade, string nome, string ende, string fone, string idade)
        {
            // Usando parâmetros para evitar SQL Injection
            conexao.Execute("INSERT INTO academia (Modalidade, Nome, Ende, Fone, Idade) VALUES (?, ?, ?, ?, ?)",
                            modalidade, nome, ende, fone, idade);
        }

        // Método para obter todos os alunos
        public List<Academia> GetAlunos()
        {
            return conexao.Query<Academia>("SELECT * FROM academia");
        }

        // Método para excluir um aluno pelo ID
        public void ExcluirAluno(string id)
        {
            conexao.Execute("DELETE FROM academia WHERE Id = ?", id);
        }

        // Método para editar um aluno pelo ID
        public void EditarAluno(string id, string modalidade, string nome, string ende, string fone, string idade)
        {
            conexao.Execute("UPDATE academia SET Modalidade = ?, Nome = ?, Ende = ?, Fone = ?, Idade = ? WHERE Id = ?",
                            modalidade, nome, ende, fone, idade, id);
        }

        // Método para pesquisar alunos pelo nome
        public List<Academia> PesquisarAlunos(string query)
        {
            return conexao.Query<Academia>("SELECT * FROM academia WHERE id LIKE ?", "%" + query.Trim() + "%");
        }
    }
}
