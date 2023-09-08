//PROJECT NAME: Production
//CLASS NAME: PP_JobCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public class PP_JobCopy : IPP_JobCopy
	{
		readonly IApplicationDB appDB;
		
		public PP_JobCopy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string ToJob,
			int? ToSuffix,
			string Infobar) PP_JobCopySp(
			string FromType,
			string FromJob,
			int? FromSuffix,
			string ToType,
			string ToJob,
			int? ToSuffix,
			string Infobar)
		{
			StringType _FromType = FromType;
			JobType _FromJob = FromJob;
			SuffixType _FromSuffix = FromSuffix;
			StringType _ToType = ToType;
			JobType _ToJob = ToJob;
			SuffixType _ToSuffix = ToSuffix;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PP_JobCopySp";
				
				appDB.AddCommandParameter(cmd, "FromType", _FromType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromJob", _FromJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSuffix", _FromSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToType", _ToType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToJob", _ToJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToSuffix", _ToSuffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ToJob = _ToJob;
				ToSuffix = _ToSuffix;
				Infobar = _Infobar;
				
				return (Severity, ToJob, ToSuffix, Infobar);
			}
		}
	}
}
