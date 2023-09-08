//PROJECT NAME: RSQCSExt
//CLASS NAME: RS_QCTesths.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Quality;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.ExternalContracts.FactoryTrack;

namespace CSI.MG.RSQCS
{
	[IDOExtensionClass("RS_QCTesths")]
	public class RS_QCTesths : CSIExtensionClassBase, IExtFTRS_QCTesths
	{

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RSQC_GetUser3Sp(ref string o_user,
            ref string Infobar)
        {
            var iRSQC_GetUser3Ext = new RSQC_GetUser3Factory().Create(this, true);

            var result = iRSQC_GetUser3Ext.RSQC_GetUser3Sp(o_user,
                Infobar);

            o_user = result.o_user;
            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CreateTesthEsigSp(Guid? TesteRowpointer,
		string UserName,
		string ReasonCode,
		Guid? EsigRowpointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_CreateTesthEsigExt = new RSQC_CreateTesthEsigFactory().Create(appDb);
				
				var result = iRSQC_CreateTesthEsigExt.RSQC_CreateTesthEsigSp(TesteRowpointer,
				UserName,
				ReasonCode,
				EsigRowpointer);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetNumSamplesSp(int? rcvr_num,
		ref int? o_samples)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GetNumSamplesExt = new RSQC_GetNumSamplesFactory().Create(appDb);
				
				var result = iRSQC_GetNumSamplesExt.RSQC_GetNumSamplesSp(rcvr_num,
				o_samples);
				
				int Severity = result.ReturnCode.Value;
				o_samples = result.o_samples;
				return Severity;
			}
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RSQC_GetUserSp(ref string o_user,
            ref string Infobar)
        {
            var iRSQC_GetUserExt = new RSQC_GetUserFactory().Create(this, true);

            var result = iRSQC_GetUserExt.RSQC_GetUserSp(o_user,
                Infobar);

            o_user = result.o_user;
            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CreateBatchTestsSp(int? i_rcvr,
		DateTime? i_trans_date,
		ref string o_message,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRSQC_CreateBatchTestsExt = new RSQC_CreateBatchTestsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRSQC_CreateBatchTestsExt.RSQC_CreateBatchTestsSp(i_rcvr,
				i_trans_date,
				o_message,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_message = result.o_message;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CreateEachTestsSp(int? i_rcvr,
		DateTime? i_trans_date,
		decimal? i_num_entries,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRSQC_CreateEachTestsExt = new RSQC_CreateEachTestsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRSQC_CreateEachTestsExt.RSQC_CreateEachTestsSp(i_rcvr,
				i_trans_date,
				i_num_entries,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CreateFailTestsSp(int? i_rcvr,
		DateTime? i_trans_date,
		decimal? i_num_entries,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRSQC_CreateFailTestsExt = new RSQC_CreateFailTestsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRSQC_CreateFailTestsExt.RSQC_CreateFailTestsSp(i_rcvr,
				i_trans_date,
				i_num_entries,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CreateSerialDefectsSp(int? i_rcvr,
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
				
				var iRSQC_CreateSerialDefectsExt = new RSQC_CreateSerialDefectsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRSQC_CreateSerialDefectsExt.RSQC_CreateSerialDefectsSp(i_rcvr,
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

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CreateUpdateTestSummarySp(int? i_rcvr,
		DateTime? i_trans_date,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRSQC_CreateUpdateTestSummaryExt = new RSQC_CreateUpdateTestSummaryFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRSQC_CreateUpdateTestSummaryExt.RSQC_CreateUpdateTestSummarySp(i_rcvr,
				i_trans_date,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetTestDataSp(int? i_rcvr,
		DateTime? i_trans_date,
		ref string o_each,
		ref string o_batch,
		ref string o_summary,
		ref string o_fail,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRSQC_GetTestDataExt = new RSQC_GetTestDataFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRSQC_GetTestDataExt.RSQC_GetTestDataSp(i_rcvr,
				i_trans_date,
				o_each,
				o_batch,
				o_summary,
				o_fail,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_each = result.o_each;
				o_batch = result.o_batch;
				o_summary = result.o_summary;
				o_fail = result.o_fail;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
