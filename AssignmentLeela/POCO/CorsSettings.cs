using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentLeela.POCO
{
    public class CorsSettings
    {
        public CorsSettings() { }

        public string AllowedHosts { get; set; }
        public string Policy { get; set; }
    }
}
