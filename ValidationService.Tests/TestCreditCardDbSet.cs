using System.Linq;

namespace ValidationService.Tests
{
    class TestCreditCardDbSet : TestDbSet<Models.CreditCard>
    {
        public override Models.CreditCard Find(params object[] keyValues)
        {
            return this.SingleOrDefault(cc => cc.Number == (int)keyValues.Single());
        }
    }
}
