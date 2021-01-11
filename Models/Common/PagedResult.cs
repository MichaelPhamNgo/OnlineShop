﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.Common
{
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public PagedResult()
        {
            Results = new List<T>();
        }
        public IList<T> Results { get; set; }
    }
}