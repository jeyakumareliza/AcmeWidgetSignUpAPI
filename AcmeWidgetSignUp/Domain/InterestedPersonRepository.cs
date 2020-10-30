using AcmeWidgetSignUp.Data;
using AcmeWidgetSignUp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeWidgetSignUp.Domain
{
    public class InterestedPersonRepository : IInterestedPersonRepository
    {
        private readonly ActivitySignUpContext _context;
        public InterestedPersonRepository(ActivitySignUpContext context)
        {
            _context = context;
        }

        public IEnumerable<InterestedPerson> GetInterestedPersons()
        {
            return _context.InterestedPersons.AsEnumerable();
        }

        public async Task AddInterestedPerson(InterestedPerson interestedPerson)
        {
            _context.Add(interestedPerson);
            await _context.SaveChangesAsync();
        }
    }
}
