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
            // number consisting of 15 digits and starting with 4
            Assert.AreNotEqual("Amex", CardType(445981456357981));

            // number consisting of 14 digits and starting with 3
            Assert.AreNotEqual("Amex", CardType(34598145635798));

            // number consisting of 16 digits and starting with 3
            Assert.AreNotEqual("Amex", CardType(3459814563579810));

            // number consisting of 17 digits and starting with 4
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
            // number consisting of 15 digits and starting with 4
            Assert.AreNotEqual("JCB", CardType(445981456357981));

            // number consisting of 14 digits and starting with 3
            Assert.AreNotEqual("JCB", CardType(34598145635798));

            // number consisting of 17 digits and starting with 3
            Assert.AreNotEqual("JCB", CardType(34598145635798101));

            // number consisting of 17 digits and starting with 4
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
            // number consisting of 15 digits and starting with 4
            Assert.AreNotEqual("Visa", CardType(444499991010234));

            // number consisting of 16 digits and starting with 1
            Assert.AreNotEqual("Visa", CardType(1444999910102345));

            // number consisting of 17 digits and starting with 9
            Assert.AreNotEqual("Visa", CardType(94449999101023458));

            // number consisting of 17 digits and starting with 4
            Assert.AreNotEqual("Visa", CardType(44449999101023456));
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
            // number consisting of 15 digits and starting with 5
            Assert.AreNotEqual("Master Card", CardType(510599991220011));

            // number consisting of 17 digits and starting with 5
            Assert.AreNotEqual("Master Card", CardType(51059999122001130));

            // number consisting of 15 digits and starting with 1
            Assert.AreNotEqual("Master Card", CardType(110599991220011));

            // number consisting of 17 digits and starting with 1
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