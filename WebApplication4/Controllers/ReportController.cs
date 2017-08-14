using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication4.Controllers
{
    public class ReportController : ApiController
    {
        #region Constructors


        /// <summary>
        /// Initializes a new instance of the <see cref="ReportController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public ReportController(IReportService service)
        {
            this.Service = service;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <value>The service.</value>
        protected IReportService Service { get; private set; }

        #endregion Properties

        #region Methods

        [HttpDelete]
        [Route("my-cart/products/{id}")]
        public bool DeleteReportAsync(Guid Id)
        {
            return Service.RemoveFromCart(id);
        }

        [HttpGet]
        [Route("products")]
        public List<IProduct> GetAsync()
        {
            return Service.GetAllAvailableProducts();
        }

        [HttpGet]
        [Route("my-cart")]
        public ICart GetMyCartAsync()
        {
            return Service.GetMyCart();
        }

        [HttpGet]
        [Route("my-cart/products")]
        public List<IProduct> GetMyCartProductsAsync()
        {
            return Service.GetMyCart().Items;
        }

        [HttpPost]
        [Route("my-cart/products/{id}")]
        public HttpResponseMessage PostMyCartProductsAsync(int id)
        {
            try
            {
                return Request.CreateResponse<bool>(Service.AddToCart(id));
            }
            catch (ArgumentOutOfRangeException)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Item is Out of Stock.");
            }
            catch (ArgumentNullException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Item's expiration date has passed.");
            }
        }


        #endregion Methods
    }
}