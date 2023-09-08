//PROJECT NAME: AdaptersExt
//CLASS NAME: SLPartySyncs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Material;
using CSI.Data.RecordSets;

namespace CSI.MG.Adapters
{
    [IDOExtensionClass("SLPartySyncs")]
    public class SLPartySyncs : ExtensionClassBase
    {




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ExpandKyByTypeSp(string DataType,
		string Key,
		[Optional, DefaultParameterValue(null)] string Site,
		ref string Result)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iExpandKyByTypeExt = new ExpandKyByTypeFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iExpandKyByTypeExt.ExpandKyByTypeSp(DataType,
				Key,
				Site,
				Result);
				
				int Severity = result.ReturnCode.Value;
				Result = result.Result;
				return Severity;
			}
		}
    }
}
