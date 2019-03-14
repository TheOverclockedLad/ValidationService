using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using ValidationService.Business;
using ValidationService.Models;

namespace ValidationService.Controllers
{
    public class CreditCardController : ApiController
    {
        private IValidationServiceContext db = new ValidationServiceContext();
        private Validator validator = new Validator();

        public CreditCardController() { }

        public CreditCardController(IValidationServiceContext context) { db = context; }

        // POST: api/CreditCard
        [ResponseType(typeof(string))]
        public IHttpActionResult PostValidateCreditCard(CreditCard creditCard)
        {
            if (ModelState.IsValid && db.CreditCards.FirstOrDefault(cc => cc.Number == creditCard.Number) != null)
            {
                string result = validator.Validate(creditCard.Number, creditCard.ExpiryDate);
                return Ok(result);
            }
            //else if (ModelState.IsValid && db.CreditCards.FirstOrDefault(cc => cc.Number == creditCard.Number) == null)
                //return NotFound();
            else
                return BadRequest();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}