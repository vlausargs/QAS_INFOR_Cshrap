//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBRequisitionLineViews.cs

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
	[IDOExtensionClass("ESBRequisitionLineViews")]
	public class ESBRequisitionLineViews : ExtensionClassBase
	{



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBRequisitionLineSp(string ReqNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBRequisitionLineExt = new CLM_ESBRequisitionLineFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBRequisitionLineExt.CLM_ESBRequisitionLineSp(ReqNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadProcessReqLineSp(string LineReqNum,
		int? ReqLine,
		string ActionCode,
		string Item,
		string Description,
		decimal? QtyOrderedConv,
		string UM,
		decimal? UnitMatCostConv,
		string CurrCode,
		DateTime? DueDate,
		string Whse,
		string VendNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iLoadProcessReqLineExt = new LoadProcessReqLineFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iLoadProcessReqLineExt.LoadProcessReqLineSp(LineReqNum,
				ReqLine,
				ActionCode,
				Item,
				Description,
				QtyOrderedConv,
				UM,
				UnitMatCostConv,
				CurrCode,
				DueDate,
				Whse,
				VendNum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
