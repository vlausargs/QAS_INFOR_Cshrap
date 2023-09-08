//PROJECT NAME: Finance
//CLASS NAME: DeprMethodValidate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class DeprMethodValidate : IDeprMethodValidate
	{
		readonly IApplicationDB appDB;
		
		
		public DeprMethodValidate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Method,
		string Infobar) DeprMethodValidateSp(string Method,
		string Infobar)
		{
			DeprMethodType _Method = Method;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeprMethodValidateSp";
				
				appDB.AddCommandParameter(cmd, "Method", _Method, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Method = _Method;
				Infobar = _Infobar;
				
				return (Severity, Method, Infobar);
			}
		}
	}
}
