using System.ComponentModel.DataAnnotations;

namespace RegistroDeContatos.Data.Dtos
{
    public class ReadContatoDto
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
