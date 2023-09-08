//PROJECT NAME: Reporting
//CLASS NAME: EXTSSSFSRpt_PurchaseRequirementsTimePhaseDetail3.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class EXTSSSFSRpt_PurchaseRequirementsTimePhaseDetail3 : IEXTSSSFSRpt_PurchaseRequirementsTimePhaseDetail3
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSFSRpt_PurchaseRequirementsTimePhaseDetail3(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string t_stat,
			decimal? t_req,
			string t_ref,
			string t_name,
			int? t_sroitem_row_idx,
			decimal? t_on_hand,
			DateTime? t_sro_date) EXTSSSFSRpt_PurchaseRequirementsTimePhaseDetail3Sp(
			string t_stat,
			decimal? t_req,
			string t_ref,
			string t_name,
			int? t_sroitem_row_idx,
			decimal? t_on_hand,
			DateTime? t_sro_date)
		{
			JobStatusType _t_stat = t_stat;
			QtyTotlType _t_req = t_req;
			StringType _t_ref = t_ref;
			NameType _t_name = t_name;
			IntType _t_sroitem_row_idx = t_sroitem_row_idx;
			QtyTotlType _t_on_hand = t_on_hand;
			DateType _t_sro_date = t_sro_date;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSFSRpt_PurchaseRequirementsTimePhaseDetail3Sp";
				
				appDB.AddCommandParameter(cmd, "t_stat", _t_stat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "t_req", _t_req, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "t_ref", _t_ref, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "t_name", _t_name, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "t_sroitem_row_idx", _t_sroitem_row_idx, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "t_on_hand", _t_on_hand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "t_sro_date", _t_sro_date, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				t_stat = _t_stat;
				t_req = _t_req;
				t_ref = _t_ref;
				t_name = _t_name;
				t_sroitem_row_idx = _t_sroitem_row_idx;
				t_on_hand = _t_on_hand;
				t_sro_date = _t_sro_date;
				
				return (Severity, t_stat, t_req, t_ref, t_name, t_sroitem_row_idx, t_on_hand, t_sro_date);
			}
		}
	}
}
