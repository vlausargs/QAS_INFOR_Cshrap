using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.CRUD.Reporting
{
    public interface IRpt_VouchersPayableSubCRUD
    {
        ICollectionLoadRequest GetPovchCrsLoadRequestForCursor(DateTime? CutoffDate);
        ICollectionLoadRequest GetSiteGroupCrsLoadRequestForCursor(string siteGroup, string siteRef);
        (string PoVchType, decimal? PoVchItemCost, decimal? PoVchExchRate, decimal? PoVchQtyReceived, decimal? PoVchQtyReturned, decimal? PoVchQtyVouchered, DateTime? PoVchRcvdDate, int? PoVchDateSeq, string PoVchGrnNum, string PoVchPackNum) SetValues(IRecordReadOnly PovchCrsLoadResponseForCursor);
    }
}
