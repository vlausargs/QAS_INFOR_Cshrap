//PROJECT NAME: DataCollection
//CLASS NAME: AutoLunch.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class AutoLunch : IAutoLunch
	{
		readonly IApplicationDB appDB;
		
		
		public AutoLunch(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PError) AutoLunchSp(string PEmpNum,
		DateTime? PTransDate,
		int? PTransTime,
		string PTransType,
		int? PTransNum,
		string PTermid,
		string PIndCode,
		string PJob,
		int? PSuffix,
		int? POperNum,
		string PWc,
		string PWhse,
		string PDcModule,
		string PError)
		{
			EmpNumType _PEmpNum = PEmpNum;
			DateTimeType _PTransDate = PTransDate;
			TimeSecondsType _PTransTime = PTransTime;
			DcsfcTransTypeType _PTransType = PTransType;
			DcTransNumType _PTransNum = PTransNum;
			DcTermIdType _PTermid = PTermid;
			IndCodeType _PIndCode = PIndCode;
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			OperNumType _POperNum = POperNum;
			WcType _PWc = PWc;
			WhseType _PWhse = PWhse;
			LongListType _PDcModule = PDcModule;
			LongListType _PError = PError;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AutoLunchSp";
				
				appDB.AddCommandParameter(cmd, "PEmpNum", _PEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransDate", _PTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransTime", _PTransTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransType", _PTransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransNum", _PTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTermid", _PTermid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PIndCode", _PIndCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POperNum", _POperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWc", _PWc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDcModule", _PDcModule, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PError", _PError, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PError = _PError;
				
				return (Severity, PError);
			}
		}
	}
}
