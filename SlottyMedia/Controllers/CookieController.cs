using Microsoft.AspNetCore.Mvc;

namespace SlottyMedia.Controllers
{
    /// <summary>
    /// Controller for setting cookies.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CookieController : ControllerBase
    {
        /// <summary>
        /// Sets a cookie with the provided data.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("set")]
        public IActionResult SetCookie([FromBody] CookieRequest? request)
        {
            if (request == null || string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Value))
            {
                return BadRequest("Invalid cookie data.");
            }

            var cookieOptions = new CookieOptions
            {
                Expires = request.Expires ?? DateTimeOffset.UtcNow.AddDays(7),
                HttpOnly = request.HttpOnly,
                Secure = request.Secure,
                SameSite = request.SameSite
            };

            Response.Cookies.Append(request.Name, request.Value, cookieOptions);
            return Ok("Cookie set successfully.");
        }
    }

    /// <summary>
    /// Request model for setting cookies.
    /// </summary>
    public class CookieRequest
    {
        /// <summary>
        /// Constructor for creating a new cookie request.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="expires"></param>
        /// <param name="httpOnly"></param>
        /// <param name="secure"></param>
        /// <param name="sameSite"></param>
        public CookieRequest(string name, string? value, DateTimeOffset? expires, bool httpOnly, bool secure, SameSiteMode sameSite)
        {
            Name = name;
            Value = value;
            Expires = expires;
            HttpOnly = httpOnly;
            Secure = secure;
            SameSite = sameSite;
        }

        public string Name { get; set; }
        public string? Value { get; set; }
        public DateTimeOffset? Expires { get; set; }
        public bool HttpOnly { get; set; }
        public bool Secure { get; set; }
        public SameSiteMode SameSite { get; set; }
    }
}