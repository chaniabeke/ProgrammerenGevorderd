using System.IO;

namespace FileIO.Models
{
    public class FileInfo
    {
        #region Properties

        public string FileName { get; set; }
        public ClassInterfaceType ClassInterface { get; set; }
        public string ClassInterfaceName { get; set; }
        public int ClassInterfaceCount { get; set; }
        public string NamespaceName { get; set; }
        public int CodeLinesCount { get; set; }

        #endregion Properties

        #region Constructors

        public FileInfo(string fileName, ClassInterfaceType classInterface, string classInterfaceName, int classInterfaceCount, string namespaceName, int codeLinesCount)
        {
            FileName = fileName;
            ClassInterface = classInterface;
            ClassInterfaceName = classInterfaceName;
            // if (classInterfaceCount > 1) throw new FileException("There can only be 1 class in a file.");
            ClassInterfaceCount = classInterfaceCount;
            NamespaceName = namespaceName;
            CodeLinesCount = codeLinesCount;
        }

        #endregion Constructors

        #region Methods

        public override string ToString()
        {
            return $"FileName: {FileName}\nType: {ClassInterface}\nName: {ClassInterfaceName}\nNamespace: {NamespaceName}\nLinesOfCode: {CodeLinesCount}";
        }

        /// <summary>
        /// Analyze CSFile and make FIleInfo object
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static FileInfo CreateFileObject(string path)
        {
            string[] result = Extensions.readLines(path);

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

        #endregion Methods
    }
}