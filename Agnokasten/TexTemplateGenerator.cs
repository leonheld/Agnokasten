using System.Collections.Generic;

namespace Agnokasten
{
    public class TexTemplateGenerator
    {
        public Tag thisTag = new Tag();
        
        private Archive thisArchive = new Archive();
        private Persistance newZettPersistance;
        private Persistance archivePersistance;

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
            archivePersistance = new Persistance(jsonFilePath);
            
            thisArchive.AddTagToList(thisTag);
            var jsonToWrite = thisArchive.SerializeTagsToJson();

            archivePersistance.WriteFile(jsonToWrite, jsonFilePath);
        }

        public void GenerateNewZettFile()
        {
            var destFileName = thisTag.ToString() + "_" + _newZettName + ".tex";
            newZettPersistance = new Persistance(_zettRoot, _templateFileName, _generatedZettTexSources, destFileName);
            newZettPersistance.CopyFile(GenerateAppendableTag());

            ArchiveGeneratedTag();
        }
    }
}