using System;
using System.Collections.Generic;

namespace LabTask.EF.Tables;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public int CId { get; set; }

    public virtual Category CIdNavigation { get; set; } = null!;
}
