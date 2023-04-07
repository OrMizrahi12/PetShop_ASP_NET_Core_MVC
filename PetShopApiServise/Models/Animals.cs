﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopApiServise.Models;

public partial class Animals
{
    public int AnimalId { get; set; }

    [Required(ErrorMessage = "Please enter a name")]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters long")]
    [MaxLength(20, ErrorMessage = "The name cant be larger than 20 chars")]
    public string Name { get; set; }

    [Required]
    [Range(1, 100, ErrorMessage = "The age must be between 1 and 100.")]
    public int Age { get; set; }

    [NotMapped]
    [Required(ErrorMessage = "Please select a file")]
    public IFormFile ImageFile { get; set; }
    public byte[] Picture { get; set; }

    [Required(ErrorMessage = "Please enter a description")]
    [StringLength(255, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 255 characters")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Please select a category")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a category")]
    public int? CategoryId { get; set; }

    public virtual Categories Category { get; set; }

    public virtual ICollection<Comments> Comments { get; } = new List<Comments>();
}