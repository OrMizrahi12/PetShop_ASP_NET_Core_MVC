﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetShopApiServise.Models;

public partial class Categories
{
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Please enter a name")]
    [MinLength(5, ErrorMessage = "Name must be at least 2 characters long")]
    [MaxLength(20, ErrorMessage = "The name cant be larger than 20 chars")]
    public string Name { get; set; }

    public virtual ICollection<Animals> Animals { get; } = new List<Animals>();
}