using AcmeWidgetSignUp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeWidgetSignUp.Data
{
    public class ActivitySignUpContext : DbContext
    {
        public ActivitySignUpContext(DbContextOptions<ActivitySignUpContext> options)
            : base(options)
        { }

        public DbSet<InterestedPerson> InterestedPersons { get; set; }
    }
}
