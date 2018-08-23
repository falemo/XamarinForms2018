using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace App2_Tarefa.Modelos
{
    public class GerenciadorTarefas
    {
        private List<Tarefa> Lista { get; set; }

        public void Finalizar(int index, Tarefa tarefa)
        {
            Lista = Listar();
            Lista.RemoveAt(index);
            tarefa.Datafinalizado = DateTime.Now;
            Lista.Add(tarefa);
            SalvarNoProperties(Lista);   
        }
        public void Remover(int index)
        {
            Lista = Listar();
            Lista.RemoveAt(index);
            SalvarNoProperties(Lista);

        }
        public void Salvar(Tarefa tarefa)
        {
            Lista = Listar();
            Lista.Add(tarefa);
            SalvarNoProperties(Lista);
        }
        public List<Tarefa> Listar()
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                string JsonVal = (string)App.Current.Properties["Tarefas"];

                return JsonConvert.DeserializeObject<List<Tarefa>>(JsonVal);//(List<Tarefa>) App.Current.Properties["Tarefas"];
            }
            else
            { return new List<Tarefa>(); }
        }
        public void SalvarNoProperties(List<Tarefa> Lista)
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                App.Current.Properties.Remove("Tarefas");
            }

            //Serializar em String.
            App.Current.Properties.Add("Tarefas", JsonConvert.SerializeObject(Lista));

        }


    }
}
