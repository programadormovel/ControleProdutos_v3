using ControleProdutos.Models;

namespace ControleProdutos.Repositorio
{
    public interface IProdutoRepositorio
    {
        List<ProdutoModel> BuscarTodos();
        ProdutoModel Adicionar(ProdutoModel produto);
        ProdutoModel ListarPorId(long id);
        ProdutoModel Atualizar(ProdutoModel produto);
        bool Apagar(int id);

    }
}
