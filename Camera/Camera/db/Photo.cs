using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Camera.db
{
    [Table("Img")]
    public class Photo
    {
        public Photo()
        {

        }
        public Photo(string path, string title)
        {
            Path = path;
            Title = title;
        }

        [PrimaryKey, AutoIncrement, Column("_id")]
        public int ID { get; set; }
        public string Path { get; set; }
        [Unique]
        public string Title { get; set; }
    }
}
