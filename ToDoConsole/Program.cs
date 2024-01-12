using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Notifications;

namespace ToDoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ToDoList.ToDoList ToDo = new ToDoList.ToDoList();

            ToDo.addToDoItem("Today 11-11-2020", "text content of item", DateTime.Now.AddSeconds(3));
            ToDo.addToDoItem("Cat food", "Remember to buy his favourite food from store", DateTime.Now.AddSeconds(4));
            ToDo.addToDoItem("Stuff", "All the things I would usualy forget", DateTime.Now.AddSeconds(5));
            ToDo.addToDoItem("Project ideas", "Lots of realy good ideas to turn into projectes and wow people...", DateTime.Now.AddSeconds(6));

            //ToDo.addToDoItem("Today 11-11-2020", "text content of item", DateTime.Now.AddSeconds(3));
            //ToDo.addToDoItem("Cat food", "Remember to buy his favourite food from store");
            //ToDo.addToDoItem("Stuff", "All the things I would usualy forget");
            //ToDo.addToDoItem("Project ideas", "Lots of realy good ideas to turn into projectes and wow people...");

            Console.WriteLine(ToDo.ToString());
            
            ToDo.saveList();
            ToDo.loadList();
            Console.WriteLine(ToDo.ToString());

            //WindowsNotification();
            //ReminderTest(ToDo.GetItem(2));

            exit();
        }

        public static void ReminderTest(ToDoList.ToDoItem item)
        {

            Reminder.IReminder r = new Reminder.Reminder()
            {
                Title = item.Title,
                Message = item.Content,
                TimeCreated = DateTime.Now,
                ReminderTime = DateTime.Now.AddSeconds(3)
            };

            r.StartReminderTimer();

        }
        public static void WindowsNotification()
        {

            new ToastContentBuilder()
                .AddArgument("action", "viewConverstion")
                .AddArgument("conversationId", 9813)
                .AddText("Hello")
                .AddText("Check this out dude")
                .Show();
        }
        public static void exit()
        {
            Console.WriteLine("Enter something to quite");
            Console.ReadLine();
        }
    }
}
