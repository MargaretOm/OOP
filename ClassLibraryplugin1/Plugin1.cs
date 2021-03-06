﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;
using ClassLibrary1;

namespace ClassLibraryplugin1
{
    public class Plugin1 : Class1 // Целевой класс
{
    public string Name { get; } = "GZip";

    public string Format { get; } = ".gz";

    // Объект адаптируемого класса
    private GZipStream gzip;

    public Plugin1() { }

    public void Compress(string inputFile, string outputFile)
    {
        using (FileStream input = File.OpenRead(inputFile))
        using (FileStream output = File.Create(outputFile))
        using (gzip = new GZipStream(output, CompressionMode.Compress))
        {
            input.CopyTo(gzip);
        }
    }

    public void Decompress(string inputFile, string outputFile)
    {
        using (FileStream input = File.OpenRead(inputFile))
        using (FileStream output = File.Create(outputFile))
        using (gzip = new GZipStream(input, CompressionMode.Decompress))
        {
            gzip.CopyTo(output);
        }
    }
}

}
