﻿using JobBoardPlatform.DAL.Models.Contracts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoardPlatform.DAL.Models.Admin
{
    [Index(nameof(Email), IsUnique = true)]
    [Table("AdminIdentities")]
    public class AdminIdentity : IUserIdentityEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }
        public int ProfileId { get; set; }
    }
}
