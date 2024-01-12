using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    [Serializable]
    public class ToDoList
    {
        private List<ToDoItem> _toDoItemList;
        private IFileHandler fileHandler = new FileHandler();
        private int _idCounter = 0;

        public ToDoItem GetItem(int index)
        {
            if(_toDoItemList != null)
            {
                if (index >= 0 && index <_toDoItemList.Count)
                {
                    return _toDoItemList[index];
                }
                else { return null; }
            }
            //return()
            return null;
        }
        public int GetLength()
        {
            return _toDoItemList.Count;
        }
        public override string ToString()
        {
            string content = "";
            if (_toDoItemList != null)
            {
                foreach (ToDoItem item in _toDoItemList)
                {
                    content += item.ToString() + "\n";
                }
            }
            else { content += "List is empty!"; }

            return content;
        }
        public ToDoList()
        {
            _toDoItemList = new List<ToDoItem>();
        }

        public void saveList() 
        {
            fileHandler.SaveToFile(_toDoItemList);
        }
        public void loadList()
        {
            
            this._toDoItemList = fileHandler.LoadFromFile();
        }
        public string addToDoItem(string title, string content)
        {
            ToDoItem newItem = new ToDoItem();

            _idCounter++;

            //newItem.Id = _idCounter;
            newItem.Title = title;
            // TODO: Remove ID from Task adds extra complication at this stage.
            newItem.Content = content;

            _toDoItemList.Add(newItem);



            return newItem.ToString();
        }
        public string addToDoItem(string title, string content, DateTime dueTime)
        {
            ToDoItem newItem = new ToDoItem(title, content, dueTime);

            //newItem.Title = title;
            //newItem.Content = content;
            //newItem.SetReminderTime(dueTime);
            
            _toDoItemList.Add(newItem);

            return newItem.ToString();
        }
        public string RemoveToDoItem(ToDoItem itemToRemove)
        {
            _toDoItemList.Remove(itemToRemove);
            return itemToRemove.ToString();
        }

        //public ToDoItem FindItemById(int selectedItemId)
        //{
        //    return _toDoItemList.Find(x => x.Id == selectedItemId);
        //}

    }
}
