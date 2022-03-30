﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Bootcamp_Homework_1.Models
{
    public class ResponseViewModel
    {
        public bool Success { get; set; }

        public string Error { get; set; }

        public string Data { get; set; }
    }
}
