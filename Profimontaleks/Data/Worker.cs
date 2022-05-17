using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profimontaleks.Data
{
    public class Worker
    {
        public int JMBG { get; set; }
        public double Coefficient { get; set; }
        public string NameAndSurname { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public WorkerStatus Status { get; set; }
        public int WorkerStatusId { get; set; }
        public Position Position { get; set; }
        public int PositionId { get; set; }
    }
}
