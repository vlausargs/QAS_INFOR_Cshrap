//PROJECT NAME: Logistics
//CLASS NAME: CoitemDeleteRemote.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoitemDeleteRemote : ICoitemDeleteRemote
	{
		readonly IApplicationDB appDB;
		
		public CoitemDeleteRemote(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CoitemDeleteRemoteSp(
			string CoNum,
			int? CoLine,
			int? CoRelease,
			string CoCustNum,
			string CoOrigSite)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			CustNumType _CoCustNum = CoCustNum;
			SiteType _CoOrigSite = CoOrigSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoitemDeleteRemoteSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoCustNum", _CoCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoOrigSite", _CoOrigSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
