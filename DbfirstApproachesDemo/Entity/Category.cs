﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbfirstApproachesDemo.Entity
{
    public partial class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string CategoryName { get; set; }
    }
}