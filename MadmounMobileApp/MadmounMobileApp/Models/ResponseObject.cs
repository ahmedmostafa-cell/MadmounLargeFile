﻿using System;
namespace MadmounMobileApp.Models
{
    public class ResponseObject
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}
