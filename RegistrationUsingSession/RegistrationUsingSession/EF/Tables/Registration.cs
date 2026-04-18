using System;
using System.Collections.Generic;

namespace RegistrationUsingSession.EF.Tables;

public partial class Registration
{
    public string Email { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public string Name { get; set; } = null!;
}
