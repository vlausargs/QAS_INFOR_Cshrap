//PROJECT NAME: MaterialExt
//CLASS NAME: SLTrxRestrictCodeTrans.cs

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
	[IDOExtensionClass("SLTrxRestrictCodeTrans")]
	public class SLTrxRestrictCodeTrans : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateRestrictedTransSp([Optional] string Item,
		[Optional] string Lot,
		[Optional] string SerialNums,
		string MatlTransType,
		ref string Infobar,
		[Optional, DefaultParameterValue(0)] decimal? RefId,
		[Optional] string RefType,
		[Optional] Guid? ProcessId,
		[Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iValidateRestrictedTransExt = new ValidateRestrictedTransFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iValidateRestrictedTransExt.ValidateRestrictedTransSp(Item,
				Lot,
				SerialNums,
				MatlTransType,
				Infobar,
				RefId,
				RefType,
				ProcessId,
				Site);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
