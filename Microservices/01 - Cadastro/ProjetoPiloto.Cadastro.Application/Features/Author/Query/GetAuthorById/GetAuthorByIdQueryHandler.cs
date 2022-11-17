using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NHibernate.Linq;
using ProjetoPiloto.Cadastro.Application.Contracts.Persistance;
using ProjetoPiloto.Cadastro.Application.Models;
using ProjetoPiloto.Utils.Exceptions;

namespace ProjetoPiloto.Cadastro.Application.Features.Author.Query.GetAuthorById
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorModel>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetAuthorByIdQueryHandler> _logger;
        private readonly IAuthorRepository _repository;

        public GetAuthorByIdQueryHandler(IMapper mapper, ILogger<GetAuthorByIdQueryHandler> logger, IAuthorRepository repository)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }


        public async Task<AuthorModel> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var author = await _repository.GetAuthorById(request.Id);

                if (author is null)
                    throw new EntityNotFoundException("Author", request.Id);

                var result = _mapper.Map<AuthorModel>(author);
                return result;

            }
            catch (Exception ex)
            {
                _logger.LogError("An Error returns when try retriev an Author:\n{0}", ex.Message);
                throw;
            }
        }
    }
}
