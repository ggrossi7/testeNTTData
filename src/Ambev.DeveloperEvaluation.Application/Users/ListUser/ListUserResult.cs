﻿using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUser;

public class ListUserResult
{
    public List<UserResult> users { get; set; } = new List<UserResult>();

    public class UserResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;   
  
        public UserRole Role { get; set; }
        public UserStatus Status { get; set; }
    }
    
}