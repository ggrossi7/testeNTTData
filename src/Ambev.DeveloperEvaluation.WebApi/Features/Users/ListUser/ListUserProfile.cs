using Ambev.DeveloperEvaluation.Application.Users.ListUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.ListUsers;
using AutoMapper;

public class ListUserProfile : Profile
{
    public ListUserProfile()
    {
        
        CreateMap<ListUserRequest, ListUserCommand>();
        
        CreateMap<ListUserResult, ListUserResponse>()
            .ConvertUsing(src => new ListUserResponse
            {
                users = src.users.Select(user => new ListUserResponse.UserResponse
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Phone = user.Phone,
                    Role = user.Role,
                    Status = user.Status
                }).ToList()
            });
    }
}