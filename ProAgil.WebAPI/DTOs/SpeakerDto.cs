using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.WebAPI.DTOs
{
    public class SpeakerDto
    {
        public int Id { get; set; }

        [Required (ErrorMessage="O campo {0} é obrigatório")]
        [Range (3, 50, ErrorMessage = "Nome deve ter entre 3 e 50 caracteres")]
        public string Name { get; set; }
        
        [Required (ErrorMessage="O campo {0} é obrigatório")]
        public string MiniCurriculum { get; set; }
        public string ImageUrl { get; set; }
        [Required (ErrorMessage="O campo {0} é obrigatório")]
        [Phone (ErrorMessage="Formato de telefone inválido")]
        public string Phone { get; set; }

        [Required (ErrorMessage="O campo {0} é obrigatório")]
        [EmailAddress (ErrorMessage = "Formato de email inválido")]
        public string Email { get; set; }

        public List<SocialNetworkDto> SocialNetwork { get; set; }
        public List<EventDto> Events { get; set; }
    }
}