using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string SubjectName { get; set; }
        public int Score { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}