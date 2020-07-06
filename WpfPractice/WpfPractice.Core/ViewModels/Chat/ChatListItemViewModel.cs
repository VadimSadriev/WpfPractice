using WpfPractice.Core.ViewModels.Base;

namespace WpfPractice.Core.ViewModels.Chat
{
    /// <summary>
    /// View model for each chat list item in the overview chat list
    /// </summary>
    public class ChatListItemViewModel : BaseViewModel
    {
        /// <summary>
        /// The display name of this item
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Latest message from this chat
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The initials to show for the profile picture background
        /// </summary>
        public string Initials { get; set; }

        /// <summary>
        /// The rgb values in hex for background color of profile picture
        /// </summary>
        public string ProfilePictureRGB { get; set; }

        /// <summary>
        /// True if there are unread messages
        /// </summary>
        public bool NewContentAvailable { get; set; }

        /// <summary>
        /// True if chat is currently selected
        /// </summary>
        public bool IsSelected { get; set; }
    }
}
