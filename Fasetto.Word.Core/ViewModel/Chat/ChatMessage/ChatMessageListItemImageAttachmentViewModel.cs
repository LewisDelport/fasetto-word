using System;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// a view model for each chat message thread item's attachment (in this case an image) in a chat thread
    /// </summary>
    public class ChatMessageListItemImageAttachmentViewModel : BaseViewModel
    {

        #region Private Members

        /// <summary>
        /// the thumbnail url of the attachment
        /// </summary>
        private string mThumbnailUrl;

        #endregion

        /// <summary>
        /// the title of this image file
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// the original file name of the attachment
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// the file size in bytes of the attachment
        /// </summary>
        public long FileSize { get; set; }
        /// <summary>
        /// the thumbnail url of the attachment
        /// </summary>
        public string ThumbnailUrl
        {
            get => mThumbnailUrl;
            set
            {
                //only update if value is not the same
                if (value == mThumbnailUrl)
                    return;

                //update value
                mThumbnailUrl = value;

                //TODO: download image from website
                //      save file to local storage/cache
                //      set LocalFilePath value
                //
                //      for now just set the file path directly
                Task.Delay(2000).ContinueWith(T =>
                {
                    LocalFilePath = "/Images/Samples/ass.jpg";
                });
            }
        }
        /// <summary>
        /// the location file path on this machine to the downloaded thumbnail
        /// </summary>
        public string LocalFilePath { get; set; }
        /// <summary>
        /// indicates if an image has loaded
        /// </summary>
        public bool ImageLoaded => LocalFilePath != null;
    }
}
