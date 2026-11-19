using System;
using System.Collections.Generic;

namespace AppLibrary.Models;

public partial class Status
{
    public int Id { get; set; }

    public string StatuseName { get; set; } = null!;

    public virtual ICollection<BookLoan> BookLoans { get; set; } = new List<BookLoan>();
}
