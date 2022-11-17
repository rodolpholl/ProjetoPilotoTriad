using AutoMapper;
using ProjetoPiloto.Cadastro.Application.Features.Author.Command.AddAuthor;
using ProjetoPiloto.Cadastro.Application.Features.Author.Command.UpdateAuthor;
using ProjetoPiloto.Cadastro.Application.Models;
using ProjetoPiloto.Cadastro.Domain.Entities;

namespace ProjetoPiloto.Cadastro.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Author
            CreateMap<Author, AddAuthorCommand>().ReverseMap();
            CreateMap<Author, UpdateAuthorCommand>().ReverseMap();
            CreateMap<Author, AuthorModel>().ReverseMap();
        }
    }
}
