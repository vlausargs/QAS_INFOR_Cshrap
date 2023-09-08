//PROJECT NAME: Production
//CLASS NAME: RSQC_GetRcvrLocLot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetRcvrLocLot : IRSQC_GetRcvrLocLot
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_GetRcvrLocLot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string o_lot,
		string o_loc,
		string Infobar) RSQC_GetRcvrLocLotSp(int? i_vrma,
		string o_lot,
		string o_loc,
		string Infobar)
		{
			QCRcvrNumType _i_vrma = i_vrma;
			LotType _o_lot = o_lot;
			LocType _o_loc = o_loc;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_GetRcvrLocLotSp";
				
				appDB.AddCommandParameter(cmd, "i_vrma", _i_vrma, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_lot", _o_lot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_loc", _o_loc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_lot = _o_lot;
				o_loc = _o_loc;
				Infobar = _Infobar;
				
				return (Severity, o_lot, o_loc, Infobar);
			}
		}
	}
}
