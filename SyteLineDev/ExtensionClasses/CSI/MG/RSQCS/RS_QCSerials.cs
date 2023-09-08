//PROJECT NAME: MG
//CLASS NAME: RS_QCSerials.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Quality;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.RSQCS
{
	[IDOExtensionClass("RS_QCSerials")]
	public class RS_QCSerials : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CreateSerialTestsSp(int? i_rcvr,
		DateTime? i_trans_date,
		string i_ref_type,
		string i_item,
		int? i_oper_num,
		string i_entity,
		string i_ref_num,
		int? i_ref_line,
		int? i_ref_release,
		string i_test_type,
		int? i_test_seq,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRSQC_CreateSerialTestsExt = new RSQC_CreateSerialTestsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRSQC_CreateSerialTestsExt.RSQC_CreateSerialTestsSp(i_rcvr,
				i_trans_date,
				i_ref_type,
				i_item,
				i_oper_num,
				i_entity,
				i_ref_num,
				i_ref_line,
				i_ref_release,
				i_test_type,
				i_test_seq,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
