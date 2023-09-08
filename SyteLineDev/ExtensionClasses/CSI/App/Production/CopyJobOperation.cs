//PROJECT NAME: CSIProduct
//CLASS NAME: CopyJobOperation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
	public interface ICopyJobOperation
	{
		int CopyJobOperationSp(string FromCardType,
		                       string FromJobType,
		                       string FromJob,
		                       short? FromSuffix,
		                       int? FromOperNum,
		                       string ToCardType,
		                       string ToJobType,
		                       string ToJob,
		                       short? ToSuffix,
		                       int? ToOperNum,
		                       ref string Infobar);
	}
	
	public class CopyJobOperation : ICopyJobOperation
	{
		readonly IApplicationDB appDB;
		
		public CopyJobOperation(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CopyJobOperationSp(string FromCardType,
		                              string FromJobType,
		                              string FromJob,
		                              short? FromSuffix,
		                              int? FromOperNum,
		                              string ToCardType,
		                              string ToJobType,
		                              string ToJob,
		                              short? ToSuffix,
		                              int? ToOperNum,
		                              ref string Infobar)
		{
			StringType _FromCardType = FromCardType;
			JobTypeType _FromJobType = FromJobType;
			JobType _FromJob = FromJob;
			SuffixType _FromSuffix = FromSuffix;
			OperNumType _FromOperNum = FromOperNum;
			StringType _ToCardType = ToCardType;
			JobTypeType _ToJobType = ToJobType;
			JobType _ToJob = ToJob;
			SuffixType _ToSuffix = ToSuffix;
			OperNumType _ToOperNum = ToOperNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CopyJobOperationSp";
				
				appDB.AddCommandParameter(cmd, "FromCardType", _FromCardType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromJobType", _FromJobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromJob", _FromJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSuffix", _FromSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromOperNum", _FromOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToCardType", _ToCardType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToJobType", _ToJobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToJob", _ToJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSuffix", _ToSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToOperNum", _ToOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
