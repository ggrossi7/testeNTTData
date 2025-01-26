using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUser;

public class ListUserCommand : IRequest<ListUserResult>
{
    public int Page { get; set; }
    
    public int Size { get; set; }
    
    public ListUserCommand(int page, int size)
    {
        Page = page;
        Size = size;
    }
}