using System.Collections.Generic;
using WpfPractice.Core.ViewModels.Base;

namespace WpfPractice.Core.ViewModels.Chat
{
    /// <summary>
    /// View model for the overview chat list
    /// </summary>
    public class ChatListViewModel : BaseViewModel
    {
        /// <summary>
        /// The chat list items for list
        /// </summary>
        public List<ChatListItemViewModel> Items { get; set; }
    }
}
