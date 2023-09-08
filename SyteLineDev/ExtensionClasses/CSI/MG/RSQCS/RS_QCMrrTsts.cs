//PROJECT NAME: RSQCSExt
//CLASS NAME: RS_QCMrrTsts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Quality;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.RSQCS
{
	[IDOExtensionClass("RS_QCMrrTsts")]
	public class RS_QCMrrTsts : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CreateTestXRefSp(int? i_rcvr,
		DateTime? i_trans_date,
		int? i_sequence,
		string i_doc_num,
		string i_type,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRSQC_CreateTestXRefExt = new RSQC_CreateTestXRefFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRSQC_CreateTestXRefExt.RSQC_CreateTestXRefSp(i_rcvr,
				i_trans_date,
				i_sequence,
				i_doc_num,
				i_type,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
