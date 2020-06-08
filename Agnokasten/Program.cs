using System.Collections.Generic;

namespace Agnokasten
{
    public class Archive
    {
        private readonly List<Tag> _tagList = new List<Tag>(); //I bet choosing List is gonna bite my ass if this thing gets remotely bigger
        public string 
        public void AddTagToList(Tag tagToAdd)
        {
            _tagList.Add(tagToAdd);
        }
        
        public void PrintAllTags()
        {
            foreach (var tag in _tagList)
            {

            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var newZettName = args[0];
            var groups = new List<string>();
            //this parsing is garbage. for the love of god, add an actual well written parser later like
            //http://www.ndesk.org/doc/ndesk-options/NDesk.Options/OptionSet.html#T:NDesk.Options.OptionSet:Docs:Example:1


            for (int i = 1; i < args.Length; i++)
            {
                groups.Add(args[i]);
            }

            string zettRoot = @"c:\users\leon\documents";
            string templateFileName = "template.tex";

            //too many parameters on this constructor, maybe use a builder or a fluent pattern like SO/40264
            var template = new TexTemplateGenerator(zettRoot, templateFileName, newZettName, groups);
            template.GenerateNewZettFile();
            
        }
    }
}