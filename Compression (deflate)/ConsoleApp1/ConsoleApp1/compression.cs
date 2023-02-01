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

        public static void CompressFile_deflate()
        {
            //1.
            //read a ready file
            //var file = new FileStream(@"C:\Users\orash\Desktop\files_compression\t.txt", FileMode.Open, FileAccess.Read);
            
            ////compressed
            //var deflate_compress = new DeflateStream(file, CompressionMode.Compress);

            ////save file in new file
            //FileStream outputfile = File.Create(@"C:\Users\orash\Desktop\files_compression\name-newfile.txt");
            //deflate_compress.CopyTo(outputfile);


            //2. 
            //create a file with 10000 lines
            StringBuilder data = new StringBuilder();

            for (int i = 1; i < 10001; i++)
            {
                data.AppendLine(string.Format("{0}\tCompress", i));
            }

            var stream_deflate = new FileStream(@"C:\Users\orash\Desktop\files_compression\compressfiledeflate.txt", FileMode.Create, FileAccess.Write);
            var deflate = new DeflateStream(stream_deflate, CompressionMode.Compress);
            var write_deflate = new StreamWriter(deflate);

            write_deflate.Write(data.ToString());
            write_deflate.Close();
            Console.Write("test deflate!");
        }


        public static void DecompressFile_deflate()
        {
            //read file
            var file = new FileStream(@"C:\Users\orash\Desktop\files_compression\t.txt", FileMode.Open, FileAccess.Read);
            
            //decompressed
            var deflate_decompress = new DeflateStream(file, CompressionMode.Decompress);

            //save result to new file
            FileStream outputFileStream = File.Create(@"C:\Users\orash\Desktop\files_compression\newfile.txt");
            deflate_decompress.CopyTo(outputFileStream);
        }


        public static void CompressFile_Gzip()
        {           
            var stream_gzip = new FileStream(@"C:\Users\orash\Desktop\files_compression\compressfilegzip.txt", FileMode.Create, FileAccess.Write);
            var gzip = new GZipStream(stream_gzip, CompressionMode.Compress);
            var writer_gzip = new StreamWriter(gzip);

            //writer_gzip.Write(data.ToString());
            writer_gzip.Close();

            Console.WriteLine("test gzip!");
        }


        public static void DecompressFile_Gzip()
        {
            //read file compressed
            var file = new FileStream(@"C:\Users\orash\Desktop\files_compression\anme.txt", FileMode.Open, FileAccess.Read);

            //decompressed
            var gzip_decompressed = new GZipStream(file, CompressionMode.Decompress);

            //save result in file
            var output = File.Create(@"C:\Users\orash\Desktop\files_compression\newfile.txt");
            gzip_decompressed.CopyTo(output);   
        }


        public static void CompressGzipToDeflate()
        {
            StringBuilder data = new StringBuilder();

            for (int i = 1; i < 10001; i++)
            {
                data.AppendLine(string.Format("{0}\tCompress", i));
            }

            //1.Gzip raw File
            var stream_deflate = new FileStream(@"C:\Users\orash\Desktop\files_compression\1gzip.txt", FileMode.Create, FileAccess.Write);
            var gzip = new GZipStream(stream_deflate, CompressionMode.Compress);
            var write_gzip = new StreamWriter(gzip);

            write_gzip.Write(data.ToString());  //final res = write_gzip
            write_gzip.Close();
            Console.Write("convert to gzip!");

            //2.Deflate Gzip file
            var stream_deflate2 = new FileStream(@"C:\Users\orash\Desktop\files_compression\2deflate.txt", FileMode.Create, FileAccess.Write);
            var deflate = new DeflateStream(stream_deflate2, CompressionMode.Compress);
            var write_deflate = new StreamWriter(deflate);

            write_deflate.Write(write_gzip.ToString());
            write_deflate.Close();
            Console.Write("\nconvert to deflate!");
        }


        //public static void Decompress_Gzip_Deflate()
        //{
        //    //read file compressed
        //    var file = new FileStream(@"C:\Users\orash\Desktop\files_compression\2deflate.txt", FileMode.Open, FileAccess.Read);

        //    //decompressed
        //    var deflate_decompressed = new DeflateStream(file, CompressionMode.Decompress);

        //    //save result in file
        //    var output = File.Create(@"C:\Users\orash\Desktop\files_compression\decompress_2deflate.txt");
        //    deflate_decompressed.CopyTo(output);
        //}
    }
}
