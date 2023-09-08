//PROJECT NAME: APSExt
//CLASS NAME: SLBATCHnnns.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.APS
{
    [IDOExtensionClass("SLBATCHnnns")]
    public class SLBATCHnnns : ExtensionClassBase
    {


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetBATCHSp(short? AltNo,
		                                   [Optional] string Filter)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ApsGetBATCHExt = new CLM_ApsGetBATCHFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ApsGetBATCHExt.CLM_ApsGetBATCHSp(AltNo,
				                                                   Filter);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsBATCHDelSp(int? AltNo,
		Guid? RowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsBATCHDelExt = new ApsBATCHDelFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsBATCHDelExt.ApsBATCHDelSp(AltNo,
				RowPointer);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsBATCHSaveSp(int? InsertFlag,
		int? AltNo,
		string BATDEFID,
		string DESCR,
		string ITEM,
		int? SEPRL,
		int? QUANRL,
		decimal? QVALUE,
		decimal? MINQUAN,
		decimal? MAXQUAN,
		string ADDOVFG,
		int? OVERRL,
		decimal? OVTHRESH,
		string PEROVFG,
		decimal? OVCYCLE)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsBATCHSaveExt = new ApsBATCHSaveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsBATCHSaveExt.ApsBATCHSaveSp(InsertFlag,
				AltNo,
				BATDEFID,
				DESCR,
				ITEM,
				SEPRL,
				QUANRL,
				QVALUE,
				MINQUAN,
				MAXQUAN,
				ADDOVFG,
				OVERRL,
				OVTHRESH,
				PEROVFG,
				OVCYCLE);
				
				int Severity = result.Value;
				return Severity;
			}
		}
    }
}
