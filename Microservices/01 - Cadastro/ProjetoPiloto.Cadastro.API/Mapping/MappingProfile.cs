using AutoMapper;
using ProjetoPiloto.Cadastro.Application.Features.Author.Command.AddAuthor;
using ProjetoPiloto.Cadastro.Application.Features.Author.Command.UpdateAuthor;
using ProjetoPiloto.Cadastro.Application.Models;

namespace ProjetoPiloto.Cadastro.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthorModel, AddAuthorCommand>().ReverseMap();
            CreateMap<AuthorModel, UpdateAuthorCommand>().ReverseMap();
            CreateMap<Modules.Cadastro.Models.AuthorModel, Application.Models.AuthorModel>().ReverseMap();
        }
    }
}
