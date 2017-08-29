using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficReporter.Model.Common;

namespace TrafficReporter.Model
{
    public class Cause : ICause
    {
        public int Id { get; set; }
        public string IconUri { get; set; }
        public string Name { get; set; }
    }
}
