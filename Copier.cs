using System;
using System.Collections.Generic;
using System.Text;
using Podstawowe;


namespace Zadanie4
{
    public class Copier :  IScanner, IPrinter
    {
        IDevice.State IDevice.state { get;  set; }
        private int printCounter = 0;
        private int scanCounter = 0;
        private int counter = 0;
        IDevice.State state;

        //liczba wydrukowanych dokumentow
        public int PrintCounter => printCounter;
        //liczba zeskanowanych dokumentow
        public int ScanCounter => scanCounter;
        public int Counter => counter;
        //private IDevice.State SetState => this.state = state;

        void IDevice.SetState(IDevice.State state)
        {
            this.state = state;
        }

        //void IDevice.PowerOn()
        //{
        //    throw new NotImplementedException();
        //}

        //referencja
        public void Print(in IDocument document)
        {
            if (state== IDevice.State.off)
            {
                return;
            }
          
            Console.WriteLine(DateTime.Now + "Print: " + document.GetFileName());

            printCounter += 1;
            if (printCounter == 3)
            {
                state = IDevice.State.standby;
            }
        }

       



        //referencja
        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            if (state == IDevice.State.off)
            {
                document = null;
                return;
            }
            switch (formatType)
            {
                case IDocument.FormatType.JPG:
                    document = new ImageDocument($"ImageScan{ScanCounter}.jpg");

                    break;
                case IDocument.FormatType.PDF:
                    document = new PDFDocument($"PDFScan{ScanCounter}.pdf");
                    break;
                default:
                    document = new TextDocument($"TextScan{ScanCounter}.txt");
                    break;

            }
            Console.WriteLine(DateTime.Now + "Scan: " + document.GetFileName());
            scanCounter += 1;
        }
        public void ScanAndPrint()
        {
            IDocument document;
            Scan(out document, IDocument.FormatType.JPG);
            Print(document);

        }
        //liczba uruchomien drukarki
        //public int Counter { get; set; }
       // public IDevice.State state { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
       // int IDevice.Counter { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
       

        public new void PowerOn()
        {
            if (state == IDevice.State.on)
                return;
            PowerOn();
            counter += 1;
        }

       
    }
}
