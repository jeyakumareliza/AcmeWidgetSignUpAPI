using AcmeWidgetSignUp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeWidgetSignUp.Dtos
{
    public class InterestedPersonDto
    {
        // TODO expose this to the API instead of the entity
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ActivityType { get; set; }
        public string Comments { get; set; }
    }
}
