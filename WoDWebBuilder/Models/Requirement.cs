﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WoDWebBuilder.Models
{
    public class Requirement
    {
        public int StatID { get; set; }
        public int Value { get; set; }
        public bool Additive { get; set; }
    }
}