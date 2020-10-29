using System.Collections.Generic;

namespace FileIO.Models
{
    public class ClassInfo
    {
        public string Namespace { get; set; }
        public string ClassName { get; set; }
        private List<string> _constructors;
        private List<string> _usingStatements;
        private List<string> _methodes;
        private List<string> _properties;
        private List<string> _variables;
        public string ParentClass { get; set; }
    }
}