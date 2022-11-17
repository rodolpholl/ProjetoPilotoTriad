using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ProjetoPiloto.Cadastro.Application.Contracts.Persistance;

namespace ProjetoPiloto.Cadastro.Application.Features.Author.Command.AddAuthor
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, long>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AddAuthorCommandHandler> _logger;
        private readonly IAuthorRepository _repository;

        public AddAuthorCommandHandler(IMapper mapper, ILogger<AddAuthorCommandHandler> logger, IAuthorRepository authorRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = authorRepository ?? throw new ArgumentNullException(nameof(authorRepository));
        }

        public async Task<long> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newAuthor = _mapper.Map<Domain.Entities.Author>(request);
                var result = await _repository.AddAuthor(newAuthor);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error ocurred while Creating an Author:\n{0}", ex.Message);
                throw;
            }
        }
    }
}
