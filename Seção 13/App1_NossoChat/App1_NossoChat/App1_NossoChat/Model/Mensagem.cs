using System;
using System.Collections.Generic;
using System.Text;

namespace App1_NossoChat.Model
{
    public class Mensagem
    {
        public int Id { get; set; }
        public int IdChat { get; set; }
        public int Idusuario { get; set; }
        public string mensagem { get; set; }
        public Usuario Usuario { get; set; }
    }
}
