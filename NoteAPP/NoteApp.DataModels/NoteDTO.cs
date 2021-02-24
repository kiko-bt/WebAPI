﻿using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteApp.DataModels
{
    public class NoteDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
        public int Tag { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }
    }
}
