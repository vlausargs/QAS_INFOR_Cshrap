//PROJECT NAME: Logistics
//CLASS NAME: IGetLabelFilename.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface IGetLabelFilename
    {
        (int? ReturnCode,
        string Filename) GetLabelFilenameSp(
            string TemplateName,
            string Filename);
    }
}

