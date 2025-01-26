using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUser;

public class ListUserProfile : Profile
{
    public ListUserProfile()
    {
        CreateMap<List<User>, ListUserResult>()
            .ConvertUsing(src => new ListUserResult
            {
                users = src.Select(user => new ListUserResult.UserResult
                {
                    Id = user.Id,
                    Name = user.Username,
                    Email = user.Email,
                    Phone = user.Phone,
                    Role = user.Role,
                    Status = user.Status
                }).ToList()
            });
    }
}