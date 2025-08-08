namespace AppTarefas.Models
{
    public class Tarefa
    {
        //Nome da chave primária deve ser da classe + "Id"
        public int TarefasId { get; set; } //Id é a chave primária
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public bool Concluida { get; set; }

    }
}
