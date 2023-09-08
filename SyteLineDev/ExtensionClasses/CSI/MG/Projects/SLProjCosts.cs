//PROJECT NAME: ProjectsExt
//CLASS NAME: SLProjCosts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Projects;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Projects
{
	[IDOExtensionClass("SLProjCosts")]
	public class SLProjCosts : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProjcostRollFcstSp(string Process,
		                                    string ProjNum,
		                                    int? FromTaskNum,
		                                    int? ToTaskNum,
		                                    string FromCostCode,
		                                    string ToCostCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iProjcostRollFcstExt = new ProjcostRollFcstFactory().Create(appDb, bunchedLoadCollection);
				
				DataTable dt = iProjcostRollFcstExt.ProjcostRollFcstSp(Process,
				                                                       ProjNum,
				                                                       FromTaskNum,
				                                                       ToTaskNum,
				                                                       FromCostCode,
				                                                       ToCostCode);
				
				return dt;
			}
		}






		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckProjectResourceExistSp(string ProjNum,
		int? TaskNum,
		string CostCode,
		string Type,
		string CostCodeType,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCheckProjectResourceExistExt = new CheckProjectResourceExistFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCheckProjectResourceExistExt.CheckProjectResourceExistSp(ProjNum,
				TaskNum,
				CostCode,
				Type,
				CostCodeType,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CtcLogCreateSp(string FromProjNum,
		string ToProjNum,
		int? FromTaskNum,
		int? ToTaskNum,
		string FromCostCode,
		string ToCostCode,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCtcLogCreateExt = new CtcLogCreateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCtcLogCreateExt.CtcLogCreateSp(FromProjNum,
				ToProjNum,
				FromTaskNum,
				ToTaskNum,
				FromCostCode,
				ToCostCode,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjcostDelSp(string ProjNum,
		int? TaskNum,
		int? Seq,
		string CostCode,
		decimal? Units,
		decimal? FcstCost,
		string CostCodeType,
		decimal? FcstCostAcc,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProjcostDelExt = new ProjcostDelFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProjcostDelExt.ProjcostDelSp(ProjNum,
				TaskNum,
				Seq,
				CostCode,
				Units,
				FcstCost,
				CostCodeType,
				FcstCostAcc,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
