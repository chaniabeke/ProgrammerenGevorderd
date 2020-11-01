using System.Collections.Generic;

namespace FileIO.Models
{
    public class ClassInfo
    {
        #region Properties
        public FileInfo FileInfo { get; set; }
        public string NamespaceName { get; set; }
        public string ClassName { get; set; }
        public string ParentClass { get; set; }
        public List<string> Constructors = new List<string>();
        public List<string> UsingStatements = new List<string>();
        public List<string> Methodes = new List<string>();
        public List<string> Properties = new List<string>();
        public List<string> Variables = new List<string>();
        #endregion

        #region Constructors
        public ClassInfo(FileInfo fileInfo, string namespaceName, string className, string parentClass)
        {
            FileInfo = fileInfo;
            NamespaceName = namespaceName;
            ClassName = className;
            ParentClass = parentClass;
        }
        public ClassInfo(FileInfo fileInfo, string namespaceName, string className)
        {
            FileInfo = fileInfo;
            NamespaceName = namespaceName;
            ClassName = className;
        }
        #endregion 

    }
}