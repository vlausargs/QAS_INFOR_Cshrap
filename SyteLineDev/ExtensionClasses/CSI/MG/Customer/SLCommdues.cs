//PROJECT NAME: CustomerExt
//CLASS NAME: SLCommdues.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLCommdues")]
    public class SLCommdues : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetBillTypeSp(string Invnum,
                                 ref string BillType)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetBillTypeExt = new GetBillTypeFactory().Create(appDb);

                int Severity = iGetBillTypeExt.GetBillTypeSp(Invnum,
                                                             ref BillType);

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ChCommSp(string StartSlsman,
		                          string EndSlsman,
		                          DateTime? StartDueDate,
		                          DateTime? EndDueDate,
		                          string StartInvoice,
		                          string EndInvoice,
		                          string OldStatus,
		                          string NewStatus,
		                          DateTime? PaymentDate,
		                          byte? ProcessUnpdComm,
		                          byte? DeleteComp,
		                          byte? PProcess,
		                          ref string Infobar,
		                          [Optional] short? StartDueDateOffset,
		                          [Optional] short? EndDueDateOffset,
		                          [Optional] short? PaymentDateOffset)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iChCommExt = new ChCommFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iChCommExt.ChCommSp(StartSlsman,
				                                 EndSlsman,
				                                 StartDueDate,
				                                 EndDueDate,
				                                 StartInvoice,
				                                 EndInvoice,
				                                 OldStatus,
				                                 NewStatus,
				                                 PaymentDate,
				                                 ProcessUnpdComm,
				                                 DeleteComp,
				                                 PProcess,
				                                 Infobar,
				                                 StartDueDateOffset,
				                                 EndDueDateOffset,
				                                 PaymentDateOffset);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}
    }
}
