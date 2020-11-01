using FileIO.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileIO.Models
{
    public class FileInfo
    {
        public string FileName { get; set; }
        public ClassInterfaceType ClassInterface { get; set; }
        public string ClassInterfaceName {get; set;}
        public int ClassInterfaceCount { get; set; }
        public string NamespaceName { get; set; }
        public int CodeLinesCount { get; set; }

        public FileInfo(string fileName, ClassInterfaceType classInterface, string classInterfaceName, int classInterfaceCount, string namespaceName, int codeLinesCount)
        {
            FileName = fileName;
            ClassInterface = classInterface;
            ClassInterfaceName = classInterfaceName;
            if (classInterfaceCount > 1) throw new FileException("There can only be 1 class in a file.");
            ClassInterfaceCount = classInterfaceCount;
            NamespaceName = namespaceName;
            CodeLinesCount = codeLinesCount;
        }

        public override string ToString()
        {
            return $"FileName: {FileName}\nType: {ClassInterface}\nName: {ClassInterfaceName}\nNamespace: {NamespaceName}\nLinesOfCode: {CodeLinesCount}";
        }
    }
}
