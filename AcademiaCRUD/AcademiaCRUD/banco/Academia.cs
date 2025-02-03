using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademiaCRUD.banco
{
    internal class Academia
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Ende { get; set; }
        public string Fone { get; set; }
        public int Idade { get; set; }
        public string modalidade { get; set; }
    }
}
