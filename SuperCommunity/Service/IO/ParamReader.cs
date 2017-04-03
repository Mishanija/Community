
using System.IO;

namespace SuperCommunity.Service.IO
{
    public class ParamReader
    {
        private readonly string _pathToFile;

        public ParamReader(string pathToFile)
        {
            _pathToFile = pathToFile;
        }

        public string ReadParam()
        {
            try
            {
                TextReader reader = new StreamReader(_pathToFile);

                string result = reader.ReadLine();

                reader.Close();

                return result.Trim();
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }
    }
}