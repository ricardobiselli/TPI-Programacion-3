using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Compatibility( string ram, string socket)
    {
        public int Id { get; set; }
        public string? Ram { get; set; } = ram;
        public List<string>? Series { get; set; } = [];
        public string? Socket { get; set; } = socket;

    }
}
