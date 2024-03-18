using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yp_01_Decktop.Classes
{
    public class Request
    {
        public int Id { get; set; }
        public Guid Number { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Equipment { get; set; }
        public TypeOfFault TypeOfFault { get; set; }
        public string Description { get; set; }
        public User Client { get; set; }
        public User Performer { get; set; }
        public Status Status { get; set; }
        public string PerformerComment { get; set; }
    }
}
