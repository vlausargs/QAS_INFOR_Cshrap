//PROJECT NAME: Material
//CLASS NAME: IValidateCoRsvdQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
    public interface IValidateCoRsvdQty
    {
            (int? ReturnCode,
            string PromptMsg,
            string PromptButtons,
            string Infobar) 
        ValidateCoRsvdQtySp(string PCoNum,
            int? PCoLine,
            int? PCoRelease,
            decimal? PQtyRsvd,
            decimal? PQtyRsvdOld,
            string PromptMsg,
            string PromptButtons,
            string Infobar);
    }
}

