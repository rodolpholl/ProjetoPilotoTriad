using AutoMapper;
using ProjetoPiloto.Cadastro.API.Models;
using ProjetoPiloto.Cadastro.Application.Features.Author.Command.AddAuthor;
using ProjetoPiloto.Cadastro.Application.Features.Author.Command.UpdateAuthor;
using ProjetoPiloto.Cadastro.Application.Models;

namespace ProjetoPiloto.Cadastro.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthorDTO, AddAuthorCommand>().ReverseMap();
            CreateMap<AuthorDTO, UpdateAuthorCommand>().ReverseMap();
            CreateMap<AuthorDTO, AuthorModel>().ReverseMap();
        }
    }
}
