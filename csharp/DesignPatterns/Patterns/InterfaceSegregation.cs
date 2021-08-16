using System;
using System.Collections.Generic;
using System.IO;

namespace Patterns
{
   public class Document
    {

    }

    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }

    public class MultiFunctionPrinter : IMachine
    {
        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }

        public void Print(Document d)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }
    }

    public class OldFashionedPrinter : IMachine // this violates interface segregation principle! create a more granular, atomic interfaces
    {
        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }

        public void Print(Document d)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }
    }

    public interface IPrinter
    {
        void Print(Document d);
    }

    public interface IScanner
    {
        void Scan(Document d);
    }

    public class Photocopier : IPrinter, IScanner
    {
        public void Print(Document d)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }
    }

    public interface IFax
    {
        void Fax(Document d);
    }
    public interface IMultiFunctionDevice : IPrinter, IScanner, IFax
    {

    }

    public class MultiFunctionMachine : IMultiFunctionDevice
    {
        private IPrinter printer;
        private IScanner scanner;
        private IFax fax;
        public MultiFunctionMachine(IPrinter printer, IScanner scanner, IFax fax)
        {
            if (printer == null)
            {
                throw new ArgumentNullException(paramName: nameof(printer));
            }
            if (scanner == null)
            {
                throw new ArgumentNullException(paramName: nameof(scanner));
            }    
            if (fax == null)
            {
                throw new ArgumentNullException(paramName: nameof(fax));

            }
            this.printer = printer;
            this.scanner = scanner;
            this.fax = fax;
        }

        //classic decorator pattern
        public void Fax(Document d)
        {
            this.fax.Fax(d);
        }

        public void Print(Document d)
        {
            this.printer.Print(d);
        }

        public void Scan(Document d)
        {
            this.scanner.Scan(d);
        }
    }
}
