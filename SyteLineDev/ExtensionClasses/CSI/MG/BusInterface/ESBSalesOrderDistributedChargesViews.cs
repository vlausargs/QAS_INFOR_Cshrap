//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBSalesOrderDistributedChargesViews.cs

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
	[IDOExtensionClass("ESBSalesOrderDistributedChargesViews")]
	public class ESBSalesOrderDistributedChargesViews : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBDistributedChargeSp(string ConfirmationRef,
		                                      short? CoLine,
		                                      decimal? ChargeAmt,
		                                      decimal? ChargePct,
		                                      string ReasonCode,
		                                      ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBDistributedChargeExt = new LoadESBDistributedChargeFactory().Create(appDb);
				
				int Severity = iLoadESBDistributedChargeExt.LoadESBDistributedChargeSp(ConfirmationRef,
				                                                                       CoLine,
				                                                                       ChargeAmt,
				                                                                       ChargePct,
				                                                                       ReasonCode,
				                                                                       ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBDistributedChargesSp(string CoNum,
		int? CoLine)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBDistributedChargesExt = new CLM_ESBDistributedChargesFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBDistributedChargesExt.CLM_ESBDistributedChargesSp(CoNum,
				CoLine);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
