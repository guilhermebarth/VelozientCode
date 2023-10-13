using SmartVault.Program.BusinessObjects;

namespace SmartVault.ProjectProgramTest
{
    public class GeneralTests
    {
        [SetUp]
        public void Setup()
        {
            // We need to run to have a possibility to make request inside the method existent.
            // So this way I don`t need to use Mock.
            // Of course this time for one test is too much, but that's why I just created two tests.
            DataGeneration.Program.Main(new string[] { });
        }

        [Test]
        public void VerifyIfReturnsADocument()
        {
            string accountId = "1";

            Document thirdDocument = Program.Program.GetThirdDocumentFromSQL(accountId);

            Assert.IsNotNull(thirdDocument);

        }

        [Test]
        public void VerifySizeOfTheDocument()
        {
            long expectedValue = 2626;

            long sizeInBytes = Program.Program.GetAllFileSizes();

            // My case 2626 is the size. Should be the same for you
            Assert.AreEqual(expectedValue, sizeInBytes);

        }
    }
}