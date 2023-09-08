//PROJECT NAME: RSQCSExt
//CLASS NAME: RS_QCItemfs.cs

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
    [IDOExtensionClass("RS_QCItemfs")]
    public class RS_QCItemfs : ExtensionClassBase
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
    }
}
