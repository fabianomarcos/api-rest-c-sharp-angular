using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ProAgil.WebAPI.DTOs
{
    public class EventDto
    {
        public int Id { get; set; }

        [Required (ErrorMessage="O campo {0} é obrigatório")]
        public string Locale { get; set; }

        [Required (ErrorMessage="O campo {0} é obrigatório")]
        public string DateEvent { get; set; }

        [Required (ErrorMessage="O campo {0} é obrigatório")]
        public string Theme { get; set; }

        [Range(20, 1200, ErrorMessage="Quantidade de pessoas deve ser entre 20 e 1200 pessoas.")]
        [Required (ErrorMessage="O campo {0} é obrigatório")]
        public int amountPeople { get; set; }

        [Required (ErrorMessage="O campo {0} é obrigatório")]
        public string ImageUrl { get; set; }

        [Required (ErrorMessage="O campo {0} é obrigatório")]
        [Phone (ErrorMessage="Formato de telefone inválido")]
        public string Phone { get; set; }

        [Required (ErrorMessage="O campo {0} é obrigatório")]
        [EmailAddress (ErrorMessage="Formato de email inválido.")]
        public string Email { get; set; }

        public List<LotDto> Lots { get; set; }
        public List<SocialNetworkDto> SocialNetworks { get; set; }
        public List<SpeakerDto> Speakers { get; set; }
    }
}