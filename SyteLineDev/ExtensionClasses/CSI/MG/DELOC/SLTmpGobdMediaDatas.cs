//PROJECT NAME: DELOCExt
//CLASS NAME: SLTmpGobdMediaDatas.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting.Germany;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.DELOC
{
    [IDOExtensionClass("SLTmpGobdMediaDatas")]
    public class SLTmpGobdMediaDatas : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SetGobdMediaDataSp(Guid? ProcessId,
		                              [Optional] string GoBDMediaDocument)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSetGoBDMediaDataExt = new SetGoBDMediaDataFactory().Create(appDb);
				
				var result = iSetGoBDMediaDataExt.SetGoBDMediaDataSp(ProcessId,
				                                                     GoBDMediaDocument);
				
				
				return result.Value;
			}
		}
    }
}
