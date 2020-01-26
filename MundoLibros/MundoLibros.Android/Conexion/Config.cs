using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MundoLibros.Models;
using MundoLibros.Service;
using Xamarin.Forms;
using SQLite;

[assembly: Dependency(typeof(MundoLibros.Droid.Conexion.Config))]

namespace MundoLibros.Droid.Conexion
{
    public class Config : IConfig
    {
        private SQLiteAsyncConnection db;

        private string GetPath()
        {
            var dbName = "MundoLibro.db";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
            return path;
        }
        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(GetPath());
        }
        public SQLiteAsyncConnection GetConnectionAsync()
        {
            return new SQLiteAsyncConnection(GetPath(), SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.FullMutex);
        }
    }
}