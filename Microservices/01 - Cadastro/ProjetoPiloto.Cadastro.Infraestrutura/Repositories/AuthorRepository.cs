using NHibernate;
using NHibernate.Linq;
using ProjetoPiloto.Cadastro.Application.Contracts.Persistance;
using ProjetoPiloto.Cadastro.Domain.Entities;
using ProjetoPiloto.Shared.Repository;

namespace ProjetoPiloto.Cadastro.Infraestrutura.Repositories
{
    public class AuthorRepository : RepositoryBaseNHibernate<Author>, IAuthorRepository
    {
        public AuthorRepository(ISession session) : base(session) { }

        public async Task<long> AddAuthor(Author author)
        {
            await Add(author);
            return author.Id;
        }

        public async Task<Author> GetAuthorById(long idAuthor)
        {
            var result = await Collection.FirstOrDefaultAsync(x => x.Id.Equals(idAuthor));
            return result;
        }

        public async Task<IList<Author>> ListAuthor(int index, int count)
        {
            var result = await Collection.Skip(index).Take(count).ToListAsync();
            return result;
        }

        public async Task<long> UpdateAuthor(Author author)
        {
            await Update(author);
            return author.Id;
        }
    }
}
