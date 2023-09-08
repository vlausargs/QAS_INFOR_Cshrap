//PROJECT NAME: CustomerExt
//CLASS NAME: SLInvBatchDetails.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLInvBatchDetails")]
    public class SLInvBatchDetails : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CustomerDueDateSp(string CustNum,
                                     DateTime? CloseDate,
                                     ref DateTime? DueDate)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCustomerDueDateExt = new CustomerDueDateFactory().Create(appDb);

                int Severity = iCustomerDueDateExt.CustomerDueDateSp(CustNum,
                                                                     CloseDate,
                                                                     ref DueDate);

                return Severity;
            }
        }
    }
}
