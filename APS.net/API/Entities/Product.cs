using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Thumbnail { get; set; }

    public decimal Price { get; set; }

    public int Qty { get; set; }

    public string? Description { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;
}
