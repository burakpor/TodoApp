﻿namespace TodoApp.Models.BusinessModels
{
    public class RegisterUserRequest: RequestBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
