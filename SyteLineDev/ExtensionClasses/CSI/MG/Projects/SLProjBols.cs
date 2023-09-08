//PROJECT NAME: ProjectsExt
//CLASS NAME: SLProjBols.cs

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
	[IDOExtensionClass("SLProjBols")]
	public class SLProjBols : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ASNProjectRecalcSp(string ProjNum,
		                              string BolNum,
		                              ref decimal? NewFreightCharges,
		                              ref decimal? NewCodAmount,
		                              ref decimal? NewTotalCharges,
		                              ref string PromptMsg,
		                              ref string PromptButtons)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iASNProjectRecalcExt = new ASNProjectRecalcFactory().Create(appDb);
				
				int Severity = iASNProjectRecalcExt.ASNProjectRecalcSp(ProjNum,
				                                                       BolNum,
				                                                       ref NewFreightCharges,
				                                                       ref NewCodAmount,
				                                                       ref NewTotalCharges,
				                                                       ref PromptMsg,
				                                                       ref PromptButtons);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjBolPackSp(string PProjNum,
		                         int? PPackSlip,
		                         ref string PBolNum,
		                         ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iProjBolPackExt = new ProjBolPackFactory().Create(appDb);
				
				int Severity = iProjBolPackExt.ProjBolPackSp(PProjNum,
				                                             PPackSlip,
				                                             ref PBolNum,
				                                             ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjBolSp(string ProjNum,
		                     ref string BolNum,
		                     ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iProjBolExt = new ProjBolFactory().Create(appDb);
				
				int Severity = iProjBolExt.ProjBolSp(ProjNum,
				                                     ref BolNum,
				                                     ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjInitpbolSp(string PProjNum,
		                          string PBolNum,
		                          int? PPackNum,
		                          byte? PCopyFromPackSlip)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iProjInitpbolExt = new ProjInitpbolFactory().Create(appDb);
				
				int Severity = iProjInitpbolExt.ProjInitpbolSp(PProjNum,
				                                               PBolNum,
				                                               PPackNum,
				                                               PCopyFromPackSlip);
				
				return Severity;
			}
		}
	}
}
