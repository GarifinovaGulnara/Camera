using System;
using System.Collections.Generic;
using System.Text;

namespace Camera.db
{
    public interface ISqlite
    {
        string GetDataBasePath(string filename);
    }
}
