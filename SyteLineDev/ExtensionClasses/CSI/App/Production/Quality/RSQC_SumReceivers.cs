//PROJECT NAME: Production
//CLASS NAME: RSQC_SumReceivers.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_SumReceivers : IRSQC_SumReceivers
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_SumReceivers(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? qty_received_tot,
		decimal? qty_accepted_tot,
		decimal? qty_rejected_tot,
		decimal? qty_hold_tot,
		string Infobar) RSQC_SumReceiversSp(string i_item,
		string i_ref_type,
		string i_entity,
		string i_test_type = null,
		int? i_test_seq = null,
		decimal? qty_received_tot = null,
		decimal? qty_accepted_tot = null,
		decimal? qty_rejected_tot = null,
		decimal? qty_hold_tot = null,
		string Infobar = null)
		{
			ItemType _i_item = i_item;
			QCRefType _i_ref_type = i_ref_type;
			QCDocNumType _i_entity = i_entity;
			QCCharType _i_test_type = i_test_type;
			QCTestSeqType _i_test_seq = i_test_seq;
			QtyUnitType _qty_received_tot = qty_received_tot;
			QtyUnitType _qty_accepted_tot = qty_accepted_tot;
			QtyUnitType _qty_rejected_tot = qty_rejected_tot;
			QtyUnitType _qty_hold_tot = qty_hold_tot;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_SumReceiversSp";
				
				appDB.AddCommandParameter(cmd, "i_item", _i_item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_ref_type", _i_ref_type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_entity", _i_entity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_test_type", _i_test_type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_test_seq", _i_test_seq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "qty_received_tot", _qty_received_tot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "qty_accepted_tot", _qty_accepted_tot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "qty_rejected_tot", _qty_rejected_tot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "qty_hold_tot", _qty_hold_tot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				qty_received_tot = _qty_received_tot;
				qty_accepted_tot = _qty_accepted_tot;
				qty_rejected_tot = _qty_rejected_tot;
				qty_hold_tot = _qty_hold_tot;
				Infobar = _Infobar;
				
				return (Severity, qty_received_tot, qty_accepted_tot, qty_rejected_tot, qty_hold_tot, Infobar);
			}
		}
	}
}
