using System;
using System.Web.Http;
using Encrypt.Bl.Algorithms;

namespace Encrypt.WebApi.Controllers
{
    public class EncryptController : ApiController
    {
        /// <summary>
        /// Get method.
        /// </summary>
        [HttpGet]
        public IHttpActionResult Get(string alg, string str)
        {
            return Encrypt(alg, str);
        }

        /// <summary>
        /// Post method.
        /// </summary>
        [HttpPost]
        public IHttpActionResult Post(string alg, string str)
        {
            return Encrypt(alg, str);
        }

        /// <summary>
        /// Encrypts the specified string with specified algorithm.
        /// </summary>
        private IHttpActionResult Encrypt(string alg, string str)
        {
            if (alg == null) return BadRequest("'alg' parameter is not specified.");
            if (str == null) return BadRequest("'str' parameter is not specified.");
            alg = alg.Trim();
            if (string.Equals(alg, "morse", StringComparison.InvariantCultureIgnoreCase))
            {
                var encrypted = new MorseAlgorithm().Encrypt(str);
                return Ok(encrypted);
            }
            else
            {
                return BadRequest($"Unknown cipher algorithm {alg}.");
            }            
        }
    }
}
