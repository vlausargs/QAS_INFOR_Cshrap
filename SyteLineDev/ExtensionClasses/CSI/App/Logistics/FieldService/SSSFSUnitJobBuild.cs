//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUnitJobBuild.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSUnitJobBuild : ISSSFSUnitJobBuild
	{
		readonly IApplicationDB appDB;
		
		public SSSFSUnitJobBuild(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSUnitJobBuildSp(
			string PJob,
			int? PSuf,
			string PSerNum,
			string PItem,
			int? PId,
			DateTime? PInstallDate,
			int? PSubUnit,
			int? PBatchMode,
			int? PUseActual,
			string PCustNum = null,
			int? PCustSeq = null,
			string PUsrNum = null,
			int? PUsrSeq = null)
		{
			JobType _PJob = PJob;
			SuffixType _PSuf = PSuf;
			SerNumType _PSerNum = PSerNum;
			ItemType _PItem = PItem;
			FSCompIdType _PId = PId;
			CurrentDateType _PInstallDate = PInstallDate;
			FlagNyType _PSubUnit = PSubUnit;
			FlagNyType _PBatchMode = PBatchMode;
			FlagNyType _PUseActual = PUseActual;
			CustNumType _PCustNum = PCustNum;
			CustSeqType _PCustSeq = PCustSeq;
			FSUsrNumType _PUsrNum = PUsrNum;
			FSUsrSeqType _PUsrSeq = PUsrSeq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSUnitJobBuild";
				
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuf", _PSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSerNum", _PSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PId", _PId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInstallDate", _PInstallDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSubUnit", _PSubUnit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBatchMode", _PBatchMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUseActual", _PUseActual, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustSeq", _PCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUsrNum", _PUsrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUsrSeq", _PUsrSeq, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
