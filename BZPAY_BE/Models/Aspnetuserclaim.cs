﻿using System;
using System.Collections.Generic;

namespace BZPAY_BE.Models
{
    public partial class Aspnetuserclaim
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }

        public virtual AspnetUser User { get; set; } = null!;
    }
}
