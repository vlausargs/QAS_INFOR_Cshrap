//PROJECT NAME: Material
//CLASS NAME: IValidateSerailTrackedItemForContainer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
    public interface IValidateSerailTrackedItemForContainer
    {
        (int? ReturnCode, string Infobar) ValidateSerailTrackedItemForContainerSp(string PItem,
            string PContainerNum,
            string Infobar);
    }
}

