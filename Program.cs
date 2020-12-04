using Podstawowe;
using System;

namespace Zadanie4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Copier xpo = new Copier();
            
            IDocument doc = new PDFDocument("jakis.pdf");
            IDocument doc2 = new PDFDocument("jakis.pdf");
            xpo.Scan(out doc);
            xpo.Scan(out doc2);

        }
    }
}
