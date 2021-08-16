using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryProjectMvc.Models.Entity;

namespace LibraryProjectMvc.Models.Classes
{
    public class Class1
    {
        public IEnumerable<Books> bookValue { get; set; }
        public IEnumerable<Abouts> aboutValue { get; set; }
    }
}