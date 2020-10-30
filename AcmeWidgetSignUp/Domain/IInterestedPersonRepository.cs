using AcmeWidgetSignUp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeWidgetSignUp.Domain
{
    public interface IInterestedPersonRepository
    {
        IEnumerable<InterestedPerson> GetInterestedPersons();
        Task AddInterestedPerson(InterestedPerson interestedEmployee);
    }
}
