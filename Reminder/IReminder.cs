using System;

namespace Reminder
{
    public interface IReminder
    {
        string Title { get; set; }
        string Message { get; set; }
        DateTime ReminderTime { get; set; }
        DateTime TimeCreated { get; set; }
        void StartReminderTimer();
    }
}