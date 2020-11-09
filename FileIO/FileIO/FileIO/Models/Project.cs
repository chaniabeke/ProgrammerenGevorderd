using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace FileIO.Models
{
    public class Project
    {
        #region Properties

        public string InputPath { get; set; }
        public string ZipFilePath { get; set; }
        public string OutputPath { get; set; }
        private string _outputAnalyseFile;
        private string _outputClassInfoFile;
        private readonly string _folderInput = "FileIO_Input";
        private readonly string _folderOutput = "FileIO_Results";
        private List<string> _csFilePaths = new List<string>();
        private List<FileInfo> _files = new List<FileInfo>();
        private List<ClassInfo> _classInfos = new List<ClassInfo>();

        #endregion Properties

        #region Constructors

        public Project(string inputPath, string zipFilePath, string outputPath)
        {
            InputPath = inputPath + _folderInput;
            ZipFilePath = zipFilePath;
            OutputPath = outputPath + _folderOutput;
            _outputAnalyseFile = "Analyse_" + Path.GetFileNameWithoutExtension(zipFilePath) + ".txt";
            _outputClassInfoFile = "ClassInfo_" + Path.GetFileNameWithoutExtension(zipFilePath) + ".txt";
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Controller method, roept alle andere methods op voor een volledige analyze van het bestand.
        /// </summary>
        public void Analyse()
        {
            Console.WriteLine("START... Extract ZipFile");
            ExtractZipFile();
            Console.WriteLine("END... Extract ZipFile");

            Console.WriteLine("START... Analyse ZipFile");
            _csFilePaths = Directory.GetFiles(InputPath, "*.cs", SearchOption.AllDirectories).ToList();
            foreach (string filePath in _csFilePaths)
            {
                if (!filePath.Contains(".g.cs") && !filePath.Contains(".g.i.cs"))
                {
                    if (FileInfo.CreateFileObject(filePath) != null)
                    {
                        FileInfo file = FileInfo.CreateFileObject(filePath);
                        _files.Add(file);
                        if (file.ClassInterface.Equals(ClassInterfaceType.Class))
                        {
                            ClassInfo classInfo = ClassInfo.CreateClassInfoObject(filePath, file);
                            _classInfos.Add(classInfo);
                        }
                    }
                }
            }
            Console.WriteLine("END... Analyse ZipFile");

            Console.WriteLine("START... Writing Text Files");
            WriteAnalyseToTextFile();
            WriteClassInfoToTextFile();
            Console.WriteLine("END... Writing Text Files");
        }

        /// <summary>
        /// Extract ZipFile
        /// </summary>
        private void ExtractZipFile()
        {
            Directory.CreateDirectory(InputPath);
            ZipFile.ExtractToDirectory(ZipFilePath, InputPath);
        }

        /// <summary>
        /// Write FileInfo to TextFile
        /// </summary>
        private void WriteAnalyseToTextFile()
        {
            Directory.CreateDirectory(OutputPath);
            using (StreamWriter writer = File.CreateText(Path.Combine(OutputPath, _outputAnalyseFile)))
            {
                foreach (var item in _files)
                {
                    writer.WriteLine("-------------------");
                    writer.WriteLine(item.ToString());
                    writer.WriteLine("-------------------");
                }
            }
        }

        /// <summary>
        /// Write ClassInfo to TextFile
        /// </summary>
        private void WriteClassInfoToTextFile()
        {
            Directory.CreateDirectory(OutputPath);
            using (StreamWriter writer = File.CreateText(Path.Combine(OutputPath, _outputClassInfoFile)))
            {
                foreach (var classInfo in _classInfos)
                {
                    writer.WriteLine("-------------------");
                    writer.WriteLine(classInfo.ToString());
                    foreach (var ctor in classInfo.Constructors)
                    {
                        writer.WriteLine($"Constructor: {ctor}");
                    }
                    foreach (var usings in classInfo.UsingStatements)
                    {
                        writer.WriteLine($"UsingStatement: {usings}");
                    }
                    foreach (var methode in classInfo.Methodes)
                    {
                        writer.WriteLine($"Methode: {methode}");
                    }
                    foreach (var property in classInfo.Properties)
                    {
                        writer.WriteLine($"Properties: {property}");
                    }
                    //foreach (var var in classInfo.Variables)
                    //{
                    //    writer.WriteLine($"Variables: {var}");
                    //}
                    writer.WriteLine("-------------------");
                }
            }
        }

        #endregion Methods
    }
}