//PROJECT NAME: CodesExt
//CLASS NAME: SLISOUMs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Codes;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Codes
{
	[IDOExtensionClass("SLISOUMs")]
	public class SLISOUMs : CSIExtensionClassBase
	{


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetISOUMInfoSp(string ISOUMCode,
			[Optional] ref string ISOUMDescription)
		{
			var iGetISOUMInfoExt = new GetISOUMInfoFactory().Create(this, true);
			
			var result = iGetISOUMInfoExt.GetISOUMInfoSp(ISOUMCode,
				ISOUMDescription);
			
			ISOUMDescription = result.ISOUMDescription;
			
			return result.ReturnCode??0;
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable UMCategoryListSp()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iUMCategoryListExt = new UMCategoryListFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iUMCategoryListExt.UMCategoryListSp();
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
