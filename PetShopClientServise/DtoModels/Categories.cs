﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System.ComponentModel.DataAnnotations;

namespace PetShopClientServise.DtoModels;

public partial class Categories
{
    public int CategoryId { get; set; }

    [Required]
    public string Name { get; set; }

    public virtual ICollection<Animals> Animals { get; } = new List<Animals>();
}