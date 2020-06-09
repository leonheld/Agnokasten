using System.IO;

namespace Agnokasten
{
    //All of IO goes here
    public class Persistance
    {
        private readonly string _templateFilePath;
        private readonly string _destFilePath;

        public Persistance(string zettRoot, string templateFileName, string generatedZettTexSources, string destFileName)
        {
            _templateFilePath = Path.Combine(zettRoot, templateFileName);
            _destFilePath = Path.Combine(zettRoot, generatedZettTexSources, destFileName);
        }

        public Persistance(string destFileName)
        {
            _destFilePath = destFileName;
        }

        //should be able to receive ANYTHING and call .ToString on it
        public void WriteFile(object obj, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, obj.ToString());
        }

        public void PrependText(string prependant)
        {
            var tempfile = Path.GetTempFileName();
            using (var writer = new StreamWriter(tempfile))
            using (var reader = new StreamReader(_destFilePath))
            {
                writer.WriteLine(prependant);
                while (!reader.EndOfStream)
                    writer.WriteLine(reader.ReadLine());
            }
            File.Copy(tempfile, _destFilePath, true);
            File.Delete(tempfile);
        }

        public void CopyFile(string tagToAdd)
        {
            File.Copy(_templateFilePath, _destFilePath, false);
            PrependText(tagToAdd);
        }
    }
}