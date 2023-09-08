//PROJECT NAME: ProjectsExt
//CLASS NAME: SLWBSs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Projects;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Projects
{
	[IDOExtensionClass("SLWBSs")]
	public class SLWBSs : ExtensionClassBase
	{



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int WBSCheckProjWbsValidSP(string RefType,
		string RefNum,
		ref string ValidRefNum,
		ref string ValidProjType)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iWBSCheckProjWbsValidExt = new WBSCheckProjWbsValidFactory().Create(appDb);
				
				var result = iWBSCheckProjWbsValidExt.WBSCheckProjWbsValidSP(RefType,
				RefNum,
				ValidRefNum,
				ValidProjType);
				
				int Severity = result.ReturnCode.Value;
				ValidRefNum = result.ValidRefNum;
				ValidProjType = result.ValidProjType;
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable WBSPopulateProjWbsSP(string RefType)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iWBSPopulateProjWbsExt = new WBSPopulateProjWbsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iWBSPopulateProjWbsExt.WBSPopulateProjWbsSP(RefType);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable WBSPercCompleteSP(string WbsNum,
		string SiteGroup,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iWBSPercCompleteExt = new WBSPercCompleteFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iWBSPercCompleteExt.WBSPercCompleteSP(WbsNum,
				SiteGroup,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
