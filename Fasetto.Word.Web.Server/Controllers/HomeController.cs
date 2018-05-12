using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Fasetto.Word.Web.Server
{
    public class HomeController : Controller
    {

        #region Protected Members

        /// <summary>
        /// the scoped application context
        /// </summary>
        protected ApplicationDbContext mContext;

        #endregion

        #region Constructor

        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="context">the injected context</param>
        public HomeController(ApplicationDbContext context)
        {
            mContext = context;
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
    }
}
