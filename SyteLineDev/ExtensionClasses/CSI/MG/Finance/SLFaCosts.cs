//PROJECT NAME: FinanceExt
//CLASS NAME: SLFaCosts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Finance
{
	[IDOExtensionClass("SLFaCosts")]
	public class SLFaCosts : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FaCostsNextSeqSp(string pFaNum,
		ref int? pSeq,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFaCostsNextSeqExt = new FaCostsNextSeqFactory().Create(appDb);
				
				var result = iFaCostsNextSeqExt.FaCostsNextSeqSp(pFaNum,
				pSeq,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				pSeq = result.pSeq;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
