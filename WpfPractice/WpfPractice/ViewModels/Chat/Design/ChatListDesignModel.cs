using System.Collections.Generic;

namespace WpfPractice.ViewModels.Chat
{
    /// <summary>
    /// The design time data for <see cref="ChatListViewModel"/>
    /// </summary>
    public class ChatListDesignModel : ChatListViewModel
    {
        /// <summary>
        /// The design time data for <see cref="ChatListViewModel"/>
        /// </summary>
        public ChatListDesignModel()
        {
            Items = new List<ChatListItemViewModel>
            {
                new ChatListItemViewModel
                {
                    Name = "Luke",
                    Initials = "LM",
                    Message = "This chat app is awesome! i get this fast too",
                    ProfilePictureRGB = "3099c5",
                    NewContentAvailable = true
                },
                 new ChatListItemViewModel
                 {
                    Name = "Jesse",
                    Initials = "JA",
                    Message = "Hey dude here are new icons",
                    ProfilePictureRGB = "fe4503",
                    IsSelected = true
                 },
                new ChatListItemViewModel
                 {
                     Name = "PARNELL",
                    Initials = "PL",
                    Message = "The new server is up",
                    ProfilePictureRGB = "00d405"
                 },
            };
        }

        /// <summary>
        /// Single instance of design model
        /// </summary>
        public static ChatListDesignModel Instance
        {
            get
            {
                return new ChatListDesignModel();
            }
        }
    }
}
