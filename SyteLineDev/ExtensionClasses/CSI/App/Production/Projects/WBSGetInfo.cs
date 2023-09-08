//PROJECT NAME: Production
//CLASS NAME: WBSGetInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class WBSGetInfo : IWBSGetInfo
	{
		readonly IApplicationDB appDB;
		
		public WBSGetInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? WBSGetInfoSp(
			string PcostNum,
			string PType,
			string PNum,
			int? PLine,
			int? PSeq,
			string Site)
		{
			LongListType _PcostNum = PcostNum;
			LongListType _PType = PType;
			LongListType _PNum = PNum;
			GenericNoType _PLine = PLine;
			ProjmatlSeqType _PSeq = PSeq;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "WBSGetInfoSp";
				
				appDB.AddCommandParameter(cmd, "PcostNum", _PcostNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNum", _PNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLine", _PLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSeq", _PSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
