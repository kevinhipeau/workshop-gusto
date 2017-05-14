﻿using System;
using System.IO;
using Diabetic.Droid.Helpers;
using Diabetic.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace Diabetic.Droid.Helpers
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}