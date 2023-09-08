//PROJECT NAME: APSExt
//CLASS NAME: SLMATLDELVnnns.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.APS
{
    [IDOExtensionClass("SLMATLDELVnnns")]
    public class SLMATLDELVnnns : CSIExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetMATLDELVSp(short? AltNo,
		                                      [Optional] string Filter)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ApsGetMATLDELVExt = new CLM_ApsGetMATLDELVFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ApsGetMATLDELVExt.CLM_ApsGetMATLDELVSp(AltNo,
				                                                         Filter);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsMATLDELVDelSp(int? AltNo,
		Guid? RowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsMATLDELVDelExt = new ApsMATLDELVDelFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsMATLDELVDelExt.ApsMATLDELVDelSp(AltNo,
				RowPointer);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsMATLDELVSaveSp(int? InsertFlag,
		int? AltNo,
		string ORDERID,
		string DESCR,
		DateTime? DELVDATE,
		string MATERIALID,
		string AMOUNT,
		int? CATEGORY,
		int? FLAGS,
		string CUSTOMER)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsMATLDELVSaveExt = new ApsMATLDELVSaveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsMATLDELVSaveExt.ApsMATLDELVSaveSp(InsertFlag,
				AltNo,
				ORDERID,
				DESCR,
				DELVDATE,
				MATERIALID,
				AMOUNT,
				CATEGORY,
				FLAGS,
				CUSTOMER);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsWhatIfEXRCPTPOSp(int? AltNo,
			string MATERIALID,
			[Optional] string OrderIdFilter)
		{
			var iCLM_ApsWhatIfEXRCPTPOExt = this.GetService<ICLM_ApsWhatIfEXRCPTPO>();
			var result = iCLM_ApsWhatIfEXRCPTPOExt.CLM_ApsWhatIfEXRCPTPOSp(AltNo,
				MATERIALID,
				OrderIdFilter);
			
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
