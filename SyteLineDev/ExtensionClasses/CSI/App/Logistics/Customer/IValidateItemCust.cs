//PROJECT NAME: Logistics
//CLASS NAME: IValidateItemCust.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface IValidateItemCust
    {
            (int? ReturnCode,
            string NewItem,
            int? ItemCustExists,
            int? ItemCustUpdate,
            int? ItemCustAdd,
            string WarningMsg,
            string PromptMsg,
            string PromptButtons,
            string Infobar) 
        ValidateItemCustSp(
            string CustNum,
            string CustItem,
            string Item,
            string NewItem,
            int? ItemCustExists,
            int? ItemCustUpdate,
            int? ItemCustAdd,
            string WarningMsg,
            string PromptMsg,
            string PromptButtons,
            string Infobar);
    }
}

