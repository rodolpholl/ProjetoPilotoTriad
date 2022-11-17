using ProjetoPiloto.Cadastro.Domain.Entities;
using ProjetoPiloto.Shared.Repository.Interfaces;

namespace ProjetoPiloto.Cadastro.Application.Contracts.Persistance
{
    public interface IAuthorRepository : IRepositoryBase<Author>
    {
        Task<long> AddAuthor(Author author);
        Task<long> UpdateAuthor(Author author);
        Task<Author> GetAuthorById(long idAuthor);
        Task<IList<Author>> ListAuthor(int index, int count);
    }
}
