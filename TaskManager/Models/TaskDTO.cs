﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }
}