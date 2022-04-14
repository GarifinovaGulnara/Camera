using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Camera.db
{
    public class CRUDOperation
    {
        SQLiteConnection db;

        public CRUDOperation(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Photo>();
        }

        public IEnumerable<Photo> GetItems()
        {
            return db.Table<Photo>().ToList();
        }

        public Photo GetItem(int id)
        {
            return db.Get<Photo>(id);
        }

        public int DeleteItem(int id)
        {
            return db.Delete<Photo>(id);
        }

        public int SaveItem(Photo saveItem)
        {
            if (saveItem.ID != 0)
            {
                db.Update(saveItem);
                return saveItem.ID;
            }
            else
            {
                return db.Insert(saveItem);
            }
        }
    }
}
