using System;
using System.Collections.Generic;

namespace AppLibrary.Models;

public partial class User
{
    public string Bilet { get; set; } = null!;

    public int IdRole { get; set; }

    public string Surname { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Login { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
