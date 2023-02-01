using ConsoleApp1;
using Microsoft.VisualBasic;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Text;

public class Program 
{
    private readonly compression _compressionclass;

    public Program(compression compression)
    {
        _compressionclass = compression;
    }
   

    private static void Main(string[] args)
    {
        //made a new file
        StringBuilder data = new StringBuilder();

        for (int i = 1; i < 10001; i++)
        {
            data.AppendLine(string.Format("{0}\tCompress", i));
        }       

        try
        {
            #region 'make uncompress'
            //uncompress----------------------------------
            //FileStream stream = new FileStream(@"C:\Users\orash\Desktop\files_compression\compress.txt", FileMode.Create, FileAccess.Write);
            //StreamWriter writer = new StreamWriter(stream);

            //writer.Write(data.ToString());
            //writer.Close();

            //Console.Write("test");
            #endregion 'uncompress'

            #region 'gzip'
            ////Gzip--------------------------------------
            //var stream_gzip = new FileStream(@"C:\Users\orash\Desktop\files_compression\compressfilegzip.txt", FileMode.Create, FileAccess.Write);
            //var gzip = new GZipStream(stream_gzip, CompressionMode.Compress);
            //var writer_gzip = new StreamWriter(gzip);

            //writer_gzip.Write(data.ToString());
            //writer_gzip.Close();

            //Console.WriteLine("test gzip!");
            #endregion 'gzip'

            #region 'deflate'
            //deflate-----------------------------------------
            //StreamReader file_deflate = new StreamReader("C:/Users/orash/Desktop/files_compression/t.txt");

            //var stream_deflate = new FileStream(@"C:\Users\orash\Desktop\files_compression\t2-t.txt", FileMode.Create, FileAccess.Write);
            //var deflate = new DeflateStream(stream_deflate, CompressionLevel.NoCompression);
            //var write_deflate = new StreamWriter(deflate);

            //write_deflate.Write(data.ToString());
            //write_deflate.Close();

            //Console.Write("test deflate!");
            #endregion

            #region 'second deflate'
            //second deflate -----------------------------------------

            //StreamReader file_deflate = new StreamReader("C:/Users/orash/Desktop/compressfiledeflate.txt");

            //var stream_deflate = new FileStream(@"C:\Users\orash\Desktop\compressfiledeflatesecond.txt", FileMode.Create, FileAccess.Write);
            //var deflate = new DeflateStream(stream_deflate, CompressionMode.Compress);
            //var write_deflate = new StreamWriter(deflate);

            //write_deflate.Write(file_deflate.ToString());
            //write_deflate.Close();

            //Console.WriteLine("test deflate2!");
            #endregion 'second deflate'

            #region 'decompress first deflate'
            //decompress second-deflate 1:0 -------------------------------

            //var file = new FileStream(@"C:\Users\orash\Desktop\files_compression\t2.txt", FileMode.Open, FileAccess.Read);

            ////decompressed
            //var deflate_decompress = new DeflateStream(file, CompressionMode.Decompress);

            ////save result to new file
            //FileStream outputFileStream = File.Create(@"C:\Users\orash\Desktop\files_compression\decomp-t2.txt");
            //deflate_decompress.CopyTo(outputFileStream);
            //Console.Write(outputFileStream);

            #endregion 'decompress first deflate'

            #region 'decompress 2 deflate'
            //decompress second deflate to first deflate------------------
            //var stream2 = new FileStream(@"C:\Users\orash\Desktop\files_compression\compressfiledeflatesecond.txt", FileMode.Open, FileAccess.Read);
            //var deflate_stream2 = new DeflateStream(stream2, CompressionMode.Decompress);

            /////save to new 
            //FileStream outputFileStream = File.Create(@"C:\Users\orash\Desktop\files_compression\test2.txt");
            //deflate_stream2.CopyTo(outputFileStream);


            //FileStream compressedFileStream = File.Open(CompressedFileName, FileMode.Open);
            //FileStream outputFileStream = File.Create(@"C:\Users\orash\Desktop\files_compression\test.txt");
            //var decompressor = new DeflateStream(compressedFileStream, CompressionMode.Decompress);
            //decompressor.CopyTo(outputFileStream);
            #endregion 'decompress 2 deflate'
           
            #region 'three level compressing'
            // compress a file to gzip then covert it to deflate 
            //1.
            var stream_deflate = new FileStream(@"C:\Users\orash\Desktop\files_compression\1gzip.txt", FileMode.Create, FileAccess.Write);
            var gzip = new GZipStream(stream_deflate, CompressionMode.Compress);
            var write_gzip = new StreamWriter(gzip);

            write_gzip.Write(data.ToString());
            write_gzip.Close();
            Console.Write("convert to gzip!");

            //2.
            var stream_deflate2 = new FileStream(@"C:\Users\orash\Desktop\files_compression\2deflate.txt", FileMode.Create, FileAccess.Write);
            var deflate = new DeflateStream(stream_deflate2, CompressionMode.Compress);
            var write_deflate = new StreamWriter(deflate);

            write_deflate.Write(write_gzip.ToString());
            write_deflate.Close();
            Console.Write("\nconvert to deflate!");


            //3. it didn't decrease
            //StreamReader file_deflate = new StreamReader("C:/Users/orash/Desktop/2deflate.txt");
            var stream_deflate4 = new FileStream(@"C:\Users\orash\Desktop\files_compression\31gzip.txt", FileMode.Create, FileAccess.Write);
            var gzip4 = new GZipStream(stream_deflate4, CompressionMode.Compress);
            var write_gzip4 = new StreamWriter(gzip4);

            write_gzip4.Write(write_deflate.ToString());
            write_gzip4.Close();
            Console.Write("convert to gzip!");
            #endregion 'three level compressing'

        }
        catch (IOException ex)
        {
            Console.WriteLine("Error" + ex.Message);
        }
    }
}
