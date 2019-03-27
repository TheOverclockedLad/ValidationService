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
        private Main validator = new Main();

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
        /// <response code="200">OK; Validation succeeded</response>
        /// <response code="400">Bad Request; Validation failed</response>
        /// <response code="404">Not Found; Card doesn't exist</response>
        [ResponseType(typeof(string))]
        public IHttpActionResult PostValidateCreditCard(CreditCard creditCard)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            string result = "Card type: " + validator.CardType(creditCard.Number);

            if (validator.IsValid(creditCard.Number, creditCard.ExpiryDate))
            {
                //System.Data.SqlClient.SqlParameter countParam = new System.Data.SqlClient.SqlParameter("count", System.Data.SqlDbType.TinyInt) { Direction = System.Data.ParameterDirection.Output };
                //db.CreditCards.SqlQuery("EXECUTE CountCreditCardsSP @expiryDate = {0}, @number = {1}, @count = count OUTPUT", creditCard.ExpiryDate, creditCard.Number, countParam);

                //byte count = (byte)countParam.Value;

                //if (count == 1)
                if (db.CreditCards.SqlQuery("EXECUTE CountCreditCardsSP @expiryDate = {0}, @number = {1}", creditCard.ExpiryDate, creditCard.Number).Count() == 1)
                {
                    result += "; Result of validation: Valid card";
                    return Ok(result);
                }
                else
                    return NotFound();
            }
            else
                return Ok("Invalid card");
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