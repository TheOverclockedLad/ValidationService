using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using ValidationService.Business;
using ValidationService.Models;

namespace ValidationService.Controllers
{
    /// <summary>
    /// Controls stuff related to credit cards
    /// </summary>
    public class CreditCardController : ApiController
    {
        private IValidationServiceContext db = new ValidationServiceContext();
        private Validator validator = new Validator();

        /// <summary>
        /// Default constructor
        /// </summary>
        public CreditCardController() { }


        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="context">The DB context class to be used</param>
        public CreditCardController(IValidationServiceContext context) { db = context; }

        // POST: api/CreditCard
        /// <summary>
        /// POST method which validates the credit card
        /// </summary>
        /// <param name="creditCard">The CreditCard model instance to be validated</param>
        /// <returns>200 OK if the validation succeeds; 400 Bad Request if the validation fails</returns>
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

        /// <summary>
        /// Disposes the controller instance
        /// </summary>
        /// <param name="disposing"></param>
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