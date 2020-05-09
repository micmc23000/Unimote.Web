using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnimoteStaticWeb.Models
{
    public class Remote
    {
        [Required]
        public String Name { get; set; }
        public List<ButtonFunction> Buttons { get; set; }
    }
}
