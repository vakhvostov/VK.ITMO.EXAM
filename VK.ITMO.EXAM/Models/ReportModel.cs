using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VK.ITMO.EXAM.Models
{
    public class ReportModel
    {
        private int lineID = int.MinValue;
        private DateTime periodStart = DateTime.Now;
        private DateTime periodEnd = DateTime.Now;

        public int LineID { get => lineID; set => lineID = value; }
        public int ParameterID { get; set; }
        public string PeriodID { get; set; }
        public DateTime PeriodStart { get => periodStart; set => periodStart = value; }
        public DateTime PeriodEnd { get => periodEnd; set => periodEnd = value; }
        public string TerID { get; set; }
        public decimal Value { get; set; }
    }
}
