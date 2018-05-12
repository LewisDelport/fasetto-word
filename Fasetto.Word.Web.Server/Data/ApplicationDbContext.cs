using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fasetto.Word.Web.Server
{
    /// <summary>
    /// the databse representational model for our application
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        #region Public Properties

        /// <summary>
        /// the settings for the application
        /// </summary>
        public DbSet<SettingsDataModel> Settings { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// default constructor, expecting database options passed in
        /// </summary>
        /// <param name="options">the database context options</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        #endregion

        #region Overrides

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //fluent api
            //adds name as index
            modelBuilder.Entity<SettingsDataModel>().HasIndex(a => a.Name);
        }

        #endregion
    }
}
