using System.Collections.Generic;
using Newtonsoft.Json;
namespace Agnokasten
{
    public class Archive
    {
        private readonly List<Tag> _tagList = new List<Tag>(); //I bet choosing List is gonna bite my ass if this thing gets remotely bigger
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
}