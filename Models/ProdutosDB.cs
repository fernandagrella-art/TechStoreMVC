namespace TechStoreMVC.Models;

public class ProdutosDB
{
    //Passo 01- Criar os dados de produtos/trazer do Controller
    //Método que vai listar novos objetos de um produto
    //e armazená-los na variável
    private static readonly List<Produto> produtos = new()
    {
        new Produto(1, "Mouse Gamer", 129.9m, 10),  
        new Produto(1, "Teclado Mecanico", 249.9m, 5),  
        new Produto(3, "Monitor 24 polegadas", 899.9m, 8),  
        new Produto(4, "Headset Gamer", 129.9m, 10)
    };

    //Passo 02- Criar métodos do Crud e remover regra d negocio do controller
    //Responsabilidade do Listar: Devolver/mostrar os produtos. Igual ao Index
    //Controller

    public List<Produto> Listar()
    {
        return produtos;
    }

    public Produto? buscarPorId(int id)
    {
        return produtos.FirstOrDefault(
            produto => produto.Id == id
        );
    }
    public void Adicionar(Produto produto)
    {
        produto.Id = produtos.Count + 1;
        produtos.Add(produto);
    }

    public bool Atualizar(Produto produtoAtualizado)
    {
        return true;
    }

    public bool Excluir(int id)
    {
        Produto? produto = buscarPorId(id);
        if(produto is null)
        return false;
        produtos.Remove(produto);

        return true;
    }
}