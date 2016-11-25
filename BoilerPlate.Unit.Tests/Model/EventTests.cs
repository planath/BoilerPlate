using System;
using BoilerPlate.Model;
using Xamarin.Forms;
using Xunit;

namespace BoilerPlate.Unit.Tests.Model
{
    public class EventTests
    {
        [Fact]
        public void ConstructorSetsProperties()
        {
            var eventTitle = "Zmorge";
            var eventDescription = "In der Mensa";
            var eventTime = DateTime.UtcNow;
            var eventCategory = new Category("Essen", Color.Teal);
            var evnt = new Event(eventTitle, eventDescription, eventTime, eventCategory);

            Assert.Equal(evnt.Title, eventTitle);
            Assert.Equal(evnt.Description, eventDescription);
            Assert.Equal(evnt.DateTime, eventTime);
            Assert.Equal(evnt.Category, eventCategory);
            Assert.False(evnt.Partipicate);
        }
    }
}
