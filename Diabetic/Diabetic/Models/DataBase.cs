using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;

namespace Diabetic.Models
{
    public   class DataBase
    {
        public static SQLiteConnection Connection;
        public static DataBase Database;

        public DataBase(string path)
        {
            Connection = new SQLiteConnection(path);
            Connection.CreateTable<DataSugar>();
            Connection.CreateTable<User>();
            Database = this;





        }
        public List<User> GetContacts()
        {
            return Connection.Table<User>().ToList();
        }



        public User GetItem(Guid id)
        {
            return Connection.Table<User>().FirstOrDefault(i => i.ID == id);
        }

        public int SaveItem(User item)
        {
            return GetItem(item.ID) != null ? Connection.Update(item) : Connection.Insert(item);
        }

        public int DeleteItemAsync(User item)
        {
            return Connection.Delete(item);
        }
        public int DeleteAllItemAsync()
        {
            return Connection.DeleteAll<User>();
        }

    }
}