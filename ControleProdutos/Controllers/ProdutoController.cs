using ControleProdutos.Data;
using ControleProdutos.Models;
using ControleProdutos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System.ComponentModel;
using System.Security.Cryptography;

namespace ControleProdutos.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public IActionResult Index()
        {
            List<ProdutoModel> produtos = _produtoRepositorio.BuscarTodos();
            return View(produtos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ProdutoModel produto = _produtoRepositorio.ListarPorId(id);
            return View(produto);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ProdutoModel produto = _produtoRepositorio.ListarPorId(id);
            return View(produto);
        }

        public IActionResult Apagar(int id)
        {
            _produtoRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(ProdutoModel produto)
        {
            ProdutoModel model = produto;
            model.DataDeRegistro = DateTime.Now;
            
            _produtoRepositorio.Adicionar(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(ProdutoModel produto)
        {
            ProdutoModel model = produto;
            model.DataDeRegistro = produto.DataDeRegistro;
            
            _produtoRepositorio.Atualizar(model);
            return RedirectToAction("Index");
        }

    }
}
