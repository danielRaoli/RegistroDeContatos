using AutoMapper;
using RegistroDeContatos.Data.Dtos;
using RegistroDeContatos.Models;

namespace RegistroDeContatos.Profiles
{
    public class ContatoProfile : Profile
    {
        public ContatoProfile()
        {
            CreateMap<CreateContatoDto, Contato>();
            CreateMap<ReadContatoDto, Contato>();
            CreateMap< Contato, ReadContatoDto>();
        }
    }
}
