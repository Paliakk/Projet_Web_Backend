﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class UserUpdateDTO
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string Email { get; set; }
    }
}