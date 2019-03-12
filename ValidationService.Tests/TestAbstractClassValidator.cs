using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ValidationService.Tests
{
    [TestClass]
    public class TestAbstractClassValidator : Validator
    {
        [TestMethod]
        void Validate_ReturnCardTypeAmex()
        {
            System.DateTime expiry = new System.DateTime();
            expiry.AddMonths(12);
            expiry.AddYears(2019);

            var validator = new Validator(345981456357981, expiry);
            string cardType = validator.Validate();

            Assert.IsNotNull(cardType);
            Assert.AreEqual("Amex", cardType);
        }

        [TestMethod]
        void Validate_ReturnCardTypeJCB()
        {
            System.DateTime expiry = new System.DateTime();
            expiry.AddMonths(12);
            expiry.AddYears(2019);

            var validator = new Validator(3456789000001234, expiry);
            string cardType = validator.Validate();

            Assert.IsNotNull(cardType);
            Assert.AreEqual("JCB", cardType);
        }

        [TestMethod]
        void Validate_ReturnCardTypeVisa()
        {
            System.DateTime expiry = new System.DateTime();
            expiry.AddMonths(10);
            expiry.AddYears(2016);

            var validator = new Validator(4444999910102345, expiry);
            string cardType = validator.Validate();

            Assert.IsNotNull(cardType);
            Assert.AreEqual("Visa", cardType);
        }

        [TestMethod]
        void Validate_ReturnCardTypeMasterCard()
        {
            System.DateTime expiry = new System.DateTime();
            expiry.AddMonths(2);
            expiry.AddYears(2017);

            var validator = new Validator(5105999912200110, expiry);
            string cardType = validator.Validate();

            Assert.IsNotNull(cardType);
            Assert.AreEqual("Master Card", cardType);
        }

        [TestMethod]
        void Validate_ReturnUnknownAndOrInvalidCard()
        {
            System.DateTime expiry = new System.DateTime();
            expiry.AddMonths(9);
            expiry.AddYears(2019);

            var validator = new Validator(1234567890987654321, expiry);
            string cardType = validator.Validate();

            Assert.IsNotNull(cardType);
            Assert.AreEqual("Unknow and/or invalid card", cardType);
        }
    }
}