//PROJECT NAME: MG
//CLASS NAME: FSSROTypes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.Requests;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.FSPlusSRO
{
	[IDOExtensionClass("FSSROTypes")]
	public class FSSROTypes : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROTypeDefaultsSp(ref string ProductCode,
		ref string Whse,
		ref string BillCode,
		ref string BillType,
		ref string CGSLabor,
		ref string CGSMatl,
		ref string CGSMisc,
		ref byte? AccumWIP,
		ref byte? InclDemand,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSROTypeDefaultsExt = new SSSFSSROTypeDefaultsFactory().Create(appDb);
				
				var result = iSSSFSSROTypeDefaultsExt.SSSFSSROTypeDefaultsSp(ProductCode,
				Whse,
				BillCode,
				BillType,
				CGSLabor,
				CGSMatl,
				CGSMisc,
				AccumWIP,
				InclDemand,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				ProductCode = result.ProductCode;
				Whse = result.Whse;
				BillCode = result.BillCode;
				BillType = result.BillType;
				CGSLabor = result.CGSLabor;
				CGSMatl = result.CGSMatl;
				CGSMisc = result.CGSMisc;
				AccumWIP = result.AccumWIP;
				InclDemand = result.InclDemand;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
