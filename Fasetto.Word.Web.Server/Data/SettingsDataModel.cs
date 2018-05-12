using System.ComponentModel.DataAnnotations;

namespace Fasetto.Word.Web.Server
{
    /// <summary>
    /// our settings database table representational model
    /// </summary>
    public class SettingsDataModel
    {
        /// <summary>
        /// the unique id for this entry
        /// </summary>
        [Key]
        public string Id { get; set;}
        /// <summary>
        /// the settings name
        /// </summary>
        /// <remarks>this column is indexed</remarks>
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        /// <summary>
        /// the settings value
        /// </summary>
        [Required]
        [MaxLength(2048)]
        public string Value { get; set; }
    }
}
