using System;
using System.Collections.Generic;
using System.Text;

namespace NoteApp.Services.Exceptions
{
    public class NoteException : Exception
    {
        public int? NoteId { get; set; }
        public int UserId { get; set; }

        public NoteException() : base("There was a problem with a note.")
        {

        }


        public NoteException(int? noteId, int userId) : base("There was a problem with a note")
        {
            NoteId = noteId;
            UserId = userId;
        }

        public NoteException(int? noteId, int userId, string message) :base(message)
        {
            NoteId = NoteId;
            UserId = userId;
        }
    }
}
