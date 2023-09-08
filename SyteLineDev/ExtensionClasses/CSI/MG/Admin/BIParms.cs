//PROJECT NAME: AdminExt
//CLASS NAME: BIParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Admin;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Admin
{
    [IDOExtensionClass("BIParms")]
    public class BIParms : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int BI_Prepare_DataSp()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iBI_Prepare_DataExt = new BI_Prepare_DataFactory().Create(appDb);
				
				var result = iBI_Prepare_DataExt.BI_Prepare_DataSp();
				
				
				return result.Value;
			}
		}
    }
}

