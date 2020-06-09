using System.Collections.Generic;
using Newtonsoft.Json;

namespace Agnokasten
{    
    public class Archive
    {
        private readonly List<Tag> _tagList = new List<Tag>(); //this list is gonna be reused for deserialize the JSON which will contain all the metadata about an existing Zettelkasten
        public void AddTagToList(Tag tagToAdd)
        {
            _tagList.Add(tagToAdd);
        }
        
        public string SerializeTagsToJson()
        {
            return JsonConvert.SerializeObject(_tagList, Formatting.Indented);
        }
    }
}