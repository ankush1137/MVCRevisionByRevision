﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web.Entities
{
    public partial class Image
    {
        //public Image()
        //{
        //    Employees = new HashSet<Employee>();
        //}

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [Unicode(false)]
        public string ImageName { get; set; }
        [Required]
        [StringLength(200)]
        [Unicode(false)]
        public string ImageUrl { get; set; }

        //[InverseProperty("Image")]
        //public virtual ICollection<Employee> Employees { get; set; }
    }
}