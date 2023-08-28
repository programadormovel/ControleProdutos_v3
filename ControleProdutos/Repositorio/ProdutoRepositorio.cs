using ControleProdutos.Data;
using ControleProdutos.Models;
using Microsoft.IdentityModel.Tokens;

namespace ControleProdutos.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ProdutoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<ProdutoModel> BuscarTodos()
        {
            return _bancoContext.Produtos.ToList();
        }

        public ProdutoModel Adicionar(ProdutoModel produto)
        {
            // Validações
            if(produto.CodigoDeBarras.IsNullOrEmpty()) {
                Console.WriteLine("Codigo de barras requerido");
                return null;
            }

            _bancoContext.Produtos.Add(produto);
            _bancoContext.SaveChanges();

            return produto;
        }

        public ProdutoModel ListarPorId(long id)
        {
            ProdutoModel produtoDB = _bancoContext.Produtos.FirstOrDefault(x => x.Id == id);
            
            if (produtoDB == null) throw new System.Exception("Houve um erro na busca do produto");
            
            return produtoDB;
        }

        public ProdutoModel Atualizar(ProdutoModel produto)
        {
            ProdutoModel produtoDB = ListarPorId(produto.Id);

            if (produtoDB == null) throw new System.Exception("Houve um erro na atualização do produto");

            produtoDB.Descricao = produto.Descricao;
            produtoDB.CodigoDeBarras = produto.CodigoDeBarras;
            produtoDB.DataDeValidade = produto.DataDeValidade;
            //produtoDB.DataDeRegistro = produto.DataDeRegistro;
            produtoDB.Valor = produto.Valor;
            produtoDB.NomeDaFoto = produto.NomeDaFoto;
            produtoDB.Foto = produto.Foto;
            produtoDB.Ativo = produto.Ativo;

            _bancoContext.Produtos.Update(produtoDB);
            _bancoContext.SaveChanges();

            return produtoDB;
        }

        public bool Apagar(int id)
        {
            ProdutoModel produtoDB = ListarPorId(id);

            if (produtoDB == null) throw new System.Exception("Houve um erro na exclusão do produto");

            _bancoContext.Produtos.Remove(produtoDB);
            _bancoContext.SaveChanges();

            return true;
        }

    }

}
