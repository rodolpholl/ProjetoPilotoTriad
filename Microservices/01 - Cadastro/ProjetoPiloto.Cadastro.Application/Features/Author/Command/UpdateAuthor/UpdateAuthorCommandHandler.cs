using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ProjetoPiloto.Cadastro.Application.Contracts.Persistance;
using ProjetoPiloto.Utils.Exceptions;

namespace ProjetoPiloto.Cadastro.Application.Features.Author.Command.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, long>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateAuthorCommandHandler> _logger;
        private readonly IAuthorRepository _repository;

        public UpdateAuthorCommandHandler(IMapper mapper, ILogger<UpdateAuthorCommandHandler> logger, IAuthorRepository repository)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }

        public async Task<long> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var updateAuthor = _repository.Collection.FirstOrDefault(x => x.Id.Equals(request.Id));
                if (updateAuthor == null)
                    throw new EntityNotFoundException("Author", request.Id);


                var newAuthor = _mapper.Map<Domain.Entities.Author>(request);
                var result = await _repository.UpdateAuthor(newAuthor);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error ocurred while Update the Author {0} {1}:\n{2}", request.FirstName, request.LastName, ex.Message);
                throw;
            }
        }
    }

}
