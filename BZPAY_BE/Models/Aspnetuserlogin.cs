﻿using System;
using System.Collections.Generic;

namespace BZPAY_BE.Models
{
    public partial class Aspnetuserlogin
    {
        public string? LoginProvider { get; set; }
        public string? ProviderKey { get; set; }
        public string? ProviderDisplayName { get; set; }
        public string? UserId { get; set; }

        public virtual AspnetUser? User { get; set; }
    }
}
