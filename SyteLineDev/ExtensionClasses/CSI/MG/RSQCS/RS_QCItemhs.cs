//PROJECT NAME: RSQCSExt
//CLASS NAME: RS_QCItemhs.cs

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
    [IDOExtensionClass("RS_QCItemhs")]
    public class RS_QCItemhs : CSIExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_SumReceiversSp(string i_item,
		string i_ref_type,
		string i_entity,
		[Optional] string i_test_type,
		int? i_test_seq,
		ref decimal? qty_received_tot,
		ref decimal? qty_accepted_tot,
		ref decimal? qty_rejected_tot,
		ref decimal? qty_hold_tot,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_SumReceiversExt = new RSQC_SumReceiversFactory().Create(appDb);
				
				var result = iRSQC_SumReceiversExt.RSQC_SumReceiversSp(i_item,
				i_ref_type,
				i_entity,
				i_test_type,
				i_test_seq,
				qty_received_tot,
				qty_accepted_tot,
				qty_rejected_tot,
				qty_hold_tot,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				qty_received_tot = result.qty_received_tot;
				qty_accepted_tot = result.qty_accepted_tot;
				qty_rejected_tot = result.qty_rejected_tot;
				qty_hold_tot = result.qty_hold_tot;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CheckTestsSp(string i_item,
		string i_ref_type,
		string i_entity,
		string i_test_type,
		int? i_test_seq,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_CheckTestsExt = new RSQC_CheckTestsFactory().Create(appDb);
				
				var result = iRSQC_CheckTestsExt.RSQC_CheckTestsSp(i_item,
				i_ref_type,
				i_entity,
				i_test_type,
				i_test_seq,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_SetItemTestSeqSp(string i_item,
		string i_ref_type,
		string i_entity,
		ref int? o_testseq,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_SetItemTestSeqExt = new RSQC_SetItemTestSeqFactory().Create(appDb);
				
				var result = iRSQC_SetItemTestSeqExt.RSQC_SetItemTestSeqSp(i_item,
				i_ref_type,
				i_entity,
				o_testseq,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_testseq = result.o_testseq;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_UpdateIpItemsSp()
		{
            var iRSQC_UpdateIpItemsExt = new RSQC_UpdateIpItemsFactory().Create(this, true);

            var result = iRSQC_UpdateIpItemsExt.RSQC_UpdateIpItemsSp();

            return result ?? 0;
        }
    }
}
