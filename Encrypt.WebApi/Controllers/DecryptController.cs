using System;
using System.Web.Http;
using Encrypt.Bl.Algorithms;

namespace Encrypt.WebApi.Controllers
{
    public class DecryptController : ApiController
    {
        /// <summary>
        /// Get method.
        /// </summary>
        [HttpGet]
        public IHttpActionResult Get(string alg, string str)
        {
            return Decrypt(alg, str);
        }

        /// <summary>
        /// Post method.
        /// </summary>
        [HttpPost]
        public IHttpActionResult Post(string alg, string str)
        {
            return Decrypt(alg, str);
        }

        /// <summary>
        /// Decrypts the specified string with specified algorithm.
        /// </summary>
        private IHttpActionResult Decrypt(string alg, string str)
        {
            if (alg == null) return BadRequest("'alg' parameter is not specified.");
            if (str == null) return BadRequest("'str' parameter is not specified.");
            alg = alg.Trim();
            string encrypted = null;
            if (string.Equals(alg, "morse", StringComparison.InvariantCultureIgnoreCase))
            {                
                encrypted = new MorseAlgorithm().Decrypt(str);
                return Ok(encrypted);
            }
            else
            {
                return BadRequest($"Unknown cipher algorithm {alg}.");
            }
        }
    }
}
