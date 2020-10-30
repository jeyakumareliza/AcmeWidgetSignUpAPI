using AcmeWidgetSignUp.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AcmeWidgetSignUp.UnitTest
{
    [TestClass]
    public class InterestedPersonTests
    {
        [TestMethod]
        public void InterestedPerson_ShouldBeValid()
        {
            var interestedPerson = new InterestedPerson
            {
                Email = "mail@mail.ca",
                FirstName = "John",
                LastName = "Doe",
                ActivityType = ActivityType.Basketball
            };

            var errors = ValidateModel(interestedPerson);

            Assert.IsFalse(errors.Any());
        }

        [TestMethod]
        public void InterestedPerson_ShouldBeInvalid()
        {
            var interestedPerson = new InterestedPerson { };

            var errors = ValidateModel(interestedPerson);

            Assert.IsTrue(errors.Any());
        }

        //https://stackoverflow.com/questions/2167811/unit-testing-asp-net-dataannotations-validation
        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}
