using CSI.Data.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Reporting
{
    public interface IBankTransitNumLoader
    {
        string GetBankTransitNumber(int? FeatureRS9231Active, ICollectionLoadResponse po_crsLoadResponseForCursor, int po_crs_CursorCounter);
    }
}
