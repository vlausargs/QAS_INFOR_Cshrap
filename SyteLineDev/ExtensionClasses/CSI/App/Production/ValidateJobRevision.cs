//PROJECT NAME: Production
//CLASS NAME: ValidateJobRevision.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class ValidateJobRevision : IValidateJobRevision
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateJobRevision(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PRevision,
		string Infobar) ValidateJobRevisionSp(string PItem,
		string PRevision,
		string Infobar)
		{
			ItemType _PItem = PItem;
			RevisionType _PRevision = PRevision;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateJobRevisionSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRevision", _PRevision, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PRevision = _PRevision;
				Infobar = _Infobar;
				
				return (Severity, PRevision, Infobar);
			}
		}
	}
}
