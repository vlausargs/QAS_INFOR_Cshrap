//PROJECT NAME: CodesExt
//CLASS NAME: SLDimObjectAttributeInlineList.cs

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
	[IDOExtensionClass("SLDimObjectAttributeInlineList")]
	public class SLDimObjectAttributeInlineList : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_LoadInlineListSp(string ObjectName,
		                                      string Attribute)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_LoadInlineListExt = new CLM_LoadInlineListFactory().Create(appDb, bunchedLoadCollection);
				
				DataTable dt = iCLM_LoadInlineListExt.CLM_LoadInlineListSp(ObjectName,
				                                                           Attribute);
				
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PlaceholderSp()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPlaceholderExt = new PlaceholderFactory().Create(appDb);
				
				var result = iPlaceholderExt.PlaceholderSp();
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
