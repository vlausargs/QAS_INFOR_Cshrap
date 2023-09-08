//PROJECT NAME: VATTransferExt
//CLASS NAME: MXVchDist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance.Mexican;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.VATTransfer
{
	[IDOExtensionClass("MXVchDist")]
	public class MXVchDist : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MXTaxRegValidateSp([Optional] string TaxRegNum,
		[Optional] string TaxRegForeing,
		[Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iMXTaxRegValidateExt = new MXTaxRegValidateFactory().Create(appDb);
				
				var result = iMXTaxRegValidateExt.MXTaxRegValidateSp(TaxRegNum,
				TaxRegForeing,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
