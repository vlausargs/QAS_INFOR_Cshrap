//PROJECT NAME: PPIndPackExt
//CLASS NAME: PPParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.PrintingPackaging;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.PPIndPack
{
    [IDOExtensionClass("PPParms")]
    public class PPParms : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetStandardUMParmSp(ref string LinearDimensionUM,
		                               ref string DensityUM,
		                               ref string AreaUM,
		                               ref string BulkMassUM,
		                               ref string ReamMassUM,
		                               ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPP_GetStandardUMParmExt = new PP_GetStandardUMParmFactory().Create(appDb);
				
				var result = iPP_GetStandardUMParmExt.PP_GetStandardUMParmSp(LinearDimensionUM,
				                                                             DensityUM,
				                                                             AreaUM,
				                                                             BulkMassUM,
				                                                             ReamMassUM,
				                                                             Infobar);
				
				int Severity = result.ReturnCode.Value;
				LinearDimensionUM = result.LinearDimensionUM;
				DensityUM = result.DensityUM;
				AreaUM = result.AreaUM;
				BulkMassUM = result.BulkMassUM;
				ReamMassUM = result.ReamMassUM;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
