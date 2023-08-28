using ControleProdutos.Models;
using ControleProdutos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.IO;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ControleProdutos.Controllers
{
    public class ProdutoController : Controller
    {
        private IHostingEnvironment Environment;

        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoController(IProdutoRepositorio produtoRepositorio, 
            IHostingEnvironment _environment)
        {
            _produtoRepositorio = produtoRepositorio;
            Environment = _environment;
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
        public IActionResult Criar(ProdutoModel produto, IFormFile? imagemCarregada)
        {
            ProdutoModel model = produto;

            // validações 
            List<ValidationResult> results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(model, null, null);

            bool isValid = Validator.TryValidateObject( model, context, results, true);

            if (!isValid)
            {
                return View(model);
            }
            model.DataDeRegistro = DateTime.Now;

            // Carregamento de imagem
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;
            string path = Path.Combine(wwwPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileName = Path.GetFileName(imagemCarregada!.FileName);
            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                imagemCarregada.CopyTo(stream);
                model.NomeDaFoto = fileName;
            }

            model.Foto = Util.ReadFully2(Path.Combine(path, fileName));

            _produtoRepositorio.Adicionar(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(ProdutoModel produto)
        {
            ProdutoModel model = produto;
            model.DataDeRegistro = produto.DataDeRegistro;
            model.Descricao.Replace("-", "");

            _produtoRepositorio.Atualizar(model);
            return RedirectToAction("Index");
        }



        [Route("/Produto/CarregarImagem")]
        public IActionResult CarregarImagem(string rota)
        {

            return View();
        }

    }
}
