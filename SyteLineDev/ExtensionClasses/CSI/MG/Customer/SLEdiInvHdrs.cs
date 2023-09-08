//PROJECT NAME: CustomerExt
//CLASS NAME: SLEdiInvHdrs.cs

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
    [IDOExtensionClass("SLEdiInvHdrs")]
    public class SLEdiInvHdrs : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_RetransmitEDIInvoicesSp([Optional] string CustomerStarting,
                                                  [Optional] string CustomerEnding,
                                                  [Optional] string InvNumStarting,
                                                  [Optional] string InvNumEnding,
                                                  [Optional] DateTime? CDateStarting,
                                                  [Optional] DateTime? CDateEnding,
                                                  [Optional] short? CDateStartingOffset,
                                                  [Optional] short? CDateEndingOffset,
                                                  [Optional, DefaultParameterValue((byte)1)] byte? ProcessFlag,
         [Optional] ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iRetransmitEDIInvoicesExt = new CLM_RetransmitEDIInvoicesFactory().Create(appDb, bunchedLoadCollection);

                var result = iRetransmitEDIInvoicesExt.CLM_RetransmitEDIInvoicesSp(CustomerStarting,
                                                                               CustomerEnding,
                                                                               InvNumStarting,
                                                                               InvNumEnding,
                                                                               CDateStarting,
                                                                               CDateEnding,
                                                                               CDateStartingOffset,
                                                                               CDateEndingOffset,
                                                                               ProcessFlag,
                                                                               Infobar);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                Infobar = result.Infobar;
                return dt;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RetransmitEDIInvoicesSp([Optional] string CustomerStarting,
                                            [Optional] string CustomerEnding,
                                            [Optional] string InvNumStarting,
                                            [Optional] string InvNumEnding,
                                            [Optional] DateTime? CDateStarting,
                                            [Optional] DateTime? CDateEnding,
                                            [Optional] short? CDateStartingOffset,
                                            [Optional] short? CDateEndingOffset,
                                            [Optional, DefaultParameterValue((byte)1)] byte? ProcessFlag,
         [Optional] ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iRetransmitEDIInvoicesExt = new RetransmitEDIInvoicesFactory().Create(appDb);

                var result = iRetransmitEDIInvoicesExt.RetransmitEDIInvoicesSp(CustomerStarting,
                                                                               CustomerEnding,
                                                                               InvNumStarting,
                                                                               InvNumEnding,
                                                                               CDateStarting,
                                                                               CDateEnding,
                                                                               CDateStartingOffset,
                                                                               CDateEndingOffset,
                                                                               ProcessFlag,
                                                                               Infobar);

                int Severity = result.ReturnCode.Value;
                Infobar = result.Infobar;
                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PurgeEDIInvoices([Optional] string CustomerStarting,
		[Optional] string CustomerEnding,
		[Optional] DateTime? CDateStarting,
		[Optional] DateTime? CDateEnding,
		[Optional] string ExOptprPostedEmp,
		[Optional] short? CDateStartingOffset,
		[Optional] short? CDateEndingOffset,
		[Optional] ref string Message)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPurgeEDIInvoicesExt = new PurgeEDIInvoicesFactory().Create(appDb);
				
				var result = iPurgeEDIInvoicesExt.PurgeEDIInvoicesSp(CustomerStarting,
				CustomerEnding,
				CDateStarting,
				CDateEnding,
				ExOptprPostedEmp,
				CDateStartingOffset,
				CDateEndingOffset,
				Message);
				
				int Severity = result.ReturnCode.Value;
				Message = result.Message;
				return Severity;
			}
		}
    }
}
