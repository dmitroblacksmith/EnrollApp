using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using EnrollApp.Models;

namespace EnrollApp.ViewModels
{
    public class AllRequestsViewModel
    {
        public IEnumerable<ClientRequest> ClientRequests { get; set; } = new List<ClientRequest>();
        
        public int CurrentRequestStateId { get; set; }
        
        public SelectList ClientRequestStates { get; set; }

        public int CurrentOfferId { get; set; }

        public SelectList Offers { get; set; }
    }
}
