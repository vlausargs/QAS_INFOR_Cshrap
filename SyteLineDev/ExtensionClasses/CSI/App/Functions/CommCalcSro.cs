//PROJECT NAME: Data
//CLASS NAME: CommCalcSro.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CommCalcSro : ICommCalcSro
	{
		readonly IApplicationDB appDB;
		
		public CommCalcSro(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CommCalcSroSp(
			string InvHdrInvNum,
			string TSroNum,
			string InvCred,
			string Infobar)
		{
			InvNumType _InvHdrInvNum = InvHdrInvNum;
			FSSRONumType _TSroNum = TSroNum;
			StringType _InvCred = InvCred;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CommCalcSroSp";
				
				appDB.AddCommandParameter(cmd, "InvHdrInvNum", _InvHdrInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TSroNum", _TSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvCred", _InvCred, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
