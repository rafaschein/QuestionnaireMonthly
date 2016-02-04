using QuestionnaireMonthly.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionnaireMonthly.Models
{
    public class Answer : Entity
    {
        public int QuestionID { get; set; }
        public int UserID { get; set; }
        public Boolean Response { get; set; }
        public DateTime Date { get; set; }

        public virtual Question Question { get; set; }
        public virtual User User { get; set; }
    }
}