//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateTesthEsig.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CreateTesthEsig : IRSQC_CreateTesthEsig
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CreateTesthEsig(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? RSQC_CreateTesthEsigSp(Guid? TesteRowpointer,
		string UserName,
		string ReasonCode,
		Guid? EsigRowpointer)
		{
			RowPointerType _TesteRowpointer = TesteRowpointer;
			UsernameType _UserName = UserName;
			ReasonCodeType _ReasonCode = ReasonCode;
			RowPointerType _EsigRowpointer = EsigRowpointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CreateTesthEsigSp";
				
				appDB.AddCommandParameter(cmd, "TesteRowpointer", _TesteRowpointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCode", _ReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EsigRowpointer", _EsigRowpointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
