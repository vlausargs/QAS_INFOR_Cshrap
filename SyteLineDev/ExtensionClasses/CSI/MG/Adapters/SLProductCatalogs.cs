//PROJECT NAME: AdaptersExt
//CLASS NAME: SLProductCatalogs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Adapters;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Adapters
{
	[IDOExtensionClass("SLProductCatalogs")]
	public class SLProductCatalogs : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CfgCheckConfigSp(string PCEP,
		string PItem,
		ref int? PConfigurable)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCfgCheckConfigExt = new CfgCheckConfigFactory().Create(appDb);
				
				var result = iCfgCheckConfigExt.CfgCheckConfigSp(PCEP,
				PItem,
				PConfigurable);
				
				int Severity = result.ReturnCode.Value;
				PConfigurable = result.PConfigurable;
				return Severity;
			}
		}
	}
}
