//PROJECT NAME: Production
//CLASS NAME: CopyJobMaterial.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class CopyJobMaterial : ICopyJobMaterial
	{
		readonly IApplicationDB appDB;
		
		
		public CopyJobMaterial(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CopyJobMaterialSp(string FromCardType,
		string FromJobType,
		string FromJob,
		int? FromSuffix,
		int? FromOperNum,
		int? FromSequence,
		string ToCardType,
		string ToJobType,
		string ToJob,
		int? ToSuffix,
		int? ToOperNum,
		int? ToSequence,
		int? CutFlag,
		string Infobar)
		{
			StringType _FromCardType = FromCardType;
			JobTypeType _FromJobType = FromJobType;
			JobType _FromJob = FromJob;
			SuffixType _FromSuffix = FromSuffix;
			OperNumType _FromOperNum = FromOperNum;
			JobmatlSequenceType _FromSequence = FromSequence;
			StringType _ToCardType = ToCardType;
			JobTypeType _ToJobType = ToJobType;
			JobType _ToJob = ToJob;
			SuffixType _ToSuffix = ToSuffix;
			OperNumType _ToOperNum = ToOperNum;
			JobmatlSequenceType _ToSequence = ToSequence;
			ListYesNoType _CutFlag = CutFlag;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CopyJobMaterialSp";
				
				appDB.AddCommandParameter(cmd, "FromCardType", _FromCardType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromJobType", _FromJobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromJob", _FromJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSuffix", _FromSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromOperNum", _FromOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSequence", _FromSequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToCardType", _ToCardType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToJobType", _ToJobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToJob", _ToJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSuffix", _ToSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToOperNum", _ToOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSequence", _ToSequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CutFlag", _CutFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
