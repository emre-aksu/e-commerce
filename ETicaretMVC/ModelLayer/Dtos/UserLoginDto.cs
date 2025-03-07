﻿using Infrastructure.Model;

namespace ModelLayer.Dtos
{
    public class UserLoginDto : IDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
