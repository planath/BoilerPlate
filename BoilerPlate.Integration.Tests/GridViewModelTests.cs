using BoilerPlate.ViewModel;
using Xunit;

namespace BoilerPlate.Integration.Tests
{
    public class GridViewModelTests
    {
        private GridViewModel Vm { get;}
        public GridViewModelTests()
        {
            var locator = new ViewModelLocator();
            Vm = locator.Grid;
        }


        [Fact]
        public void GridViewModel_AfterInit_AllPropertiesSet()
        {
            Vm.Init();

            Assert.NotNull(Vm.Pictures);
            Assert.NotNull(Vm.Picture0);
            Assert.NotNull(Vm.Picture1);
            Assert.NotNull(Vm.Picture2);
            Assert.NotNull(Vm.Picture3);
            Assert.NotNull(Vm.Picture4);
            Assert.NotNull(Vm.Picture5);
            Assert.NotNull(Vm.Picture6);
            Assert.NotNull(Vm.Picture7);
            Assert.NotNull(Vm.Picture8);
            Assert.NotNull(Vm.Picture9);
            Assert.NotNull(Vm.Picture10);
        }
    }
}
