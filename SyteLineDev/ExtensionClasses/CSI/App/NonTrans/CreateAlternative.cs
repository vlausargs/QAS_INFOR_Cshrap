//PROJECT NAME: NonTrans
//CLASS NAME: CreateAlternative.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.NonTrans
{
	public interface ICreateAlternative
	{
		(int? ReturnCode, string Infobar) CreateAlternativeSp(short? AltNo,
		string Infobar);
	}
	
	public class CreateAlternative : ICreateAlternative
	{
		readonly IApplicationDB appDB;
		
		public CreateAlternative(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CreateAlternativeSp(short? AltNo,
		string Infobar)
		{
			ApsAltNoType _AltNo = AltNo;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateAlternativeSp";
				
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
