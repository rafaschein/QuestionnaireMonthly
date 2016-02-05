using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireMonthly.Domain
{
    public class Question : Entity
    {
        public String Description { get; set; }
        public int Order { get; set; }
        public int? DependenceId { get; set; }
    }
}
