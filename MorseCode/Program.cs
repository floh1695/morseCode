using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCode
{
    class Program
    {
        static void HelpMessage()
        {
            Console.WriteLine("help   : displays this help message");
            Console.WriteLine("encode : transcribe message into morse code");
            //Console.WriteLine("decode : transcribe message from morse code"); // TODO: Re-add this after completing @decode
            Console.WriteLine("exit   : exit menu, ends program");
        }

        static void Encode(IDictionary<string, string> code)
        {
            Console.WriteLine("Write a word to decode");
            Console.Write("encode: ");
            var phrase = Console.ReadLine().ToUpper();
            var encodedPhrase = String.Join("   ", phrase
                .Split(' ')
                .Select((string word) =>
                {
                    return String.Join(" ", word
                        .ToCharArray()
                        .Select((char c) =>
                        {
                            return code[c.ToString()];
                        }));
                }));
            Console.WriteLine(encodedPhrase);
        }

        static void Decode(IDictionary<string, string> code)
        {
            // TODO: @decode: implement this
            throw new NotImplementedException();
        }

        static void Main(string[] args)
        {
            var morseCode = new Dictionary<string, string>();
            using (var reader = new StreamReader("../../morse.csv"))
            {
                while (reader.Peek() > -1)
                {
                    var line = reader.ReadLine().Split(',');
                    morseCode.Add(line[0], line[1]);
                }
            }
            HelpMessage();
            while (true)
            {
                Console.Write("> ");
                var input = Console.ReadLine().ToLower();
                if (input == "") { continue; }
                else if (input == "exit") { break; }
                else if (input == "help") { HelpMessage(); }
                else if (input == "encode") { Encode(morseCode); }
                else if (input == "decode") { Decode(morseCode); }
                else
                {
                    Console.WriteLine($"\"{input}\" is not a valid command");
                }
            }
        }
    }
}
