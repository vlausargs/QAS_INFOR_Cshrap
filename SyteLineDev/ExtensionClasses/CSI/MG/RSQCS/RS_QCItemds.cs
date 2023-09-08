//PROJECT NAME: RSQCSExt
//CLASS NAME: RS_QCItemds.cs

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
    [IDOExtensionClass("RS_QCItemds")]
    public class RS_QCItemds : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_SetTestValuesSp(string i_item,
		string i_ref_type,
		string i_entity,
		int? i_testseq,
		ref int? o_seq,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_SetTestValuesExt = new RSQC_SetTestValuesFactory().Create(appDb);
				
				var result = iRSQC_SetTestValuesExt.RSQC_SetTestValuesSp(i_item,
				i_ref_type,
				i_entity,
				i_testseq,
				o_seq,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_seq = result.o_seq;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CopyTestsSp(string i_item,
		string i_ref_type,
		string i_entity,
		[Optional] string i_test_type,
		int? i_test_seq,
		string i_item2,
		string i_ref_type2,
		string i_entity2,
		[Optional] string i_test_type2,
		int? i_test_seq2,
		string i_item3,
		string i_ref_type3,
		string i_entity3,
		[Optional] string i_test_type3,
		int? i_test_seq3,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_CopyTestsExt = new RSQC_CopyTestsFactory().Create(appDb);
				
				var result = iRSQC_CopyTestsExt.RSQC_CopyTestsSp(i_item,
				i_ref_type,
				i_entity,
				i_test_type,
				i_test_seq,
				i_item2,
				i_ref_type2,
				i_entity2,
				i_test_type2,
				i_test_seq2,
				i_item3,
				i_ref_type3,
				i_entity3,
				i_test_type3,
				i_test_seq3,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_ParmgnSp(ref int? o_check_gage,
		ref int? o_check_method,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_ParmgnExt = new RSQC_ParmgnFactory().Create(appDb);
				
				var result = iRSQC_ParmgnExt.RSQC_ParmgnSp(o_check_gage,
				o_check_method,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_check_gage = result.o_check_gage;
				o_check_method = result.o_check_method;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
