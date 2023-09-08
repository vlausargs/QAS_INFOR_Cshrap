//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBEUSalesLineViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.BusInterface;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.BusInterface
{
	[IDOExtensionClass("ESBEUSalesLineViews")]
	public class ESBEUSalesLineViews : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBEUSalesLineSp(string SiteGroup,
		int? CalendarQuarter,
		DateTime? StartTaxPeriod,
		DateTime? EndTaxPeriod,
		string StartCust,
		string EndCust,
		string StartEcCode,
		string EndEcCode,
		string StartProcessInd,
		string EndProcessInd)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBEUSalesLineExt = new CLM_ESBEUSalesLineFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBEUSalesLineExt.CLM_ESBEUSalesLineSp(SiteGroup,
				CalendarQuarter,
				StartTaxPeriod,
				EndTaxPeriod,
				StartCust,
				EndCust,
				StartEcCode,
				EndEcCode,
				StartProcessInd,
				EndProcessInd);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
