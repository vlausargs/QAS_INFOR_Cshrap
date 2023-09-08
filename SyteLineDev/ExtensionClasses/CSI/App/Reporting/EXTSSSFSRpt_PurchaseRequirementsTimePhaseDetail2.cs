//PROJECT NAME: Reporting
//CLASS NAME: EXTSSSFSRpt_PurchaseRequirementsTimePhaseDetail2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class EXTSSSFSRpt_PurchaseRequirementsTimePhaseDetail2 : IEXTSSSFSRpt_PurchaseRequirementsTimePhaseDetail2
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSFSRpt_PurchaseRequirementsTimePhaseDetail2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? t_sro_date,
			int? t_sroitem_row_idx) EXTSSSFSRpt_PurchaseRequirementsTimePhaseDetail2Sp(
			string iItem,
			string iWhseStarting,
			string iWhseEnding,
			int? iShowDepl,
			DateTime? t_sro_date,
			int? t_sroitem_row_idx)
		{
			ItemType _iItem = iItem;
			WhseType _iWhseStarting = iWhseStarting;
			WhseType _iWhseEnding = iWhseEnding;
			FlagNyType _iShowDepl = iShowDepl;
			DateType _t_sro_date = t_sro_date;
			IntType _t_sroitem_row_idx = t_sroitem_row_idx;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSFSRpt_PurchaseRequirementsTimePhaseDetail2Sp";
				
				appDB.AddCommandParameter(cmd, "iItem", _iItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iWhseStarting", _iWhseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iWhseEnding", _iWhseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iShowDepl", _iShowDepl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "t_sro_date", _t_sro_date, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "t_sroitem_row_idx", _t_sroitem_row_idx, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				t_sro_date = _t_sro_date;
				t_sroitem_row_idx = _t_sroitem_row_idx;
				
				return (Severity, t_sro_date, t_sroitem_row_idx);
			}
		}
	}
}
