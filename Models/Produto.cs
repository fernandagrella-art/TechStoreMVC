namespace TechStoreMVC.Models;

public class Produto
{
    // Passo 01 - criar as models
    // atributos
    public int Id {get; set;} //Get para obter um id = identificador
                            // Set para definir um novo valor, atualizar e 
    public string Nome {get; set;}
    public decimal Preco {get; set;}
    public int Estoque {get; set;}

    //Método construtor - Define valores iniciais desses atributos acima!
    public Produto (
        int id,
        string nome, 
        decimal preco, 
        int estoque
    )
    {
        Id = id;
        Nome = nome;
        Preco = preco;
        Estoque = estoque;
    }
}
