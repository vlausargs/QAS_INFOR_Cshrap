//PROJECT NAME: ProductExt
//CLASS NAME: SLRgrp000s.cs

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
	[IDOExtensionClass("SLRgrp000s")]
	public class SLRgrp000s : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RgrpDelSp(string Rgid,
		int? AltNo,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRgrpDelExt = new RgrpDelFactory().Create(appDb);
				
				var result = iRgrpDelExt.RgrpDelSp(Rgid,
				AltNo,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
