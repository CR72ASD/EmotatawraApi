﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Entity
{
    [Table("Admin")]
    public partial class Admin: BaseEntity
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(14)]
        public string NationalId { get; set; }
        [StringLength(50)]
        public string FristName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string ThirdName { get; set; }
        [StringLength(50)]
        public string FouthName { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
    }
}