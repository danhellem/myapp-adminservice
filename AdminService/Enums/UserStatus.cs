﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.Enums
{
    public enum UserStatus
    {
        NotConfirmed = 0,
        Okay = 1,
        ForgotPassword = 2,
        BlockedExceededLoginAttempts = 3
    };
}
