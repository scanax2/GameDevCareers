﻿using JobBoardPlatform.DAL.Models.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoardPlatform.DAL.Models.Company
{
    [Table("TechKeywords")]
    public class TechKeyword : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
