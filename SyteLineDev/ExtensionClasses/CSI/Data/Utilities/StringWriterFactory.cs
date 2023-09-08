using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CSI.Data.Utilities
{
    public class StringWriterFactory
    {
        public StringWriter Create()
        {
            return new StringWriter();
        }
    }
}
