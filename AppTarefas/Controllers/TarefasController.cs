using System.Net.NetworkInformation;
using AppTarefas.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppTarefas.Controllers
{
    public class TarefasController : Controller
    {
        //Lista em memória(grava as informações apenas quando a aplicação está rodando)

        private static List<Tarefa> _tarefas = new List<Tarefa>();
        private static int _proximoID = 1;

        //GET: Tarefas 

        public IActionResult Index()
        {
            return View(_tarefas); //Envia a lista de tarefas como parametro para a pagina Index.
        }

        //GET: Tarefas/Create
        //Get -> Metodo para "pegar" a página e exibir
        public IActionResult Create()
        {
            return View();
        }

        //POST: Tarefas/Create
        [HttpPost] //Especifica que este método responde a requisições POST
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                tarefa.TarefasId = _proximoID++; //Atribui o próximo ID à tarefa
                _tarefas.Add(tarefa);
                return RedirectToAction("Index"); //Redireciona para a página de listagem de tarefas
            }
            return View(tarefa); //Retorna a view com o objeto tarefa preenchido
        }

        //GET: Tarefas/Edit/1
        public IActionResult Edit(int id)
        {
            //var tarefa = _tarefas[id]; //Trabalhando com lista
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefasId == id);
            return View(tarefa);

        }

        //POST: Tarefas/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Tarefa tarefaAtualizada)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefasId == id);

            tarefa.Titulo = tarefaAtualizada.Titulo;
            tarefa.Descricao = tarefaAtualizada.Descricao;
            tarefa.Concluida = tarefaAtualizada.Concluida;

            return RedirectToAction("Index");

        }
        //GET: Tarefas/Edit/1
        public IActionResult Details(int id)
        {
            //var tarefa = _tarefas[id]; //Trabalhando com lista
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefasId == id);
            return View(tarefa);


        }
        //GET: Tarefas/Edit/1
        public IActionResult Delete(int id)
        {
            //var tarefa = _tarefas[id]; //Trabalhando com lista
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefasId == id);
            return View(tarefa);

        }
        //Post: Tarefas/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteConfirmed(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefasId == id);
            if (tarefa != null)
            {
                _tarefas.Remove(tarefa); //Remove a tarefa da lista
            }
            return RedirectToAction("Index");


        }
    }
}
