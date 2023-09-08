//PROJECT NAME: Logistics
//CLASS NAME: IValidateCoLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface IValidateCoLine
    {
        (int? ReturnCode,
        string Infobar) ValidateCoLineSp(
            string CoNum,
            int? CoLine,
            string Infobar);
    }
}