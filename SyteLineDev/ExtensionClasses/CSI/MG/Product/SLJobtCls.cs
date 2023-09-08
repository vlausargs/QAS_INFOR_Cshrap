//PROJECT NAME: ProductExt
//CLASS NAME: SLJobtCls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Product
{
	[IDOExtensionClass("SLJobtCls")]
	public class SLJobtCls : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int JobtClsLogErrorSp(decimal? PTransNum,
		string ErrorMsg)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iJobtClsLogErrorExt = new JobtClsLogErrorFactory().Create(appDb);
				
				var result = iJobtClsLogErrorExt.JobtClsLogErrorSp(PTransNum,
				ErrorMsg);
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
