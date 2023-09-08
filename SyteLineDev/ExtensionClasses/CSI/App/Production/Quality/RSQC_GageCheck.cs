//PROJECT NAME: Production
//CLASS NAME: RSQC_GageCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GageCheck : IRSQC_GageCheck
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_GageCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? o_gage_expired,
		string Infobar) RSQC_GageCheckSp(Guid? i_gage,
		int? o_gage_expired,
		string Infobar)
		{
			RowPointerType _i_gage = i_gage;
			ListYesNoType _o_gage_expired = o_gage_expired;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_GageCheckSp";
				
				appDB.AddCommandParameter(cmd, "i_gage", _i_gage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_gage_expired", _o_gage_expired, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_gage_expired = _o_gage_expired;
				Infobar = _Infobar;
				
				return (Severity, o_gage_expired, Infobar);
			}
		}
	}
}
