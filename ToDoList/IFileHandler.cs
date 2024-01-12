using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    interface IFileHandler
    {
        void SaveToFile(List<ToDoItem> ListToSave);
        List<ToDoItem> LoadFromFile();

    }
}
