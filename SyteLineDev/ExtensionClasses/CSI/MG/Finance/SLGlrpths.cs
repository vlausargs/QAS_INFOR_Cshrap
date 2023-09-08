//PROJECT NAME: FinanceExt
//CLASS NAME: SLGlrpths.cs

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
	[IDOExtensionClass("SLGlrpths")]
	public class SLGlrpths : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FinStmtPreviewDefaultsSp(ref string pSource1,
		ref string pRange1,
		ref int? pFiscalYear1,
		ref int? pCurPeriod1,
		ref string pSource2,
		ref string pRange2,
		ref int? pFiscalYear2,
		ref int? pCurPeriod2,
		ref DateTime? pCurPerStart1,
		ref DateTime? pCurPerEnd1,
		ref DateTime? pCurPerStart2,
		ref DateTime? pCurPerEnd2,
		string pReportID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFinStmtPreviewDefaultsExt = new FinStmtPreviewDefaultsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFinStmtPreviewDefaultsExt.FinStmtPreviewDefaultsSp(pSource1,
				pRange1,
				pFiscalYear1,
				pCurPeriod1,
				pSource2,
				pRange2,
				pFiscalYear2,
				pCurPeriod2,
				pCurPerStart1,
				pCurPerEnd1,
				pCurPerStart2,
				pCurPerEnd2,
				pReportID);
				
				int Severity = result.ReturnCode.Value;
				pSource1 = result.pSource1;
				pRange1 = result.pRange1;
				pFiscalYear1 = result.pFiscalYear1;
				pCurPeriod1 = result.pCurPeriod1;
				pSource2 = result.pSource2;
				pRange2 = result.pRange2;
				pFiscalYear2 = result.pFiscalYear2;
				pCurPeriod2 = result.pCurPeriod2;
				pCurPerStart1 = result.pCurPerStart1;
				pCurPerEnd1 = result.pCurPerEnd1;
				pCurPerStart2 = result.pCurPerStart2;
				pCurPerEnd2 = result.pCurPerEnd2;
				return Severity;
			}
		}
	}
}
