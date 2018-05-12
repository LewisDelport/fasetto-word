using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Fasetto.Word.Web.Server
{
    public class HomeController : Controller
    {

        #region Protected Members

        /// <summary>
        /// the scoped application context
        /// </summary>
        protected ApplicationDbContext mContext;
        /// <summary>
        /// the manager for handling user creation, deletion, searching, roles etc...
        /// </summary>
        protected UserManager<ApplicationUser> mUserManager;
        /// <summary>
        /// the manager for handling signin in and out for our users
        /// </summary>
        protected SignInManager<ApplicationUser> mSignInManager;

        #endregion

        #region Constructor

        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="context">the injected context</param>
        public HomeController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            mContext = context;
            mUserManager = userManager;
            mSignInManager = signInManager;
        }

        #endregion

        public IActionResult Index()
        {
            //make sure we have the database
            mContext.Database.EnsureCreated();

            if (!mContext.Settings.Any())
            {
                mContext.Settings.Add(new SettingsDataModel()
                {
                    Name = "BackgroundColor",
                    Value = "Red",
                });

                var settingsLocally = mContext.Settings.Local.Count();
                var settingsDatabase = mContext.Settings.Count();

                var firstLocal = mContext.Settings.Local.FirstOrDefault();
                var firstDatabase = mContext.Settings.FirstOrDefault();

                mContext.SaveChanges();

                settingsLocally = mContext.Settings.Local.Count();
                settingsDatabase = mContext.Settings.Count();

                firstLocal = mContext.Settings.Local.FirstOrDefault();
                firstDatabase = mContext.Settings.FirstOrDefault();
            }

            return View();
        }

        /// <summary>
        /// creates our single user for now
        /// </summary>
        /// <returns></returns>
        [Route("create")]
        public async Task<IActionResult> CreateUserAsync()
        {
            var result = await mUserManager.CreateAsync(new ApplicationUser
            {
                UserName = "pielkop",
                Email = "piel@balsak.com",
            }, "password");

            if (result.Succeeded)
                return Content("User was created!", "text/html");

            return Content("User creation failed!", "text/html");
        }

        /// <summary>
        /// private area
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [Route("private")]
        public IActionResult Private()
        {
            return Content($"This is a private area. Welcome {HttpContext.User.Identity.Name}", "text/html");
        }
        /// <summary>
        /// an-auto login page for testing
        /// </summary>
        /// <param name="returnUrl">the url to return to if successfully logged in</param>
        /// <returns></returns>
        [Route("login")]
        public async Task<IActionResult> LoginAsync(string returnUrl)
        {
            //sign out any previous sessions
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            //sign user in with the valid credentials
            var result = await mSignInManager.PasswordSignInAsync("pielkop", "password", true, false);

            //if successfull...
            if (result.Succeeded)
            {
                //if we have no return url...
                if (string.IsNullOrEmpty(returnUrl))
                    //go to home
                    return RedirectToAction(nameof(Index));
                //otherwise, goto the return url
                return Redirect(returnUrl);
            }

            return Content("Failed to login", "text/html");
        }

        [Route("logout")]
        public async Task<IActionResult> SignOutAsync()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return Content("Done");
        }
    }
}
