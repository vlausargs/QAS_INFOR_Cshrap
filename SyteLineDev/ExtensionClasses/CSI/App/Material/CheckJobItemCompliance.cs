//PROJECT NAME: CSIMaterial
//CLASS NAME: CheckJobItemCompliance.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface ICheckJobItemCompliance
	{
		(int? ReturnCode, string Infobar) CheckJobItemComplianceSp(string pJob,
		short? pSuffix,
		string Infobar,
		string pItem = null,
		string pRevision = null);
	}
	
	public class CheckJobItemCompliance : ICheckJobItemCompliance
	{
		readonly IApplicationDB appDB;
		
		public CheckJobItemCompliance(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CheckJobItemComplianceSp(string pJob,
		short? pSuffix,
		string Infobar,
		string pItem = null,
		string pRevision = null)
		{
			JobType _pJob = pJob;
			SuffixType _pSuffix = pSuffix;
			InfobarType _Infobar = Infobar;
			ItemType _pItem = pItem;
			RevisionType _pRevision = pRevision;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckJobItemComplianceSp";
				
				appDB.AddCommandParameter(cmd, "pJob", _pJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSuffix", _pSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pItem", _pItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRevision", _pRevision, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
