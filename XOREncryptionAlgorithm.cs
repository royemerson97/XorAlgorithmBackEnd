using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncryptionAPI
{
    public class XOREncryptionAlgorithm
    {
   
        public string EncryptDecrypt(string text, string key, string option)
        {
            string output;
            switch (option)
            {
                case "enc":
                    output = Encrypt(text, key);
                    break;
                case "dec":
                    output = Decrypt(text, key);
                    break;
                default:
                    output = "";
                    break;
            }
            return output;
            
        }

        public string Encrypt(string text, string key)
        {
            string[] output = new string [text.Length];
            int [] auxOutput = new int [text.Length];
            var keys = key.Distinct().ToArray();
        
            for (int i = 0; i < text.Length; i++)
            {
                auxOutput[i] = text[i] ^ keys[i % keys.Length];
            }
            
            for (int i = 0; i < auxOutput.Length; i++)
            {
                output[i] = auxOutput[i].ToString();
            }
            string finalOutput = "";
            for (int i = 0; i < output.Length; i++)
            {
                finalOutput += output[i];
                if (i!=output.Length-1)
                {
                    finalOutput += "*";
                }
            }
            return finalOutput;
        }

        public string Decrypt(string text, string key)
        {
            var data = text.Split('*');
            char[] output = new char[data.Length];
            int[] auxOutput = new int[data.Length];
            var keys = key.Distinct().ToArray();
            for (int i = 0; i < data.Length; i++)
            {
                auxOutput[i] =  int.Parse((data[i])) ^ keys[i % keys.Length];
            }
            
            for (int i = 0; i < auxOutput.LongLength; i++)
            {
                output[i] = (char)auxOutput[i];
            }
            return new string(output);
        }

        public void Initialize(int [] vector)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = 0;
            }
        }
    }
}
