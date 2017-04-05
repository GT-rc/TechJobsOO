﻿using System;
using System.Collections.Generic;
using TechJobs.Data;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class JobFieldsViewModel : BaseViewModel
    {
        // The current column
        public JobFieldType Column { get; set; }

        // All fields in the given column
        public IEnumerable<JobField> Fields { get; set; }

        public JobFieldsViewModel()
        {
            PopulateColumns();
        }
    }
}
