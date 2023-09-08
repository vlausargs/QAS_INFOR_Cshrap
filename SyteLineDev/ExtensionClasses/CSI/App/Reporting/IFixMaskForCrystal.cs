//PROJECT NAME: Reporting
//CLASS NAME: IFixMaskForCrystal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
    public interface IFixMaskForCrystal
    {
        string FixMaskForCrystalFn(string QtyFormat,
        string Grouping);
    }
}

