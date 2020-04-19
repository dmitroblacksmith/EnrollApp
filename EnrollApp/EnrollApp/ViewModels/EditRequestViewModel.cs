
using EnrollApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EnrollApp.ViewModels
{
    public class EditRequestViewModel
    {
        public ClientRequest ClientRequest { get; set; }
        public SelectList RequestStates { get; set; }
    }
}
