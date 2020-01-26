using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MundoLibros.Service
{
    public interface IConfig
    {
        SQLiteConnection GetConnection();
        SQLiteAsyncConnection GetConnectionAsync();
    }
}
