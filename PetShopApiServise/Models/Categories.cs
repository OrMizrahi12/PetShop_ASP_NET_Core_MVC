﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace PetShopApiServise.Models;

public partial class Categories
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; }

    public virtual ICollection<Animals> Animals { get; } = new List<Animals>();

    public virtual ICollection<PetProducts> PetProducts { get; } = new List<PetProducts>();
}