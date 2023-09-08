//PROJECT NAME: ProductExt
//CLASS NAME: SLResrc000s.cs

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
	[IDOExtensionClass("SLResrc000s")]
	public class SLResrc000s : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ResrcDelSp(string Resid,
		int? AltNo,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iResrcDelExt = new ResrcDelFactory().Create(appDb);
				
				var result = iResrcDelExt.ResrcDelSp(Resid,
				AltNo,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
