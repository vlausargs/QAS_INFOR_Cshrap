//PROJECT NAME: Material
//CLASS NAME: IValidateNonInventoryItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
    public interface IValidateNonInventoryItem
    {
        (int? ReturnCode, string PromptMsg) ValidateNonInventoryItemSp(string item, string PromptMsg);
    }
}

