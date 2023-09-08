//PROJECT NAME: Logistics
//CLASS NAME: CpSoCpSoSo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CpSoCpSoSo : ICpSoCpSoSo
	{
		readonly IApplicationDB appDB;
		
		
		public CpSoCpSoSo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? POrderBal,
		string Infobar) CpSoCpSoSoSp(string PCoNum,
		int? TPlaces,
		decimal? POrderBal,
		string Infobar)
		{
			CoNumType _PCoNum = PCoNum;
			DecimalPlacesType _TPlaces = TPlaces;
			GenericDecimalType _POrderBal = POrderBal;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CpSoCpSoSoSp";
				
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TPlaces", _TPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrderBal", _POrderBal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				POrderBal = _POrderBal;
				Infobar = _Infobar;
				
				return (Severity, POrderBal, Infobar);
			}
		}
	}
}
