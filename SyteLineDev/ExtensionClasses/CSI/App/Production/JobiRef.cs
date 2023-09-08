//PROJECT NAME: Production
//CLASS NAME: JobiRef.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobiRef : IJobiRef
	{
		readonly IApplicationDB appDB;
		
		
		public JobiRef(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? FoundRef,
		string PMessage,
		string Infobar) JobiRefSp(string PJob,
		int? PSuffix,
		string PItem,
		int? FoundRef,
		string PMessage,
		string Infobar)
		{
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			ItemType _PItem = PItem;
			FlagNyType _FoundRef = FoundRef;
			LongListType _PMessage = PMessage;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobiRefSp";
				
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FoundRef", _FoundRef, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PMessage", _PMessage, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				FoundRef = _FoundRef;
				PMessage = _PMessage;
				Infobar = _Infobar;
				
				return (Severity, FoundRef, PMessage, Infobar);
			}
		}
	}
}
