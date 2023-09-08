using PLLOC.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PLLOC.Objects
{
    public class RptVATFactory
    {
        public IRptVAT Create()
        {
            return new RptVAT();
        }
    }
}