using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace ToDoList
{

    class FileHandler : IFileHandler
    {
        const string FILE_NAME = "myToDoListFile.dat";
        
        public void SaveToFile(List<ToDoItem> ListToSave)
        {
            if (ListToSave != null)
            {
                using (FileStream outFile = new FileStream(FILE_NAME, FileMode.Create, FileAccess.Write))
                {
                    BinaryFormatter bFormatter = new BinaryFormatter();

                    bFormatter.Serialize(outFile, ListToSave);
                }
            }
        }
        public List<ToDoItem> LoadFromFile()
        {
            List<ToDoItem> loadedList;

            try
            {
                using (FileStream inFile = new FileStream(FILE_NAME, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter bFormatter = new BinaryFormatter();
                    loadedList = (List<ToDoItem>)bFormatter.Deserialize(inFile);
                }
            }
            catch (IOException e)
            {
                string ex = e.ToString();
                loadedList = new List<ToDoItem>();
            }
            finally
            { 
               
            }

            return loadedList;
        }

    }
}
