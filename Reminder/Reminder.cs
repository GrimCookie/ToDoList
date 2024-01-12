using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Reminder
{
    [Serializable]
    public class Reminder : IReminder
    {
        public  string Title { get; set; }
        public string Message { get; set; }
        public DateTime ReminderTime { get; set; }
        public DateTime TimeCreated { get; set; }

        // hours, minutes, seconds


        public void StartReminderTimer()
        {
            if (ReminderTime != null)
            {
                TimerCallback callback = new TimerCallback(ProcessTimerEvent);

                TimeSpan dueTime = ReminderTime - TimeCreated;

                //var dt = DateTime.Now;

                if (TimeCreated < ReminderTime)
                {
                    var timer = new System.Threading.Timer(callback, null, dueTime, Timeout.InfiniteTimeSpan);
                }
            }

        }

        private void ProcessTimerEvent(object state)
        {
            // raise a notification for user to be advised of reminder
            Notification notification = new Notification()
            {
                Title = this.Title,
                Message = this.Message,
                CreationDate = this.TimeCreated
            };

            notification.RaiseNotification();

            //Console.WriteLine(new NotImplementedException().ToString());
        }
    }
}
