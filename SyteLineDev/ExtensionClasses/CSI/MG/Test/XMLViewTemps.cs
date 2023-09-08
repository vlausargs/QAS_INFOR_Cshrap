//PROJECT NAME: TestExt
//CLASS NAME: XMLViewTemps.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Test;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Test
{
	[IDOExtensionClass("XMLViewTemps")]
	public class XMLViewTemps : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_XMLViewSp(string TableName,
		                               string TableColumn)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_XMLViewExt = new CLM_XMLViewFactory().Create(appDb, bunchedLoadCollection);
				
				DataTable dt = iCLM_XMLViewExt.CLM_XMLViewSp(TableName,
				                                             TableColumn);
				
				return dt;
			}
		}
	}
}
