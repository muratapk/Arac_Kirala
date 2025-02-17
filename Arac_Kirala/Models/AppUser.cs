﻿using Microsoft.AspNetCore.Identity;

namespace Arac_Kirala.Models
{
    public class AppUser:IdentityUser<int>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; }=string.Empty;
        public string City { get; set; } = string.Empty;    
        public int ConfirmCode { get; set; }

    }
}
