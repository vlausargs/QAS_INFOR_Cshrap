//PROJECT NAME: Data
//CLASS NAME: GetUserPOReqLimit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetUserPOReqLimit : IGetUserPOReqLimit
	{
		readonly IApplicationDB appDB;
		
		public GetUserPOReqLimit(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PreqLimit,
			decimal? PreqItemLimit,
			string Infobar) GetUserPOReqLimitSp(
			string UserName,
			decimal? PreqLimit,
			decimal? PreqItemLimit,
			string Infobar)
		{
			UsernameType _UserName = UserName;
			AmountType _PreqLimit = PreqLimit;
			AmountType _PreqItemLimit = PreqItemLimit;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetUserPOReqLimitSp";
				
				appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreqLimit", _PreqLimit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PreqItemLimit", _PreqItemLimit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PreqLimit = _PreqLimit;
				PreqItemLimit = _PreqItemLimit;
				Infobar = _Infobar;
				
				return (Severity, PreqLimit, PreqItemLimit, Infobar);
			}
		}
	}
}
