using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yp_01_Decktop.Classes
{
    public class HistoryPerformerRequest
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public User Performer { get; set; }
        public string Date { get; set; }
        public string Comment { get; set; }
    }
}
