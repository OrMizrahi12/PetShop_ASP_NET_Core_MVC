﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace PetShopApiServise.Models;

public partial class PetProducts
{
    public int ProductId { get; set; }

    public string ProductName { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public int? CategoryId { get; set; }

    public byte[] Image { get; set; }

    public virtual ICollection<Cart> Cart { get; } = new List<Cart>();

    public virtual Categories Category { get; set; }

    public virtual ICollection<Comments> Comments { get; } = new List<Comments>();

    public virtual ICollection<OrderItems> OrderItems { get; } = new List<OrderItems>();

    public virtual ICollection<WishList> WishList { get; } = new List<WishList>();
}