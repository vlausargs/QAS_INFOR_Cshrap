//PROJECT NAME: FSPlusUnitExt
//CLASS NAME: FSUnitMnts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.FSPlusUnit
{
	[IDOExtensionClass("FSUnitMnts")]
	public class FSUnitMnts : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSCopyDefMaintSp(string iItem,
		                               string iSerNum,
		                               ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSCopyDefMaintExt = new SSSFSCopyDefMaintFactory().Create(appDb);
				
				int Severity = iSSSFSCopyDefMaintExt.SSSFSCopyDefMaintSp(iItem,
				                                                         iSerNum,
				                                                         ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSUnitGetSROTypeSp(string iSRONum,
		                                 string iSROType,
		                                 ref string PromptMsgBadType,
		                                 ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSUnitGetSROTypeExt = new SSSFSUnitGetSROTypeFactory().Create(appDb);
				
				int Severity = iSSSFSUnitGetSROTypeExt.SSSFSUnitGetSROTypeSp(iSRONum,
				                                                             iSROType,
				                                                             ref PromptMsgBadType,
				                                                             ref Infobar);
				
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSAutoSROGenSp(int? iCreateSROs,
		DateTime? iThroughDate,
		string iStartSerNum,
		string iEndSerNum,
		string iStartSroType,
		string iEndSroType,
		string iStartDept,
		string iEndDept,
		string iStartWc,
		string iEndWc,
		int? iKeepOperNums,
		int? iDateOffset,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSAutoSROGenExt = new SSSFSAutoSROGenFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSAutoSROGenExt.SSSFSAutoSROGenSp(iCreateSROs,
				iThroughDate,
				iStartSerNum,
				iEndSerNum,
				iStartSroType,
				iEndSroType,
				iStartDept,
				iEndDept,
				iStartWc,
				iEndWc,
				iKeepOperNums,
				iDateOffset,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
