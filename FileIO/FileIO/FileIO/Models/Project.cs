using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace FileIO.Models
{
    public class Project
    {
        #region Properties
        public string InputPath { get; set; }
        public string ZipFilePath { get; set; }
        public string OutputPath { get; set; }
        private string _outputTextFile;
        private readonly string _folderInput = "FileIO_Input";
        private readonly string _folderOutput = "FileIO_Results";
        private List<string> _csFilePaths = new List<string>();
        private List<FileInfo> _files = new List<FileInfo>();
        private List<ClassInfo> _classInfos = new List<ClassInfo>();
        #endregion

        #region Constructors
        public Project(string inputPath, string zipFilePath, string outputPath)
        {
            InputPath = inputPath + _folderInput;
            ZipFilePath = zipFilePath;
            OutputPath = outputPath + _folderOutput;
            _outputTextFile = "Analyse_" + Path.GetFileNameWithoutExtension(zipFilePath) + ".txt";
        }
        #endregion

        #region Methods
        public void Analyse()
        {
            ExtractZipFile();

            _csFilePaths = Directory.GetFiles(InputPath, "*.cs", SearchOption.AllDirectories).ToList();
            foreach (string filePath in _csFilePaths)
            {
                if (!filePath.Contains(".g.cs") && !filePath.Contains(".g.i.cs"))
                {
                    if (CreateFileObject(filePath) != null)
                    {
                        FileInfo file = CreateFileObject(filePath);
                        _files.Add(file);
                        if (file.ClassInterface.Equals(ClassInterfaceType.Class))
                        {
                            ClassInfo classInfo = CreateClassInfoObject(filePath, file);
                            _classInfos.Add(classInfo);
                        }
                    }
                }
            }
            WriteAnalyseToTextFile();

        }
        private void ExtractZipFile()
        {
            Directory.CreateDirectory(InputPath);
            ZipFile.ExtractToDirectory(ZipFilePath, InputPath);
        }
        private void WriteAnalyseToTextFile()
        {
            Directory.CreateDirectory(OutputPath);
            using (StreamWriter writer = File.CreateText(Path.Combine(OutputPath, _outputTextFile)))
            {
                foreach (var item in _files)
                {
                    writer.WriteLine("-------------------");
                    writer.WriteLine(item.ToString());
                    writer.WriteLine("-------------------");
                }
            }
        }
        private FileInfo CreateFileObject(string path)
        {
            string[] result = readLines(path);

            ClassInterfaceType classInterface = ClassInterfaceType.Geen;
            string classInterfaceName = "";
            string namespaceName = "";
            int codeLinesCount = 0;
            int classCount = 0;

            for (int index = 0; index < result.Length; index++)
            {
                if (result[index].Trim() != "")
                {
                    codeLinesCount++;
                    if (!result[index].Contains("//") && !result[index].Contains("///") && !result[index].Contains("#"))
                    {
                        if (result[index].Contains("namespace"))
                        {
                            string[] x = result[index].Split("namespace ");
                            namespaceName = x[1].Trim();
                        }
                        if (result[index].Contains("class"))
                        {
                            classCount++;
                            string[] x = result[index].Split("class ");
                            classInterfaceName = x[1].Trim();
                            classInterface = ClassInterfaceType.Class;
                        }
                        if (result[index].Contains("interface"))
                        {
                            classCount++;
                            string[] x = result[index].Split("interface ");
                            classInterfaceName = x[1].Trim();
                            classInterface = ClassInterfaceType.Interface;
                        }
                    }
                }
            }
            if (classInterface.Equals(ClassInterfaceType.Geen))
            {
                return null;
            }
            string fileName = Path.GetFileName(path);
            FileInfo file = new FileInfo(fileName, classInterface, classInterfaceName, classCount, namespaceName, codeLinesCount);
            return file;
        }
        private ClassInfo CreateClassInfoObject(string path, FileInfo fileInfo)
        {
            if (fileInfo.ClassInterfaceName.Contains(":"))
            {
                string[] inheritance = fileInfo.ClassInterfaceName.Split(":");
                fileInfo.ClassInterfaceName = inheritance[0];
                string parentClass = inheritance[1];
                ClassInfo classInfoWithParentClass = new ClassInfo(fileInfo, fileInfo.NamespaceName, fileInfo.ClassInterfaceName, parentClass);
                return classInfoWithParentClass;
            }
            ClassInfo classInfo = new ClassInfo(fileInfo, fileInfo.NamespaceName, fileInfo.ClassInterfaceName);
            return classInfo;
        }
        private string[] readLines(string path)
        {
            string[] result = null;
            using (StreamReader reader = new StreamReader(path))
            {
                result = reader.ReadAllLines().ToArray();
            }
            return result;
        }
        #endregion
    }
}
