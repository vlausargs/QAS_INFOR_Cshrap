using CSI.Production;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Production
{
    public class CopyCpVjFromSpFactory
    {
        public ICopyCpVjFrom Create()
        {
            return new CopyCpVjFrom();
        }
    }
}
