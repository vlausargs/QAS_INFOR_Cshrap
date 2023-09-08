//PROJECT NAME: Production
//CLASS NAME: RSQC_RcvrUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_RcvrUpdate : IRSQC_RcvrUpdate
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_RcvrUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) RSQC_RcvrUpdateSp(int? RcvrNum = null,
		decimal? Qty = null,
		int? Complete = null,
		string Infobar = null)
		{
			QCRcvrNumType _RcvrNum = RcvrNum;
			QtyUnitType _Qty = Qty;
			ListYesNoType _Complete = Complete;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_RcvrUpdateSp";
				
				appDB.AddCommandParameter(cmd, "RcvrNum", _RcvrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Complete", _Complete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
