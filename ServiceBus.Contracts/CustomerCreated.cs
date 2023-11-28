﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus.Contracts {
    public class CustomerCreated {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
