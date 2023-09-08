//PROJECT NAME: MaterialExt
//CLASS NAME: SLItemJobRevisions.cs

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
	[IDOExtensionClass("SLItemJobRevisions")]
	public class SLItemJobRevisions : ExtensionClassBase
	{



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MO_UpdateAlternateDescSp(string Job,
		int? JobSuffix,
		[Optional] string AlternateDescription)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iMO_UpdateAlternateDescExt = new MO_UpdateAlternateDescFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iMO_UpdateAlternateDescExt.MO_UpdateAlternateDescSp(Job,
				JobSuffix,
				AlternateDescription);
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
