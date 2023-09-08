//PROJECT NAME: MaterialExt
//CLASS NAME: SLTmpItemPortalPriceErrors.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLTmpItemPortalPriceErrors")]
    public class SLTmpItemPortalPriceErrors : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PortalPriceActivationValidationSp([Optional] string Site,
		                                             [Optional, DefaultParameterValue("P")] string Process,
		[Optional] ref string Infobar,
		[Optional] int? BGTaskID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPortalPriceActivationValidationExt = new PortalPriceActivationValidationFactory().Create(appDb);
				
				var result = iPortalPriceActivationValidationExt.PortalPriceActivationValidationSp(Site,
				                                                                                   Process,
				                                                                                   Infobar,
				                                                                                   BGTaskID);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
