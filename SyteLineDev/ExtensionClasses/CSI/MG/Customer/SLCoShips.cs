//PROJECT NAME: CustomerExt
//CLASS NAME: SLCoShips.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Logistics.Vendor;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLCoShips")]
	public class SLCoShips : CSIExtensionClassBase
	{



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GenerateDoSeqSp(string DoNum,
		int? DoLine,
		string CoNum,
		int? CoLine,
		int? CoRelease,
		DateTime? CoShipDate,
		int? CoDateSeq,
		ref string ErrorMessage)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGenerateDoSeqExt = new GenerateDoSeqFactory().Create(appDb);
				
				var result = iGenerateDoSeqExt.GenerateDoSeqSp(DoNum,
				DoLine,
				CoNum,
				CoLine,
				CoRelease,
				CoShipDate,
				CoDateSeq,
				ErrorMessage);
				
				int Severity = result.ReturnCode.Value;
				ErrorMessage = result.ErrorMessage;
				return Severity;
			}
		}








































		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetShipmentTrackingURLSp(decimal? ShipmentID,
		[Optional] string TrackingNumber,
		ref string TrackingURL)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetShipmentTrackingURLExt = new GetShipmentTrackingURLFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetShipmentTrackingURLExt.GetShipmentTrackingURLSp(ShipmentID,
				TrackingNumber,
				TrackingURL);
				
				int Severity = result.ReturnCode.Value;
				TrackingURL = result.TrackingURL;
				return Severity;
			}
		}










		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CoShipInProcessAdjEntrySp(Guid? CurCoShipRowPointer,
		decimal? QtyApprove,
		DateTime? ApproveDate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCoShipInProcessAdjEntryExt = new CoShipInProcessAdjEntryFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCoShipInProcessAdjEntryExt.CoShipInProcessAdjEntrySp(CurCoShipRowPointer,
				QtyApprove,
				ApproveDate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_DomesticCurrencySp(string CurrCode,
		[Optional, DefaultParameterValue(0)] int? UseBuyRate,
		[Optional] decimal? TRate,
		[Optional] DateTime? PossibleDate,
		[Optional] decimal? Amount1,
		[Optional] decimal? Amount2,
		[Optional] decimal? Amount3,
		[Optional] decimal? Amount4,
		[Optional] decimal? Amount5,
		[Optional] decimal? Amount6,
		[Optional] decimal? Amount7,
		[Optional] decimal? Amount8,
		[Optional] decimal? Amount9,
		[Optional] decimal? Amount10,
		[Optional] decimal? Amount11,
		[Optional] decimal? Amount12,
		[Optional] decimal? Amount13,
		[Optional] decimal? Amount14,
		[Optional] decimal? Amount15,
		[Optional] decimal? Amount16,
		[Optional] decimal? Amount17,
		[Optional] decimal? Amount18,
		[Optional] decimal? Amount19,
		[Optional] decimal? Amount20,
		[Optional] decimal? Amount21,
		[Optional] decimal? Amount22,
		[Optional] decimal? Amount23,
		[Optional] decimal? Amount24,
		[Optional] decimal? Amount25,
		[Optional] decimal? Amount26,
		[Optional] decimal? Amount27,
		[Optional] decimal? Amount28,
		[Optional] decimal? Amount29,
		[Optional] decimal? Amount30,
		[Optional] decimal? Amount31,
		[Optional] decimal? Amount32,
		[Optional] decimal? Amount33,
		[Optional] decimal? Amount34,
		[Optional] decimal? Amount35,
		[Optional] decimal? Amount36,
		[Optional] decimal? Amount37,
		[Optional] decimal? Amount38,
		[Optional] decimal? Amount39,
		[Optional] decimal? Amount40)
		{
			var iCLM_DomesticCurrencyExt = new CSI.Logistics.Customer.CLM_DomesticCurrencyFactory().Create(this, true);
			
			var result = iCLM_DomesticCurrencyExt.CLM_DomesticCurrencySp(CurrCode,
			UseBuyRate,
			TRate,
			PossibleDate,
			Amount1,
			Amount2,
			Amount3,
			Amount4,
			Amount5,
			Amount6,
			Amount7,
			Amount8,
			Amount9,
			Amount10,
			Amount11,
			Amount12,
			Amount13,
			Amount14,
			Amount15,
			Amount16,
			Amount17,
			Amount18,
			Amount19,
			Amount20,
			Amount21,
			Amount22,
			Amount23,
			Amount24,
			Amount25,
			Amount26,
			Amount27,
			Amount28,
			Amount29,
			Amount30,
			Amount31,
			Amount32,
			Amount33,
			Amount34,
			Amount35,
			Amount36,
			Amount37,
			Amount38,
			Amount39,
			Amount40);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}

	}
}
