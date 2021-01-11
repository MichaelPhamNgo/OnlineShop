﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class TagModel
    {
        public long Id { get; set; }
        public string TagName { get; set; }
        public string TagDescription { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Creator { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Modifier { get; set; }
        public string Status { get; set; }
    }
}
