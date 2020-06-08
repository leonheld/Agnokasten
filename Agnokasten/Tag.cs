using System;

namespace Agnokasten
{
    public class Tag
    {
        public DateTime tagDate;
        static private string format = "yyyyMMdHHmm";

        public Tag()
        {
            GeneratedTag();
        }
        public void GeneratedTag()
        {
            //Anno yyyy; month MM; day d; hour HH mm;
            this.tagDate = DateTime.Now;
            //tag = DateTime.Now.ToString(format);
        }

        public override string ToString()
        {
            return tagDate.ToString(format);
        }
    }
}
