//PROJECT NAME: Material
//CLASS NAME: DeleteTrnLineItemLogEntries.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class DeleteTrnLineItemLogEntries : IDeleteTrnLineItemLogEntries
	{
		readonly IApplicationDB appDB;
		
		
		public DeleteTrnLineItemLogEntries(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DeleteTrnLineItemLogEntriesSp(DateTime? SActivityDate,
		DateTime? EActivityDate,
		string STrnNum,
		string ETrnNum,
		int? STrnLine,
		int? ETrnLine,
		int? CreateInitial,
		string Infobar)
		{
			DateType _SActivityDate = SActivityDate;
			DateType _EActivityDate = EActivityDate;
			TrnNumType _STrnNum = STrnNum;
			TrnNumType _ETrnNum = ETrnNum;
			TrnLineType _STrnLine = STrnLine;
			TrnLineType _ETrnLine = ETrnLine;
			SmallintType _CreateInitial = CreateInitial;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeleteTrnLineItemLogEntriesSp";
				
				appDB.AddCommandParameter(cmd, "SActivityDate", _SActivityDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EActivityDate", _EActivityDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "STrnNum", _STrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ETrnNum", _ETrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "STrnLine", _STrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ETrnLine", _ETrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateInitial", _CreateInitial, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
