using AutoMapper;
using RegistroDeContatos.Data;
using RegistroDeContatos.Data.Dtos;
using RegistroDeContatos.Models;

namespace RegistroDeContatos.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private ContatoContext _context;
        private IMapper _map;

        public ContatoRepository(ContatoContext context, IMapper map)
        {
            _context = context;
            _map = map;
        }

        public void CreateContato(CreateContatoDto contatoDto)
        {
            var contato = _map.Map<Contato>(contatoDto);
            _context.Contatos.Add(contato);
            _context.SaveChanges();
        }

        public IEnumerable<ReadContatoDto> FindAll()
        {
           return _map.Map<List<ReadContatoDto>>(_context.Contatos.ToList());
        }

        public  ReadContatoDto FindById(int? id)
        {
            return  _map.Map<ReadContatoDto>(_context.Contatos.FirstOrDefault(c => c.Id == id));
        }

        public void EditContato(ReadContatoDto contatoDto)
        {
            var contatoDb = _context.Contatos.FirstOrDefault(c => c.Id == contatoDto.Id);
            if(contatoDb == null)
            {
                throw new Exception("Contato não encontrado");
            }
            _map.Map(contatoDto,contatoDb);
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            var contatoDb = _context.Contatos.FirstOrDefault(c => c.Id == id);
            if(contatoDb == null)
            {
                throw new Exception();
            }
            _context.Contatos.Remove(contatoDb);
            _context.SaveChanges();
        }
    }
}
