//PROJECT NAME: VendorExt
//CLASS NAME: SLEdiScheds.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Vendor;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Vendor
{
	[IDOExtensionClass("SLEdiScheds")]
	public class SLEdiScheds : ExtensionClassBase
	{



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_RetransmitEDIPlanningSched([Optional] string VendorStarting,
		[Optional] string VendorEnding,
		[Optional] int? SchedNumStarting,
		[Optional] int? SchedNumEnding,
		[Optional] DateTime? CDateStarting,
		[Optional] DateTime? CDateEnding,
		[Optional] int? CDateStartingOffset,
		[Optional] int? CDateEndingOffset,
		[Optional, DefaultParameterValue(1)] int? ProcessFlag,
		[Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRetransmitEDIPlanningSchedExt = new RetransmitEDIPlanningSchedFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRetransmitEDIPlanningSchedExt.RetransmitEDIPlanningSchedSp(VendorStarting,
				VendorEnding,
				SchedNumStarting,
				SchedNumEnding,
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
		public int RetransmitEDIPlanningSchedSp([Optional] string VendorStarting,
		[Optional] string VendorEnding,
		[Optional] int? SchedNumStarting,
		[Optional] int? SchedNumEnding,
		[Optional] DateTime? CDateStarting,
		[Optional] DateTime? CDateEnding,
		[Optional] int? CDateStartingOffset,
		[Optional] int? CDateEndingOffset,
		[Optional, DefaultParameterValue(1)] int? ProcessFlag,
		[Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
                var iRetransmitEDIPlanningSchedExt = new RetransmitEDIPlanningSchedFactory().Create(appDb, bunchedLoadCollection,

                mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRetransmitEDIPlanningSchedExt.RetransmitEDIPlanningSchedSp(VendorStarting,
				VendorEnding,
				SchedNumStarting,
				SchedNumEnding,
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
    }
}
