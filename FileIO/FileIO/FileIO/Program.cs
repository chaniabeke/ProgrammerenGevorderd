﻿using FileIO.Models;
using System;
using System.IO;
using System.IO.Compression;

namespace FileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = @"C:\Users\Chania\Desktop\Programmeren Gevorderd\";
            string zipFilePathBIG = @"C:\Users\Chania\Desktop\PROJECT\VipServices2020.zip";
            string zipFileSMALL = @"C:\Users\Chania\Desktop\Programmeren Gevorderd\Unit tests\Restaurant.zip";
            string zipFilePathMIDDEl = @"C:\Users\Chania\Desktop\Programmeren Gevorderd\Collections\CollectionsShipsExcercise.zip";
            string outputPath = @"C:\Users\Chania\Desktop\Programmeren Gevorderd\";

            Project project = new Project(inputPath, zipFilePathMIDDEl, outputPath);
            project.Analyse();
        }
    }
}
