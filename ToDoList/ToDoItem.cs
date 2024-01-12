using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reminder;

namespace ToDoList
{
    [Serializable]
    public class ToDoItem
    {
        //static int _id = 0;
       // public int Id { get; set; }

        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public IReminder Reminder { get; set; }
        public string Content { get; set; }


        public ToDoItem(string title, string message, DateTime reminderTime)
        {
            

            this.Title = title;
            this.Content = message;
            this.DateCreated = DateTime.Now;

            Reminder = new Reminder.Reminder()
            {
                Title = this.Title,
                Message = this.Content,
                TimeCreated = this.DateCreated
            };
            Reminder.ReminderTime = reminderTime;

            Reminder.StartReminderTimer();
        }
        public ToDoItem()
        {
            // this.Id = System.Threading.Interlocked.Increment(ref _id);
            DateCreated = DateTime.Now;
        }
        private void SetReminderTime(DateTime reminderTime)
        {
            Reminder.ReminderTime = reminderTime;
        }
        public override string ToString()
        {
            return $"Created:{DateCreated} Title: {Title}.";
        }
    }
}
