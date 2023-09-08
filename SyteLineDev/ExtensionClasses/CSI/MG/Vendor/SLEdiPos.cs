//PROJECT NAME: VendorExt
//CLASS NAME: SLEdiPos.cs

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
	[IDOExtensionClass("SLEdiPos")]
	public class SLEdiPos : ExtensionClassBase
	{








		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_RetransmitEDIPurchaseOrder([Optional] string VendorStarting,
		[Optional] string VendorEnding,
		[Optional] string PoStarting,
		[Optional] string PoEnding,
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
				
				var iRetransmitEDIPurchaseOrdersExt = new RetransmitEDIPurchaseOrdersFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRetransmitEDIPurchaseOrdersExt.RetransmitEDIPurchaseOrdersSp(VendorStarting,
				VendorEnding,
				PoStarting,
				PoEnding,
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
		public int RetransmitEDIPurchaseOrdersSp([Optional] string VendorStarting,
		[Optional] string VendorEnding,
		[Optional] string PoStarting,
		[Optional] string PoEnding,
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

                var iRetransmitEDIPurchaseOrdersExt = new RetransmitEDIPurchaseOrdersFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iRetransmitEDIPurchaseOrdersExt.RetransmitEDIPurchaseOrdersSp(VendorStarting,
				VendorEnding,
				PoStarting,
				PoEnding,
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
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_RetransmitEDIShipSchedules([Optional] string VendorStarting,
		[Optional] string VendorEnding,
		[Optional] string PoStarting,
		[Optional] string PoEnding,
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
				
				var iRetransmitEDIShipSchedulesExt = new RetransmitEDIShipSchedulesFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRetransmitEDIShipSchedulesExt.RetransmitEDIShipSchedulesSp(VendorStarting,
				VendorEnding,
				PoStarting,
				PoEnding,
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
		public int RetransmitEDIShipSchedulesSp([Optional] string VendorStarting,
		[Optional] string VendorEnding,
		[Optional] string PoStarting,
		[Optional] string PoEnding,
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

                var iRetransmitEDIShipSchedulesExt = new RetransmitEDIShipSchedulesFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);


                var result = iRetransmitEDIShipSchedulesExt.RetransmitEDIShipSchedulesSp(VendorStarting,
				VendorEnding,
				PoStarting,
				PoEnding,
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
