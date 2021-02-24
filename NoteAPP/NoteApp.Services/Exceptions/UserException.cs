using System;
using System.Collections.Generic;
using System.Text;

namespace NoteApp.Services.Exceptions
{
    public class UserException : Exception
    {
        public int? UserId { get; set; }
        public string Name { get; set; }

        public UserException() : base("There was a problem with the user.")
        {

        }

        public UserException(int? userId, string name) :  base("There was a problem with the user")
        {
            UserId = userId;
            Name = name;
        }

        public UserException(int? userId, string name, string message) : base(message) 
        {
            UserId = userId;
            Name = name;
        }


    }
}
