﻿namespace Arac_Kirala.DataO
{
    public class DtoUserView
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty; 
        public string Email {  get; set; } = string.Empty;   
        public string Password { get; set; } = string.Empty;
        public int? ConfirmCode { get; set; }

    }
}