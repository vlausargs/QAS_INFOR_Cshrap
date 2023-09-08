//PROJECT NAME: Data
//CLASS NAME: CoAuditDiscount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CoAuditDiscount : ICoAuditDiscount
	{
		readonly IApplicationDB appDB;
		
		public CoAuditDiscount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CoAuditDiscountSp(
			string PCoNum,
			decimal? POldCoDisc,
			decimal? PNewCoDisc,
			string Infobar)
		{
			CoNumType _PCoNum = PCoNum;
			OrderDiscType _POldCoDisc = POldCoDisc;
			OrderDiscType _PNewCoDisc = PNewCoDisc;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoAuditDiscountSp";
				
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldCoDisc", _POldCoDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewCoDisc", _PNewCoDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
