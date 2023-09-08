//PROJECT NAME: DataCollection
//CLASS NAME: DccoP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DccoP : IDccoP
	{
		readonly IApplicationDB appDB;
		
		
		public DccoP(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DccoPSp(int? FromEdi = 0,
		decimal? ProcessId = null,
		DateTime? PostDate = null,
		string Infobar = null,
		string DocumentNum = null)
		{
			ListYesNoType _FromEdi = FromEdi;
			TokenType _ProcessId = ProcessId;
			DateType _PostDate = PostDate;
			InfobarType _Infobar = Infobar;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DccoPSp";
				
				appDB.AddCommandParameter(cmd, "FromEdi", _FromEdi, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostDate", _PostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
