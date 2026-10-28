namespace TechStoreMVC.Models;

public class CategoriasDB
{
    //Passo 01- Criar os dados de produtos/trazer do Controller
    //Método que vai listar novos objetos de um produto
    //e armazená-los na variável
    private static readonly List<Categorias> categorias = new()
    {
        new Categorias(1, "Computador Gamer", "Computadores e componentes"),  
        new Categorias(2, "Periféricos", "Mouse, teclado e acessórios"),  
        new Categorias(3, "Eletrônicos", "Não sei oque escrever, bjjs"),  
        new Categorias(4, "Monitores", "Telas e monitores"),
    };

    //Passo 02- Criar métodos do Crud e remover regra d negocio do controller
    //Responsabilidade do Listar: Devolver/mostrar os produtos. Igual ao Index
    //Controller

    public List<Categorias> Listar()
    {
        return categorias;
    }

    public Categorias? buscarPorId(int id)
    {
        return categorias.FirstOrDefault(
            categoria => categoria.Id == id
        );
    }
    public void Adicionar(Categorias categoria)
    {
        categoria.Id = categorias.Count + 1;
        categorias.Add(categoria);
    }

    public bool Atualizar(Categorias produtoAtualizado)
    {
        return true;
    }

    public bool Excluir(int id)
    {
        Categorias? categoria = buscarPorId(id);
        if(categoria is null)
        return false;
        categorias.Remove(categoria);

        return true;
    }
}