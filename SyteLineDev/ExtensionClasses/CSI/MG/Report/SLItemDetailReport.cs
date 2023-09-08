//PROJECT NAME: ReportExt
//CLASS NAME: SLItemDetailReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.MG.MGCore;
using CSI.Adapters;
using CSI.Data.Functions;

namespace CSI.MG.Report
{
	[IDOExtensionClass("SLItemDetailReport")]
	public class SLItemDetailReport : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ItemDetailSp([Optional, DefaultParameterValue("AOS")] string MaterialStatus,
			[Optional, DefaultParameterValue("PMT")] string Source,
			[Optional, DefaultParameterValue("MTFO")] string MaterialType,
			[Optional, DefaultParameterValue("ABC")] string ABCCode,
			[Optional, DefaultParameterValue((byte)0)] byte? Stocked,
			[Optional, DefaultParameterValue((byte)0)] byte? NotStocked,
			[Optional, DefaultParameterValue((byte)0)] byte? DisplayStockroomLocations,
			[Optional, DefaultParameterValue((byte)0)] byte? DisplayVendorsfortheItems,
			[Optional, DefaultParameterValue((byte)0)] byte? DisplayCustomersforItems,
			[Optional, DefaultParameterValue((byte)0)] byte? PrintZeroQtyOnHandItems,
			[Optional, DefaultParameterValue((byte)0)] byte? PrintCost,
			[Optional, DefaultParameterValue((byte)0)] byte? PrintPrice,
			[Optional, DefaultParameterValue((byte)0)] byte? DisplayHeader,
			[Optional] string WarehouseStarting,
			[Optional] string WarehouseEnding,
			[Optional] string ItemStarting,
			[Optional] string ItemEnding,
			[Optional] string ProductCodeStarting,
			[Optional] string ProductCodeEnding,
			[Optional] string ComplianceProgramId,
			[Optional] string ComplianceStatus,
			[Optional] string pSite)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

				var mgInvoker = new MGInvoker(this.Context);

				var iRpt_ItemDetailExt = new Rpt_ItemDetailFactory(new CloseSessionContextFactory(),
					new InitSessionContextFactory(),
					new GetIsolationLevelFactory(),
					new GetSiteDateFactory(),
					new GetCodeFactory()).Create(appDb,
						bunchedLoadCollection,
						mgInvoker,
						new CSI.Data.SQL.SQLParameterProvider(),
						true, this);

				var result = iRpt_ItemDetailExt.Rpt_ItemDetailSp(MaterialStatus,
					Source,
					MaterialType,
					ABCCode,
					Stocked,
					NotStocked,
					DisplayStockroomLocations,
					DisplayVendorsfortheItems,
					DisplayCustomersforItems,
					PrintZeroQtyOnHandItems,
					PrintCost,
					PrintPrice,
					DisplayHeader,
					WarehouseStarting,
					WarehouseEnding,
					ItemStarting,
					ItemEnding,
					ProductCodeStarting,
					ProductCodeEnding,
					ComplianceProgramId,
					ComplianceStatus,
					pSite);


				if (result.Data is null)
					return new DataTable();
				else
				{
					IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
					return recordCollectionToDataTable.ToDataTable(result.Data.Items);
				}
			}
		}
	}
}
