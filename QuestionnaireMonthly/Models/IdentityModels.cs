using Microsoft.AspNet.Identity.EntityFramework;

namespace QuestionnaireMonthly.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<QuestionnaireMonthly.Domain.Question> Question { get; set; }
        public System.Data.Entity.DbSet<QuestionnaireMonthly.Domain.User> User { get; set; }
        public System.Data.Entity.DbSet<QuestionnaireMonthly.Domain.Answer> Answer { get; set; }
    }
}