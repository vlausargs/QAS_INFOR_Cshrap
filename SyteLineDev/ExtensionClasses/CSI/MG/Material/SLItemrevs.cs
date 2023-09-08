//PROJECT NAME: MaterialExt
//CLASS NAME: SLItemrevs.cs

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
	[IDOExtensionClass("SLItemrevs")]
	public class SLItemrevs : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UtilRevDel(string SelectedItem,
		                      string StartingRev,
		                      string EndingRev,
		                      ref int? CounterItem,
		                      ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUtilRevDelExt = new UtilRevDelFactory().Create(appDb);
				
				var result = iUtilRevDelExt.UtilRevDelSp(SelectedItem,
				                                         StartingRev,
				                                         EndingRev,
				                                         CounterItem,
				                                         Infobar);
				
				int Severity = result.ReturnCode.Value;
				CounterItem = result.CounterItem;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
