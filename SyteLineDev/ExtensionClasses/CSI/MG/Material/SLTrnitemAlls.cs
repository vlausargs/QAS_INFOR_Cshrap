//PROJECT NAME: MaterialExt
//CLASS NAME: SLTrnitemAlls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Material
{
	[IDOExtensionClass("SLTrnitemAlls")]
	public class SLTrnitemAlls : ExtensionClassBase
	{



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_TranferLineDetailSp(string Item,
		string Whse,
		[Optional] string FilterString,
		[Optional] string PSiteGroup)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_TranferLineDetailExt = new CLM_TranferLineDetailFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_TranferLineDetailExt.CLM_TranferLineDetailSp(Item,
				Whse,
				FilterString,
				PSiteGroup);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
