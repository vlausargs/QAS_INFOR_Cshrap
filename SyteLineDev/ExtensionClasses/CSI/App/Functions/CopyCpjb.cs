//PROJECT NAME: Data
//CLASS NAME: CopyCpjb.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CopyCpjb : ICopyCpjb
	{
		readonly IApplicationDB appDB;
		
		public CopyCpjb(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string ToJob,
			int? ToSuffix,
			string Infobar) CopyCpjbSp(
			string FromJobCategory,
			string FromJob,
			int? FromSuffix,
			int? StartOper,
			int? EndOper,
			string Revision,
			int? ScrapFactor,
			string ToJobCategory,
			string ToJob,
			int? ToSuffix,
			DateTime? EffectDate,
			int? IsCalledFromFirmJob = 0,
			Guid? SessionID = null,
			string Infobar = null,
			int? FromMRP = 0,
			string PLN_Ref_Type = null,
			string PLN_Ref_Num = null,
			int? PLN_ref_suf = null,
			int? CopyUetValues = 0)
		{
			StringType _FromJobCategory = FromJobCategory;
			JobType _FromJob = FromJob;
			SuffixType _FromSuffix = FromSuffix;
			OperNumType _StartOper = StartOper;
			OperNumType _EndOper = EndOper;
			RevisionType _Revision = Revision;
			ListYesNoType _ScrapFactor = ScrapFactor;
			StringType _ToJobCategory = ToJobCategory;
			JobType _ToJob = ToJob;
			SuffixType _ToSuffix = ToSuffix;
			DateType _EffectDate = EffectDate;
			ListYesNoType _IsCalledFromFirmJob = IsCalledFromFirmJob;
			RowPointerType _SessionID = SessionID;
			Infobar _Infobar = Infobar;
			ListYesNoType _FromMRP = FromMRP;
			MrpOrderTypeType _PLN_Ref_Type = PLN_Ref_Type;
			MrpOrderType _PLN_Ref_Num = PLN_Ref_Num;
			MrpOrderLineType _PLN_ref_suf = PLN_ref_suf;
			ListYesNoType _CopyUetValues = CopyUetValues;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CopyCpjbSp";
				
				appDB.AddCommandParameter(cmd, "FromJobCategory", _FromJobCategory, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromJob", _FromJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSuffix", _FromSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartOper", _StartOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOper", _EndOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Revision", _Revision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScrapFactor", _ScrapFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToJobCategory", _ToJobCategory, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToJob", _ToJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToSuffix", _ToSuffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EffectDate", _EffectDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsCalledFromFirmJob", _IsCalledFromFirmJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromMRP", _FromMRP, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLN_Ref_Type", _PLN_Ref_Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLN_Ref_Num", _PLN_Ref_Num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLN_ref_suf", _PLN_ref_suf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyUetValues", _CopyUetValues, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ToJob = _ToJob;
				ToSuffix = _ToSuffix;
				Infobar = _Infobar;
				
				return (Severity, ToJob, ToSuffix, Infobar);
			}
		}
	}
}
