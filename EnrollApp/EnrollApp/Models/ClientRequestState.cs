using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollApp.Models
{
    public class ClientRequestState
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsNewRequest { get; set; }
    }
}
