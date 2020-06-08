using System.Collections.Generic;

namespace Agnokasten
{
    public class TexTemplateGenerator
    {
        public Tag thisTag = new Tag();
        public Persistance persistance;

        private string _zettRoot;
        private string _newZettName;
        private string _templateFileName;
        //worthless code that should be swaped for a proper cli parser l8r
        private List<string> _groups;
        public TexTemplateGenerator(string zettRoot, string templateFileName, string newZettName, List<string> groups)
        {
            _zettRoot = zettRoot;
            _templateFileName = templateFileName;
            _newZettName = newZettName;
            _groups = groups;
        }

        //uses the tag generated in the thisTag object to generate a headfile for the .tex document
        public string GenerateAppendableTag()
        {
            string tagToPrepend = @"\newcommand{\thisTag}";
            return tagToPrepend + "{" + thisTag.ToString() + "_" + _newZettName + "}";
        }

        public void GenerateNewZettFile()
        {
            var destFileName = thisTag.ToString() + "_" + _newZettName + ".tex";
            persistance = new Persistance(_zettRoot, _templateFileName, destFileName);
            persistance.CopyFile(GenerateAppendableTag());
        }
    }
}