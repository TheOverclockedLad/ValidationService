using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ValidationService.Tests
{
    [TestClass]
    public class TestClassValidator : Business.Main
    {
        [TestMethod]
        public void ShouldReturnCardTypeAmex()
        {
            Assert.AreEqual("Amex", CardType(345981456357981));
        }

        [TestMethod]
        public void ShouldReturnValidCardTypeAmex()
        {
            Assert.IsTrue(IsValid(345981456357981, new System.DateTime(2019, 12, 01)));
        }

        [TestMethod]
        public void ShouldNotReturnCardTypeAmex()
        {
            Assert.AreNotEqual("Amex", CardType(44598145635798190));
        }

        [TestMethod]
        public void ShouldNotReturnValidCardTypeAmex()
        {
            Assert.IsFalse(IsValid(34598145635798, null));
        }

        [TestMethod]
        public void ShouldReturnCardTypeJCB()
        {
            Assert.AreEqual("JCB", CardType(3456789000001234));
        }

        [TestMethod]
        public void ShouldReturnValidCardTypeJCB()
        {
            Assert.IsTrue(IsValid(3456789000001234, new System.DateTime(2019, 12, 01)));
        }

        [TestMethod]
        public void ShouldNotReturnCardTypeJCB()
        {
            Assert.AreNotEqual("JCB", CardType(44598145635798101));
        }

        [TestMethod]
        public void ShouldNotReturnValidCardTypeJCB()
        {
            Assert.IsFalse(IsValid(2456789000001234, new System.DateTime(2019, 12, 01)));
        }

        [TestMethod]
        public void ShouldReturnCardTypeVisa()
        {
            Assert.AreEqual("Visa", CardType(4444999910102345));
        }

        [TestMethod]
        public void ShouldReturnValidCardTypeVisa()
        {
            Assert.IsTrue(IsValid(4444999910102345, new System.DateTime(2016, 10, 01)));
        }

        [TestMethod]
        public void ShouldNotReturnCardTypeVisa()
        {
            Assert.AreNotEqual("Visa", CardType(94449999101023458));
        }

        [TestMethod]
        public void ShouldNotReturnValidCardTypeVisa()
        {
            Assert.IsFalse(IsValid(4444999910102345, new System.DateTime(2017, 10, 01)));
        }

        [TestMethod]
        public void ShouldReturnCardTypeMasterCard()
        {
            Assert.AreEqual("Master Card", CardType(5105999912200110));
        }

        [TestMethod]
        public void ShouldReturnValidCardTypeMasterCard()
        {
            Assert.IsTrue(IsValid(5105999912200110, new System.DateTime(2017, 02, 01)));
        }

        [TestMethod]
        public void ShouldNotReturnCardTypeMasterCard()
        {
            Assert.AreNotEqual("Master Card", CardType(11059999122001156));
        }

        [TestMethod]
        public void ShouldNotReturnValidCardTypeMasterCard()
        {
            Assert.IsFalse(IsValid(5105999912200110, new System.DateTime(2016, 02, 01)));
        }

        [TestMethod]
        public void ShouldReturnUnknownAndOrInvalidCard()
        {
            Assert.AreEqual("Unknown and/or invalid card", CardType(1234567890987654321));
        }
    }
}