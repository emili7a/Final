﻿namespace Final_Project.ViewModels.ContactViewModels
{
    public class ContactCreateVM
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
            public string? Subject { get; set; }
        public string Message { get; set; } = null!;
        

    }
}
