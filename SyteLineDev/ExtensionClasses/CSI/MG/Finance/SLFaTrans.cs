//PROJECT NAME: FinanceExt
//CLASS NAME: SLFaTrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Finance
{
	[IDOExtensionClass("SLFaTrans")]
	public class SLFaTrans : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FatranPostDeleteTmpSp(Guid? ProcessID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFatranPostDeleteTmpExt = new FatranPostDeleteTmpFactory().Create(appDb);
				
				int Severity = iFatranPostDeleteTmpExt.FatranPostDeleteTmpSp(ProcessID);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FatranPostSp(Guid? ProcessID,
		                        Guid? FatranRowPointer,
		                        ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFatranPostExt = new FatranPostFactory().Create(appDb);
				
				int Severity = iFatranPostExt.FatranPostSp(ProcessID,
				                                           FatranRowPointer,
				                                           ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FatranPostVerifyCloseFormSp(Guid? ProcessID,
		                                       ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFatranPostVerifyCloseFormExt = new FatranPostVerifyCloseFormFactory().Create(appDb);
				
				int Severity = iFatranPostVerifyCloseFormExt.FatranPostVerifyCloseFormSp(ProcessID,
				                                                                         ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FatranPostVerifyPrintSp(ref Guid? ProcessID,
		                                   ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFatranPostVerifyPrintExt = new FatranPostVerifyPrintFactory().Create(appDb);
				
				int Severity = iFatranPostVerifyPrintExt.FatranPostVerifyPrintSp(ref ProcessID,
				                                                                 ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetFaTransTotalSp(string pFaNum,
		                             ref decimal? pTotCost,
		                             ref decimal? pTotDepr)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetFaTransTotalExt = new GetFaTransTotalFactory().Create(appDb);
				
				int Severity = iGetFaTransTotalExt.GetFaTransTotalSp(pFaNum,
				                                                     ref pTotCost,
				                                                     ref pTotDepr);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable FatranPostCreateTmpSp(Guid? ProcessID,
		                                       [Optional] string AssetStarting,
		                                       [Optional] string AssetEnding,
		                                       [Optional] string AssetType,
		                                       [Optional] string StatusCode,
		                                       [Optional] string ClassCodeStarting,
		                                       [Optional] string ClassCodeEnding,
		                                       [Optional] string DepartmentStarting,
		                                       [Optional] string DepartmentEnding,
		                                       [Optional] string LocationStarting,
		                                       [Optional] string LocationEnding,
		                                       [Optional] DateTime? TransDateStarting,
		                                       [Optional] DateTime? TransDateEnding,
		                                       [Optional] short? TransDateStartingOffset,
		                                       [Optional] short? TransDateEndingOffset)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iFatranPostCreateTmpExt = new FatranPostCreateTmpFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iFatranPostCreateTmpExt.FatranPostCreateTmpSp(ProcessID,
				                                                           AssetStarting,
				                                                           AssetEnding,
				                                                           AssetType,
				                                                           StatusCode,
				                                                           ClassCodeStarting,
				                                                           ClassCodeEnding,
				                                                           DepartmentStarting,
				                                                           DepartmentEnding,
				                                                           LocationStarting,
				                                                           LocationEnding,
				                                                           TransDateStarting,
				                                                           TransDateEnding,
				                                                           TransDateStartingOffset,
				                                                           TransDateEndingOffset);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
