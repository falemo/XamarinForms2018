using System;
using System.Collections.Generic;
using System.Text;

namespace App2_Tarefa.Modelos
{
    public class Tarefa
    {
        public string Nome { get; set; }
        public DateTime? Datafinalizado { get; set; }
        public byte Prioridade { get; set; }

        public Tarefa()
        {
            Nome = "";
            Datafinalizado = null;
            Prioridade = 0;

        }

    }
}
