using System;
using static Podstawowe.IDevice;

namespace Podstawowe
{
    public interface IDevice
    {
       // private int counter;

        enum State { on, off, standby };
        State state { get; set; }

        public IDevice.State GetState() => state;
        abstract protected void SetState(State state);
        //int Counter { get; }  // zwraca liczbę charakteryzującą eksploatację urządzenia,
        public int Counter { get; }         // np. liczbę uruchomień, liczbę wydrukow, liczbę skanów, ...
        public void PowerOff()
        {
            state = State.off;
            SetState(State.off);
            Console.WriteLine("... Device is off !");
        }

        public void PowerOn()
        {
            state = State.on;
            SetState(State.on);
            Console.WriteLine("Device is on ...");
        }

        public void StandbyOn()
        {
            state = State.standby;
            SetState(State.standby);
            Console.WriteLine("Device is on standby ...");
        }

        public void StandByOff()
        {
            state = State.on;
            SetState(State.on);
            throw new NotImplementedException();
        }



    }

    //public abstract class BaseDevice : IDevice
    //{
    //    protected IDevice.State state = IDevice.State.off;
    //    public IDevice.State GetState() => state;
    //    abstract protected void SetState(State state);
    //    public void PowerOff()
    //    {
    //        state = IDevice.State.off;
    //        SetState(state);
    //        Console.WriteLine("... Device is off !");
    //    }

    //    public void PowerOn()
    //    {
    //        state = IDevice.State.on;
    //        SetState(state);
    //        Console.WriteLine("Device is on ...");
    //    }

    //    public void StandbyOn()
    //    {
    //        state = IDevice.State.standby;
    //        SetState(state);
    //        Console.WriteLine("Device is on ...");
    //    }

    //    public void StandByOff()
    //    {
    //        state = IDevice.State.on;
    //        SetState(state);
    //        throw new NotImplementedException();
    //    }

    //    public int Counter { get; private set; } = 0;


    //}

    public interface IPrinter : IDevice
    {
        
            
        /// <summary>
        /// Dokument jest drukowany, jeśli urządzenie włączone.W przeciwnym przypadku nic się nie wykonuje
        /// </summary>
        /// <param name = "document" > obiekt typu IDocument, różny od `null`</param>
        void Print(in IDocument document);
    }

    public interface IScanner : IDevice
    {
        //dokument jest skanowany, jeśli urządzenie włączone
        //w przeciwnym przypadku nic się dzieje
        void Scan(out IDocument document, IDocument.FormatType formatType);
    }

    
}