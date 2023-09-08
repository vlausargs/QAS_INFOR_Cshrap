//PROJECT NAME: CodesExt
//CLASS NAME: SLAddressTaxcodeDefaults.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Codes;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Codes
{
	[IDOExtensionClass("SLAddressTaxcodeDefaults")]
	public class SLAddressTaxcodeDefaults : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetTaxCodeDefaultsSp([Optional] string Country,
		[Optional] string State,
		[Optional] string Zip,
		[Optional] ref string TaxCode1,
		[Optional] ref string TaxCode2,
		[Optional, DefaultParameterValue(0)] ref int? TaxCodeFound,
		[Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetTaxCodeDefaultsExt = new GetTaxCodeDefaultsFactory().Create(appDb);
				
				var result = iGetTaxCodeDefaultsExt.GetTaxCodeDefaultsSp(Country,
				State,
				Zip,
				TaxCode1,
				TaxCode2,
				TaxCodeFound,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				TaxCode1 = result.TaxCode1;
				TaxCode2 = result.TaxCode2;
				TaxCodeFound = result.TaxCodeFound;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
