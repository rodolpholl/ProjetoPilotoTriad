using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ProjetoPiloto.Cadastro.Application.Contracts.Persistance;
using ProjetoPiloto.Cadastro.Application.Models;

namespace ProjetoPiloto.Cadastro.Application.Features.Author.Query.ListAuthor
{
    public class ListAuthorQueryHandler : IRequestHandler<ListAuthorQuery, List<AuthorModel>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ListAuthorQueryHandler> _logger;
        private readonly IAuthorRepository _repository;

        public ListAuthorQueryHandler(IMapper mapper, ILogger<ListAuthorQueryHandler> logger, IAuthorRepository repository)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }

        public async Task<List<AuthorModel>> Handle(ListAuthorQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var listAuthors = await _repository.ListAuthor(request.Index - 1, request.Count);
                var result = _mapper.Map<List<AuthorModel>>(listAuthors);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurrs while attempt to find Authors:\n{0}", ex.Message);
                throw;
            }
        }
    }
}
