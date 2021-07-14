﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_X.Contracts.Requests
{
    public class UpdateApplicationRequest
    {
        public DateTime? Date { get; set; }
        public string Status { get; set; }
        public long CandidateId { get; set; }
        public long OfferId { get; set; }
    }
}