//PROJECT NAME: ConfigExt
//CLASS NAME: SLCfgComps.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Config;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Config
{
	[IDOExtensionClass("SLCfgComps")]
	public class SLCfgComps : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CfgRemoveUnusedCompsSp(string ConfigId,
		string CompGIDs,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCfgRemoveUnusedCompsExt = new CfgRemoveUnusedCompsFactory().Create(appDb);
				
				var result = iCfgRemoveUnusedCompsExt.CfgRemoveUnusedCompsSp(ConfigId,
				CompGIDs,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
