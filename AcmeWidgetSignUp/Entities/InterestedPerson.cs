using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeWidgetSignUp.Entities
{
    public class InterestedPerson
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$")]
        public string Email { get; set; }
        public int ActivityTypeId { get; set; }
        public string Comments { get; set; }

        [NotMapped]
        [EnumDataType(typeof(ActivityType))]
        public ActivityType ActivityType
        {
            get
            {
                return (ActivityType)this.ActivityTypeId;
            }
            set
            {
                this.ActivityTypeId = (int)value;
            }
        }
    }
}
