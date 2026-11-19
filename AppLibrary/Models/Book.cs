using System;
using System.Collections.Generic;

namespace AppLibrary.Models;

public partial class Book
{
    public string Isbn { get; set; } = null!;

    public string BookName { get; set; } = null!;

    public int IdAuthor { get; set; }

    public int IdGenre { get; set; }

    public int IdPublish { get; set; }

    public int YearPub { get; set; }

    public int Pages { get; set; }

    public int Copies { get; set; }

    public int Available { get; set; }

    public string Annotation { get; set; } = null!;

    public string? Image { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual Genre Genre { get; set; } = null!;

    public virtual PublishHouse PublishHouse { get; set; } = null!;
}
