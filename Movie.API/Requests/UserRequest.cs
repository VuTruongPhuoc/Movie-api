﻿namespace Movie.API.Requests
{
    public class UserRequest
    {
    }
    public class AddUserRequest
    {
        public string UserName { get; set; }
        public string? DisplayName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
