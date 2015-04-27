using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobShop.Models
{
    public class HomePageModel
    {
        //public AspNetUsers Model3 { get; set; } 

        public List<Jobs> allJobs { get; set; }
        public List<Candidates> allCandidates { get; set; }
        public List<AspNetUsers> allUsers { get; set; }
    }
}
