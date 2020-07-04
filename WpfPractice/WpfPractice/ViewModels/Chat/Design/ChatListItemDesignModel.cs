namespace WpfPractice.ViewModels.Chat
{
    /// <summary>
    /// The design time data for <see cref="ChatListViewModel"/>
    /// </summary>
    public class ChatListItemDesignModel : ChatListItemViewModel
    {
        /// <summary>
        /// The design time data for <see cref="ChatListViewModel"/>
        /// </summary>
        public ChatListItemDesignModel()
        {
            Initials = "LM";
            Name = "Luke";
            Message = "This chat app is awesome! i get this fast too";
            ProfilePictureRGB = "3099c5";
        }

        /// <summary>
        /// Single instance of design model
        /// </summary>
        public static ChatListItemDesignModel Instance
        {
            get
            {
                return new ChatListItemDesignModel();
            }
        }
    }
}
