using System.Collections.Generic;

namespace Agnokasten
{
    public class TexTemplateGenerator
    {
        public Tag thisTag = new Tag();
        
        private Archive thisArchive = new Archive();
        private Persistence newZettPersistence;
        private Persistence archivePersistence;

        private string jsonFilePath = @"./metadata/json";

        private string _zettRoot;
        private string _newZettName;
        private const string _generatedZettTexSources = @"generatedZettTexSources";
        private string _templateFileName;
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

        public void ArchiveGeneratedTag()
        {
            archivePersistence = new Persistence(jsonFilePath);
            
            thisArchive.AddTagToList(thisTag);
            var jsonToWrite = thisArchive.SerializeTagsToJson();

            //dá pra usar o append() pra colocar o novo json no começo
            archivePersistence.PrependText(jsonToWrite);
        }

        public void GenerateNewZettFile()
        {
            var destFileName = thisTag.ToString() + "_" + _newZettName + ".tex";
            newZettPersistence = new Persistence(_zettRoot, _templateFileName, _generatedZettTexSources, destFileName);
            newZettPersistence.CopyFile(GenerateAppendableTag());

            ArchiveGeneratedTag();
        }
    }
}