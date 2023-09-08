//PROJECT NAME: Finance
//CLASS NAME: GenerateAppmtd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AP
{
	public class GenerateAppmtd : IGenerateAppmtd
	{
		readonly IApplicationDB appDB;
		
		public GenerateAppmtd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? PCreated,
			int? PUpdated,
			int? PDeleted,
			string Infobar) GenerateAppmtdSp(
			Guid? PSessionId,
			Guid? PAppmtRowid,
			int? PCreated,
			int? PUpdated,
			int? PDeleted,
			string Infobar)
		{
			RowPointerType _PSessionId = PSessionId;
			RowPointerType _PAppmtRowid = PAppmtRowid;
			GenericNoType _PCreated = PCreated;
			GenericNoType _PUpdated = PUpdated;
			GenericNoType _PDeleted = PDeleted;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateAppmtdSp";
				
				appDB.AddCommandParameter(cmd, "PSessionId", _PSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAppmtRowid", _PAppmtRowid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCreated", _PCreated, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUpdated", _PUpdated, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDeleted", _PDeleted, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PCreated = _PCreated;
				PUpdated = _PUpdated;
				PDeleted = _PDeleted;
				Infobar = _Infobar;
				
				return (Severity, PCreated, PUpdated, PDeleted, Infobar);
			}
		}
	}
}
