using System.Collections.Generic;

namespace Agnokasten
{
    class Program
    {
        static void Main(string[] args)
        {
        /*
            var newZettName = args[0];
            var groups = new List<string>();
            //this parsing is garbage. for the love of god, add an actual well written parser later like
            //http://www.ndesk.org/doc/ndesk-options/NDesk.Options/OptionSet.html#T:NDesk.Options.OptionSet:Docs:Example:1


            for (int i = 1; i < args.Length; i++)
            {
                groups.Add(args[i]);
            }
        */
            string newZettName = "newZettName";
            var groups = new List<string> {"group1", "group2"};

            string zettRoot = @"./metadata";
            string templateFileName = "template.tex";

            //too many parameters on this constructor, maybe use a builder or a fluent pattern like SO/40264
            var template = new TexTemplateGenerator(zettRoot, templateFileName, newZettName, groups);
            template.GenerateNewZettFile();
            
        }
    }
}