using RegistroDeContatos.Data.Dtos;

namespace RegistroDeContatos.Repository
{
    public interface IContatoRepository
    {
        void CreateContato(CreateContatoDto contatoDto);
        void EditContato(ReadContatoDto contatoDto);
        IEnumerable<ReadContatoDto> FindAll();
        ReadContatoDto FindById(int? id);

        void Delete(int id);
    }
}
