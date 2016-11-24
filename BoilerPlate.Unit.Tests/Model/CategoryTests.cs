
using BoilerPlate.Model;
using Xamarin.Forms;
using Xunit;

namespace BoilerPlate.Unit.Tests.Model
{
    public class CategoryTests
    {
        [Fact]
        public void ConstructorSetsProperties()
        {
            var categoryTitle = "Essen";
            var categoryColor = Color.Teal;
            var category = new Category(categoryTitle, categoryColor);

            Assert.Equal(category.Title, categoryTitle);
            Assert.Equal(category.Color, categoryColor);
        }
    }
}
