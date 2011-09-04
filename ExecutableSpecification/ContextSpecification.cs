using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExecutableSpecfication
{
    [TestClass]
    public abstract class ContextSpecification<TSystemUnderTest> : SilverlightTest
    {
        protected TSystemUnderTest Sut { get; private set; }

        [TestInitialize]
        public void SetupContext()
        {
            Initialise();
            Sut = CreateSystemUnderTest();
            GivenThat();
            BecauseOf();
        }

        protected abstract TSystemUnderTest CreateSystemUnderTest();

        [TestCleanup]
        public void TearDownContext()
        {
            Cleanup();
        }

        protected virtual void Initialise() { }

        protected virtual void GivenThat() { }

        protected virtual void BecauseOf() { }

        protected virtual void Cleanup() { }
    }
}
