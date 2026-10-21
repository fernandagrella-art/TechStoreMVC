using System.ComponentModel.DataAnnotations;

namespace TechStoreMVC.Models;

public class Produto
{
    // Passo 01 - criar as models
    // atributos
    public int Id {get; set;} //Get para obter um id = identificador
                            // Set para definir um novo valor, atualizar e 
    [Required(ErrorMessage = "Informe um nome")]
    [StringLength(
        100,
        MinimumLength =3,
        ErrorMessage = "O nome deve possuir entre 3 e 100 caracteres"
    )]
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
