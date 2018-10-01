using Archery.Data;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Archery.Validators
{
    public class Email : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            using (ArcheryDbContext db = new ArcheryDbContext())
            {
                return !db.Archers.Any(x => x.Mail == value.ToString());
            }
        }
    }
}