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
        //public List<string> Variables = new List<string>();

        #endregion Properties

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

        #endregion Constructors

        #region Methods

        public override string ToString()
        {
            return $"FileName: {FileInfo.FileName}\nNamespace: {NamespaceName}\nParentClass: {ParentClass}\nClassName: {ClassName}";
        }

        /// <summary>
        /// Analyze CSFile and create a classinfo object
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        public static ClassInfo CreateClassInfoObject(string path, FileInfo fileInfo)
        {
            if (fileInfo.ClassInterfaceName.Contains(":"))
            {
                string[] inheritance = fileInfo.ClassInterfaceName.Split(":");
                fileInfo.ClassInterfaceName = inheritance[0];
                string parentClass = inheritance[1];
                ClassInfo classInfoWithParentClass = new ClassInfo(fileInfo, fileInfo.NamespaceName, fileInfo.ClassInterfaceName, parentClass);
                classInfoWithParentClass.AddLists(path);
                return classInfoWithParentClass;
            }
            ClassInfo classInfo = new ClassInfo(fileInfo, fileInfo.NamespaceName, fileInfo.ClassInterfaceName);
            classInfo.AddLists(path);
            return classInfo;
        }

        /// <summary>
        /// Add Constructors, Properties, Methods and UsingStatements To lists
        /// </summary>
        /// <param name="path"></param>
        private void AddLists(string path)
        {
            string[] result = Extensions.readLines(path);

            for (int index = 0; index < result.Length; index++)
            {
                if (result[index].Trim() != "")
                {
                    if (!result[index].Contains("//") && !result[index].Contains("///") && !result[index].Contains("#"))
                    {
                        if (result[index].Contains(ClassName) && !result[index].Contains("class")
                            && !result[index].Contains("static") && result[index].Contains("(")
                            &&
                            (result[index].Contains("public") || result[index].Contains("private")
                            || result[index].Contains("internal") || result[index].Contains("protected")))
                        {
                            string[] x = result[index].Split("(");
                            string constructor = x[0].Trim();
                            Constructors.Add(constructor);
                        }
                        if (result[index].Contains("using"))
                        {
                            string[] x = result[index].Split(";");
                            string usings = x[0].Trim();
                            UsingStatements.Add(usings);
                        }
                        if (!result[index].Contains(ClassName) && !result[index].Contains("using") &&
                            !result[index].Contains("get") && !result[index].Contains(";") &&
                            (result[index].Contains("public") || result[index].Contains("private")
                            || result[index].Contains("internal") || result[index].Contains("protected")))
                        {
                            string[] x = result[index].Split("(");
                            string method = x[0].Trim();
                            Methodes.Add(method);
                        }
                        if (result[index].Contains("get") && result[index].Contains("set"))
                        {
                            Properties.Add(result[index].TrimStart());
                        }
                    }
                }
            }
        }

        #endregion Methods
    }
}