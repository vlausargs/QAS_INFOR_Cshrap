//PROJECT NAME: ProjectsExt
//CLASS NAME: SLProjParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Projects;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Projects
{
	[IDOExtensionClass("SLProjParms")]
	public class SLProjParms : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetProjParmDevPercSp(ref decimal? pSchVarLowDev,
		                                ref decimal? pSchVarUpDev,
		                                ref byte? pSchVarPri,
		                                ref decimal? pCostCodeVarLowDev,
		                                ref decimal? pCostCodeVarUpDev,
		                                ref byte? pCostCodeVarPri)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetProjParmDevPercExt = new GetProjParmDevPercFactory().Create(appDb);
				
				int Severity = iGetProjParmDevPercExt.GetProjParmDevPercSp(ref pSchVarLowDev,
				                                                           ref pSchVarUpDev,
				                                                           ref pSchVarPri,
				                                                           ref pCostCodeVarLowDev,
				                                                           ref pCostCodeVarUpDev,
				                                                           ref pCostCodeVarPri);
				
				return Severity;
			}
		}
	}
}
