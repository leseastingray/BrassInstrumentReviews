﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrassInstrumentReviews.Models
{
    public class Instrument
    {
        // ID for EF Core primary key
        public int InstrumentID { get; set; }
        public string Name { get; set; }
    }
}
