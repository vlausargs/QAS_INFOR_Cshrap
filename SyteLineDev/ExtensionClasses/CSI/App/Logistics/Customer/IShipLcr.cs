//PROJECT NAME: Logistics
//CLASS NAME: IShipLcr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface IShipLcr
    {
        (int? ReturnCode, string PromptMsg,
        string PromptButtons,
        string Infobar) ShipLcrSp(string PCoNum,
        DateTime? PTransDate,
        string PMText,
        string PromptMsg,
        string PromptButtons,
        string Infobar);
    }
}

