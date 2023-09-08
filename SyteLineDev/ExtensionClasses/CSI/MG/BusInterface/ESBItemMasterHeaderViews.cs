//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBItemMasterHeaderViews.cs

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
	[IDOExtensionClass("ESBItemMasterHeaderViews")]
	public class ESBItemMasterHeaderViews : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBItemMasterSp(string DerBODID,
		                               string ActionExpression,
		                               string Item,
		                               string Description,
		                               string AbcCode,
		                               string CommCode,
		                               string DerCostMethod,
		                               string DerProductCode,
		                               string DerBackflush,
		                               string UM,
		                               decimal? UnitCost,
		                               string DerSerialTracked,
		                               string DerLotTracked,
		                               string DerBODPMTCode,
		                               decimal? OrderMin,
		                               decimal? OrderMax,
		                               string AltItem,
		                               decimal? NetWeightMeasure,
		                               string OrderConfigurable,
		                               string CommodityJurisdiction,
		                               string ECCNUSMLValue,
		                               string ExportComplianceProgram,
		                               string SchedBNum,
		                               string HTSCode,
		                               string RevisionID,
		                               string LastModificationPerson,
		                               string TrackingIndicator,
		                               decimal? LotSize,
		                               string SpecificationName,
		                               ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBItemMasterExt = new LoadESBItemMasterFactory().Create(appDb);
				
				int Severity = iLoadESBItemMasterExt.LoadESBItemMasterSp(DerBODID,
				                                                         ActionExpression,
				                                                         Item,
				                                                         Description,
				                                                         AbcCode,
				                                                         CommCode,
				                                                         DerCostMethod,
				                                                         DerProductCode,
				                                                         DerBackflush,
				                                                         UM,
				                                                         UnitCost,
				                                                         DerSerialTracked,
				                                                         DerLotTracked,
				                                                         DerBODPMTCode,
				                                                         OrderMin,
				                                                         OrderMax,
				                                                         AltItem,
				                                                         NetWeightMeasure,
				                                                         OrderConfigurable,
				                                                         CommodityJurisdiction,
				                                                         ECCNUSMLValue,
				                                                         ExportComplianceProgram,
				                                                         SchedBNum,
				                                                         HTSCode,
				                                                         RevisionID,
				                                                         LastModificationPerson,
				                                                         TrackingIndicator,
				                                                         LotSize,
				                                                         SpecificationName,
				                                                         ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBItemMasterHeaderSp(string Item)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBItemMasterHeaderExt = new CLM_ESBItemMasterHeaderFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBItemMasterHeaderExt.CLM_ESBItemMasterHeaderSp(Item);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
