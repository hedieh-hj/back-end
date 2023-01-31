using ConsoleApp1;
using Microsoft.VisualBasic;
using System.IO.Compression;
using System.Text;


StringBuilder data = new StringBuilder();

for (int i = 1; i < 10001; i++)
{
    data.AppendLine(string.Format("{0}\tCompress", i));
}

try
{
    #region 'make uncompress'
    //uncompress----------------------------------
    FileStream stream = new FileStream(@"C:\Users\orash\Desktop\compress.txt", FileMode.Create, FileAccess.Write);
    StreamWriter writer = new StreamWriter(stream);

    writer.Write(data.ToString());
    writer.Close();

    Console.Write("test");
    #endregion 'uncompress'

    #region 'gzip'
    //gzip--------------------------------------    
    var stream_gzip = new FileStream(@"C:\Users\orash\Desktop\compressfilegzip.txt", FileMode.Create, FileAccess.Write);
    var gzip = new GZipStream(stream_gzip, CompressionMode.Compress);
    var writer_gzip = new StreamWriter(gzip);

    writer_gzip.Write(data.ToString());
    writer_gzip.Close();

    Console.WriteLine("test gzip!");
    #endregion 'gzip'

    #region 'deflate'
    //deflate-----------------------------------------    
    var stream_deflate = new FileStream(@"C:\Users\orash\Desktop\compressfiledeflate.txt", FileMode.Create, FileAccess.Write);
    var deflate = new DeflateStream(stream_deflate, CompressionMode.Compress);
    var write_deflate = new StreamWriter(deflate);

    write_deflate.Write(data.ToString());
    write_deflate.Close();

    Console.Write("test deflate!");
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

    var stream_deflate_decomp = new FileStream(@"C:\Users\orash\Desktop\compressfiledeflate.txt", FileMode.Open, FileAccess.Read);
    var deflate_decompress = new DeflateStream(stream_deflate_decomp, CompressionMode.Decompress);
    var write_undeflate = new StreamReader(deflate_decompress);

    string decomp_second = write_undeflate.ReadToEnd();
    write_undeflate.Close();

    //save decomp_second in new file
    var fs = new FileStream(@"C:\Users\orash\Desktop\decomp1.txt", FileMode.Create);
    var w = new StreamWriter(fs, Encoding.UTF8);
    w.WriteLine(decomp_second);

    Console.Write(decomp_second);

    #endregion 'decompress first deflate'


}
catch (IOException ex)
{
    Console.WriteLine("Error" + ex.Message);
}
