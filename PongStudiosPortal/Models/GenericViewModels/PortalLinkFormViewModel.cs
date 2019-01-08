using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PongStudiosPortal.Models.GenericViewModels
{
    public class PortalLinkFormViewModel
    {
        public int Id { get; set; }
        public IFormFile Image { get; set; }
        public string Text { get; set; }
        public string HttpLink { get; set; }
    }
}
