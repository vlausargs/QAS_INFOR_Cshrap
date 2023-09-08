//PROJECT NAME: ProjectsExt
//CLASS NAME: SLUnPostedTransactionsViews.cs

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
	[IDOExtensionClass("SLUnPostedTransactionsViews")]
	public class SLUnPostedTransactionsViews : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetUnPostedProdTransSp(ref int? UnpostedDCSFC,
		ref int? UnpostedDCJM,
		ref int? UnpostedDCJMRcpt,
		ref int? UnpostedJobLaborTrans,
		ref int? UnpostedDCJIT,
		ref int? UnpostedDCPS,
		ref int? UnpostedDCPSScrap,
		ref int? UnpostedJobMatlTrans,
		ref int? UnpostedDCSFCWCLabor,
		ref int? UnpostedDCSFCWCMachine,
		ref int? UnpostedDCWC)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetUnPostedProdTransExt = new GetUnPostedProdTransFactory().Create(appDb);
				
				var result = iGetUnPostedProdTransExt.GetUnPostedProdTransSp(UnpostedDCSFC,
				UnpostedDCJM,
				UnpostedDCJMRcpt,
				UnpostedJobLaborTrans,
				UnpostedDCJIT,
				UnpostedDCPS,
				UnpostedDCPSScrap,
				UnpostedJobMatlTrans,
				UnpostedDCSFCWCLabor,
				UnpostedDCSFCWCMachine,
				UnpostedDCWC);
				
				int Severity = result.ReturnCode.Value;
				UnpostedDCSFC = result.UnpostedDCSFC;
				UnpostedDCJM = result.UnpostedDCJM;
				UnpostedDCJMRcpt = result.UnpostedDCJMRcpt;
				UnpostedJobLaborTrans = result.UnpostedJobLaborTrans;
				UnpostedDCJIT = result.UnpostedDCJIT;
				UnpostedDCPS = result.UnpostedDCPS;
				UnpostedDCPSScrap = result.UnpostedDCPSScrap;
				UnpostedJobMatlTrans = result.UnpostedJobMatlTrans;
				UnpostedDCSFCWCLabor = result.UnpostedDCSFCWCLabor;
				UnpostedDCSFCWCMachine = result.UnpostedDCSFCWCMachine;
				UnpostedDCWC = result.UnpostedDCWC;
				return Severity;
			}
		}
	}
}
