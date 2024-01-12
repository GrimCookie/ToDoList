using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Notifications;


namespace Reminder
{
    [Serializable]
    class Notification
    {
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Message { get; set; }

        public void RaiseNotification()
        {
            new ToastContentBuilder()
                .AddArgument("action", "viewConverstion")
                .AddArgument("conversationId", 9813)
                .AddText(Title)
                .AddText(Message)
                .Show();
        }
    }
}
