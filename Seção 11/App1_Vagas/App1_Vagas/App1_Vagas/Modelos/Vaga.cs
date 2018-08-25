﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1_Vagas.Modelos
{
    [Table("Vaga")]
    public class Vaga
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } 
        public string Cargo { get; set; }
        public string Empresa { get; set; }
        public short Quantidade { get; set; }
        public string Cidade { get; set; }
        public double Salario { get; set; }
        public string Descricao { get; set; }
        public string Tipocontracao { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

    }
}
