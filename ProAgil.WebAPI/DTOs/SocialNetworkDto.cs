using System.ComponentModel.DataAnnotations;

namespace ProAgil.WebAPI.DTOs
{
    public class SocialNetworkDto
    {
        public int Id { get; set; }

        [Required (ErrorMessage="O campo {0} é obrigatório")]
        [Range (3, 50, ErrorMessage = "Nome deve ter entre 3 e 50 caracteres")]
        public string Name { get; set; }

        [Required (ErrorMessage="O campo {0} é obrigatório")]
        [Range (3, 50, ErrorMessage = "Nome deve ter entre 10 e 150 caracteres")]
        public string URL { get; set; }
    }
}