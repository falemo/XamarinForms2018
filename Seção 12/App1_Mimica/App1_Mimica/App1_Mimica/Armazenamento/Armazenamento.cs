using System;
using System.Collections.Generic;
using System.Text;
using App1_Mimica.Model;

namespace App1_Mimica.Armazenamento
{
    public class Armazenamento
    {
        public static Jogo Jogo { get; set; }
        public static short RodadaAtual { get; set; }

        public static string[][] Palavras = {
            //Fac
            new string[] {"Olho", "Lingua", "Chinelo","Milho", "Penalty", "Ping Pong", "Bola"},
            //Med
            new string[] {"Carpinteiro", "Limão", "Amarelo","Abelha"},
            //Dificil
            new string[] {"Ciesterna", "Lampada", "Laterna","Batman vs SuperMan", "Paralelepipedo", "Notebook"},
        };
    }
}
