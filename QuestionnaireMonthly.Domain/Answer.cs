using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireMonthly.Domain
{
    public class Answer : Entity
    {
        public long QuestionID { get; set; }
        public long UserID { get; set; }
        public Boolean Response { get; set; }
        public DateTime Date { get; set; }

        public virtual Question Question { get; set; }
        public virtual User User { get; set; }

        public Answer()
        {
            Date = DateTime.Now;
        }
    }
}
