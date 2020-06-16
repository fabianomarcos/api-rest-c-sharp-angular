using System.ComponentModel.DataAnnotations;

namespace ProAgil.WebAPI.DTOs
{
    public class LotDto
    {
        public int Id { get; set; }

        [Required (ErrorMessage="O campo {0} é obrigatório")]
        [Range (3, 50, ErrorMessage = "Nome deve ter entre 3 e 50 caracteres")]
        public string Name { get; set; }

        [Required (ErrorMessage="O campo {0} é obrigatório")]
        public decimal price { get; set; }

        [Required (ErrorMessage="O campo {0} é obrigatório")]
        public string InitialDate { get; set; }

        [Required (ErrorMessage="O campo {0} é obrigatório")]
        public string FinalDate { get; set; }

        [Required (ErrorMessage="O campo {0} é obrigatório")]
        public int amount { get; set; }
    }
}