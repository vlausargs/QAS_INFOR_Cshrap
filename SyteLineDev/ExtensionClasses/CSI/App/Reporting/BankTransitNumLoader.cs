using CSI.Data.CRUD;
using CSI.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Reporting
{
    public class BankTransitNumLoader : IBankTransitNumLoader
    {
        public string GetBankTransitNumber(int? FeatureRS9231Active, ICollectionLoadResponse po_crsLoadResponseForCursor, int po_crs_CursorCounter)
        {
            string BankTransitNum;
            if (FeatureRS9231Active == 0)
            {
                BankTransitNum = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(36);
            }
            else
            {
                string OverrideBankTransitNum = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(45);
                if (OverrideBankTransitNum == "0")
                {
                    BankTransitNum = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(36);
                }
                else
                {
                    BankTransitNum = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(44);
                }
            }

            return BankTransitNum;
        }
    }
}
