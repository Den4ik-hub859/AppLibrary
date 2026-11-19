using System;
using System.Collections.Generic;

namespace AppLibrary.Models;

public partial class PublishHouse
{
    public int Id { get; set; }

    public string PublishHouseName { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
