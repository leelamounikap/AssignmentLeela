using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentLeela.POCO
{
    public class InputWrapper
    {
        //[JsonProperty("inputCards")]
        public List<string> inputCards { get; } = new List<string>();

    }
}
