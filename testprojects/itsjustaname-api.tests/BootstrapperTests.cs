using NUnit.Framework;

namespace itsjustaname_api.tests
{
    [TestFixture]
    public class BootstrapperTests
    {
        [Test]
        public void BootstrapperInitialises()
        {
            var bootstrapper = new Bootstrapper();
            Assert.DoesNotThrow(() => bootstrapper.Initialise());
        }
    }
}