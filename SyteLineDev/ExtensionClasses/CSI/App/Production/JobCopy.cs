//PROJECT NAME: Production
//CLASS NAME: JobCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobCopy : IJobCopy
	{
		readonly IApplicationDB appDB;
		
		
		public JobCopy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ToJob,
		int? ToSuffix,
		string Infobar) JobCopySp(string FromType,
		string FromJob,
		int? FromSuffix,
		int? FromOperNumStart,
		int? FromOperNumEnd,
		string FromOpt,
		string FromRevision,
		string ToType,
		string ToItem,
		string ToJob,
		int? ToSuffix,
		DateTime? EffectDate,
		string ToOpt,
		int? InsertOperNum,
		int? SetQtyAllocJob = 1,
		int? OverwriteExistingJobroute = 1,
		Guid? SessionID = null,
		string Infobar = null,
		int? FromMRP = 0,
		string PLN_Ref_Type = null,
		string PLN_Ref_Num = null,
		int? PLN_ref_suf = null,
		int? CopyUetValues = 0)
		{
			StringType _FromType = FromType;
			JobType _FromJob = FromJob;
			SuffixType _FromSuffix = FromSuffix;
			OperNumType _FromOperNumStart = FromOperNumStart;
			OperNumType _FromOperNumEnd = FromOperNumEnd;
			StringType _FromOpt = FromOpt;
			RevisionType _FromRevision = FromRevision;
			StringType _ToType = ToType;
			ItemType _ToItem = ToItem;
			JobType _ToJob = ToJob;
			SuffixType _ToSuffix = ToSuffix;
			DateType _EffectDate = EffectDate;
			StringType _ToOpt = ToOpt;
			OperNumType _InsertOperNum = InsertOperNum;
			ListYesNoType _SetQtyAllocJob = SetQtyAllocJob;
			ListYesNoType _OverwriteExistingJobroute = OverwriteExistingJobroute;
			RowPointerType _SessionID = SessionID;
			InfobarType _Infobar = Infobar;
			ListYesNoType _FromMRP = FromMRP;
			MrpOrderTypeType _PLN_Ref_Type = PLN_Ref_Type;
			MrpOrderType _PLN_Ref_Num = PLN_Ref_Num;
			MrpOrderLineType _PLN_ref_suf = PLN_ref_suf;
			ListYesNoType _CopyUetValues = CopyUetValues;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobCopySp";
				
				appDB.AddCommandParameter(cmd, "FromType", _FromType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromJob", _FromJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSuffix", _FromSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromOperNumStart", _FromOperNumStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromOperNumEnd", _FromOperNumEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromOpt", _FromOpt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromRevision", _FromRevision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToType", _ToType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToItem", _ToItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToJob", _ToJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToSuffix", _ToSuffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EffectDate", _EffectDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToOpt", _ToOpt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InsertOperNum", _InsertOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetQtyAllocJob", _SetQtyAllocJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OverwriteExistingJobroute", _OverwriteExistingJobroute, ParameterDirection.Input);
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
