using FMS_API.Controllers;

namespace FMS_API.Tests.Properties
{
    [TestFixture]
    public class UtilityTests
    {
        // Naming : UnitOfWork_Scenario_ExpectedResult

        [Test]
        public void getSplitRMHId_NoRefNo_ReturnNull()
        {
            var result = Utility.getSplitRMHId("#23452#1234213");
            Assert.IsNull(result);
        }
    }
}
