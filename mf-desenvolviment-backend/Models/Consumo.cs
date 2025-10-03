using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mf_desenvolviment_backend.Models
{
    [Table("Consumos")]
    public class Consumo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Obrigatório informar a descrição")]
        [Display(Name ="Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a data")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o valor")]
        public decimal Valor { get; set; }


        [Required(ErrorMessage = "Obrigatório informar a quilometragem")]
        public int Km { get; set; }

        [Display(Name = "Tipo de Combustível")]
        public TipoCombustivel Tipo { get; set; }

        [Display(Name = "Veículo")]
        [Required(ErrorMessage = "Obrigatório informar o veiculo")]
        //entidades do Entity Framework (como no seu modelo Consumo), é comum ter dois campos relacionados a uma associação (relacionamento) com outra tabela:
	     //VeiculoId:
        //a chave estrangeira(foreign key) que armazena o identificador do veículo relacionado.Ele é do tipo int porque corresponde ao campo Id da tabela Veiculos.
	    //Veiculo:
         // É a propriedade de navegação(navigation property). Ela permite acessar diretamente o objeto Veiculo relacionado, facilitando o acesso aos dados do veículo associado ao consumo.
        public int VeiculoId { get; set; }

        [ForeignKey("VeiculoId")]
        public Veiculo Veiculo { get; set; }
    }
    public enum TipoCombustivel
    {
        Gasolina,
        Alcool,
        Diesel,
        Flex
    }
}
