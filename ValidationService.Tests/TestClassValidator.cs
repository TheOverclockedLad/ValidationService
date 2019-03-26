using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ValidationService.Tests
{
    [TestClass]
    public class TestClassValidator : Business.Validator
    {
        [TestMethod]
        public void Validate_ReturnCardTypeAmex()
        {
            System.DateTime expiry = new System.DateTime(2019, 12, 01);

            string cardType = Validate(345981456357981, expiry);

            Assert.IsNotNull(cardType);
            Assert.AreEqual("Amex", cardType);
        }

        [TestMethod]
        public void Validate_ReturnCardTypeJCB()
        {
            System.DateTime expiry = new System.DateTime(2019, 12, 01);

            string cardType = Validate(3456789000001234, expiry);

            Assert.IsNotNull(cardType);
            Assert.AreEqual("JCB", cardType);
        }

        [TestMethod]
        public void Validate_ReturnCardTypeVisa()
        {
            System.DateTime expiry = new System.DateTime(2016, 10, 01);

            string cardType = Validate(4444999910102345, expiry);

            Assert.IsNotNull(cardType);
            Assert.AreEqual("Visa", cardType);
        }

        [TestMethod]
        public void Validate_ReturnCardTypeMasterCard()
        {
            System.DateTime expiry = new System.DateTime(2017, 02, 01);

            string cardType = Validate(5105999912200110, expiry);

            Assert.IsNotNull(cardType);
            Assert.AreEqual("Master Card", cardType);
        }

        [TestMethod]
        public void Validate_ReturnUnknownAndOrInvalidCard()
        {
            System.DateTime expiry = new System.DateTime(2019, 09, 01);

            string cardType = Validate(1234567890987654321, expiry);

            Assert.IsNotNull(cardType);
            Assert.AreEqual("Unknown and/or invalid card", cardType);
        }
    }
}