using System;
using System.Collections.Generic;

namespace AppLibrary.Models;

public partial class BookLoan
{
    public int Id { get; set; }

    public string Bilet { get; set; } = null!;

    public string Isbn { get; set; } = null!;

    public DateOnly DateIssue { get; set; }

    public DateOnly DateBackPlanned { get; set; }

    public DateOnly? DateBack { get; set; }

    public int IdStatus { get; set; }

    public virtual Status Status { get; set; } = null!;
}
