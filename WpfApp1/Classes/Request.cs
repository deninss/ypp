using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Classes
{
    public class Request
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Equipment { get; set; }
        public string TypeOfFault { get; set; }
        public string Description { get; set; }
        public string Client { get; set; }
        public string Performer { get; set; }
        public string Status { get; set; }
        public string PerformerComment { get; set; }
    }
}
