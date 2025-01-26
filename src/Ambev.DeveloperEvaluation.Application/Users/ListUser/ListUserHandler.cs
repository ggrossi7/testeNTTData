using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUser;

public class ListUserHandler: IRequestHandler<ListUserCommand, ListUserResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private IRequestHandler<ListUserCommand, ListUserResult> _requestHandlerImplementation;

    public ListUserHandler(
        IUserRepository userRepository,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    

    public async Task<ListUserResult> Handle(ListUserCommand request, CancellationToken cancellationToken)
    {
        
        var users = await _userRepository.GetAll(request.Page, request.Size, cancellationToken);

        if (!users.Any())
        {
            return new ListUserResult();
        }
        
        var result = _mapper.Map<ListUserResult>(users);

        return result;
    }
}