using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
                CreateFileWatcher(@"C:\Users\Jorge\Desktop");
            Console.Read();

        }

        public static void CreateFileWatcher(string path)
            {
                // Create a new FileSystemWatcher and set its properties.
                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path = path;
                /* Watch for changes in LastAccess and LastWrite times, and 
                   the renaming of files or directories. */
                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                   | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                // Only watch text files.
                watcher.Filter = "*.xlsx";

                // Add event handlers.
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Created += new FileSystemEventHandler(OnChanged);
                watcher.Deleted += new FileSystemEventHandler(OnChanged);
                watcher.Renamed += new RenamedEventHandler(OnRenamed);

                // Begin watching.
                watcher.EnableRaisingEvents = true;
            }

            // Define the event handlers.
            private static void OnChanged(object source, FileSystemEventArgs e)
            {
                // Specify what is done when a file is changed, created, or deleted.
                Console.WriteLine("Base de datos cambiada "+  DateTime.Now.ToString("hh:mm:ss"));
                Conn.insert("Base de datos cambiada " + DateTime.Now.ToString("hh:mm:ss"));
            }

            private static void OnRenamed(object source, RenamedEventArgs e)
            {
            // Specify what is done when a file is renamed.
            Console.WriteLine("Base de datos cambiada " + DateTime.Now.ToString("hh:mm:ss"));
            Conn.insert("Base de datos cambiada " + DateTime.Now.ToString("hh:mm:ss"));
        }
        }

    }


