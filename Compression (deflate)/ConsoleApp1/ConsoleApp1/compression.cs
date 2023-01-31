using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace ConsoleApp1
{
    public class compression
    {

        static void Main(string[] args)
        { 
            StringBuilder data = new StringBuilder();


            for (int i = 1; i < 10001; i++)
            {
                data.AppendLine(string.Format("{0}\tCompress", i));
            }

            try
            {
                FileStream stream = new FileStream(@"C:\Users\orash\Desktop\compress.txt", FileMode.Create, FileAccess.Write);

                StreamWriter writer = new StreamWriter(stream);

                writer.Write(data.ToString());
                writer.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }

        }


    }
}
