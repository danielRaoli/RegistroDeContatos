using System.ComponentModel.DataAnnotations;

namespace RegistroDeContatos.Data.Dtos
{
    public class CreateContatoDto
    {
        [Required(ErrorMessage ="O nome é obrigatório")]
        public string Name { get; set; }
        
        [Required(ErrorMessage ="Email obrigatório")]
        public string Email { get; set; }


        [Required(ErrorMessage ="Telefone obrigatório")]
        public string PhoneNumber { get; set; }
    }
}
