using System;
using System.IO;

// --------- Счетчик ---------
                    
namespace SuperCommunity.Service.IO
{
    public class Counter
    {
        private static string _textFile;
        private static int _startValue;

        private int _counter;
        private readonly ParamReader _paramReader;

        public Counter(string fileName)
            : this(fileName, 1000)
        {
        }

        public Counter(string fileName, int startValue)
        {
            _textFile = AppDomain.CurrentDomain.BaseDirectory + fileName;
            
            _paramReader = new ParamReader(_textFile);

            _startValue = startValue;
        }

        public int GetNumber()
        {
            try
            {
                _counter = Convert.ToInt32(_paramReader.ReadParam());
            }
            catch (FileNotFoundException)
            {
                CreateCounterFile();
            }
            File.WriteAllText(_textFile, ++_counter + "");
            return _counter;
        }

        private void CreateCounterFile()
        {
            Directory.CreateDirectory(_textFile);
            _counter = _startValue;
        }

    }
}

