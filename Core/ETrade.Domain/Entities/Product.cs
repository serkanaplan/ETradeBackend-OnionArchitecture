﻿using ETrade.Domain.Entities.Common;

namespace ETrade.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }
    public ICollection<Order> Orders { get; set; }
    public ICollection<ProductImageFile> ProductImageFiles { get; set; }
    public ICollection<BasketItem> BasketItems { get; set; }
}
