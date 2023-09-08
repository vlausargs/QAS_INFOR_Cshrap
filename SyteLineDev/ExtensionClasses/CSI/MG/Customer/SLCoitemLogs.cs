//PROJECT NAME: CustomerExt
//CLASS NAME: SLCoitemLogs.cs

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
	[IDOExtensionClass("SLCoitemLogs")]
	public class SLCoitemLogs : ExtensionClassBase
	{



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_SlsmanOrderBookingsSP(string SlsManList,
		DateTime? StartDate,
		int? RMAInclude,
		string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_SlsmanOrderBookingsExt = new CLM_SlsmanOrderBookingsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_SlsmanOrderBookingsExt.CLM_SlsmanOrderBookingsSP(SlsManList,
				StartDate,
				RMAInclude,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetFutureSalesPeriodsSp(DateTime? StartDate,
		[Optional] ref DateTime? FirstPeriodEnd,
		[Optional] ref DateTime? SecondPeriodEnd,
		[Optional] ref DateTime? ThirdPeriodEnd,
		[Optional] ref DateTime? FourthPeriodEnd,
		[Optional] ref DateTime? FifthPeriodEnd,
		[Optional] ref DateTime? SixthPeriodEnd,
		[Optional] ref DateTime? InitialPeriodStart,
		[Optional] ref DateTime? SixthPeriodStart)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetFutureSalesPeriodsExt = new GetFutureSalesPeriodsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetFutureSalesPeriodsExt.GetFutureSalesPeriodsSp(StartDate,
				FirstPeriodEnd,
				SecondPeriodEnd,
				ThirdPeriodEnd,
				FourthPeriodEnd,
				FifthPeriodEnd,
				SixthPeriodEnd,
				InitialPeriodStart,
				SixthPeriodStart);
				
				int Severity = result.ReturnCode.Value;
				FirstPeriodEnd = result.FirstPeriodEnd;
				SecondPeriodEnd = result.SecondPeriodEnd;
				ThirdPeriodEnd = result.ThirdPeriodEnd;
				FourthPeriodEnd = result.FourthPeriodEnd;
				FifthPeriodEnd = result.FifthPeriodEnd;
				SixthPeriodEnd = result.SixthPeriodEnd;
				InitialPeriodStart = result.InitialPeriodStart;
				SixthPeriodStart = result.SixthPeriodStart;
				return Severity;
			}
		}
	}
}
