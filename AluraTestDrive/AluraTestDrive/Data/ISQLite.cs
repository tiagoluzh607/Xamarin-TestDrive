
using SQLite;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace AluraTestDrive.Data
{
    public interface ISQLite
    {
       SQLiteConnection PegarConexao();
    }
}
