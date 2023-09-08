//PROJECT NAME: Material
//CLASS NAME: Coitem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class Coitem : ICoitem
	{
		readonly IApplicationDB appDB;
		
		
		public Coitem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CoitemSp(string PMode,
		string CoNum,
		int? CoLine,
		int? CoRelease,
		string FromParmsSite)
		{
			LongListType _PMode = PMode;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			SiteType _FromParmsSite = FromParmsSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoitemSp";
				
				appDB.AddCommandParameter(cmd, "PMode", _PMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromParmsSite", _FromParmsSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
