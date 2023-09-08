//PROJECT NAME: Data
//CLASS NAME: JobCopyIndented.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JobCopyIndented : IJobCopyIndented
	{
		readonly IApplicationDB appDB;
		
		public JobCopyIndented(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string NewJob,
			int? NewSuffix,
			string Infobar) JobCopyIndentedSp(
			string FromType,
			int? ExtScrap,
			string ToType,
			string FromJob,
			int? FromSuffix,
			DateTime? EffectDate,
			string NewJob,
			int? NewSuffix,
			int? MinOper,
			int? MaxOper,
			Guid? PSessionID = null,
			string Site = null,
			int? FromMRP = 0,
			string PLN_Ref_Type = null,
			string PLN_Ref_Num = null,
			int? PLN_Ref_Suf = null,
			decimal? HrsPerDay = 8M,
			int? CalcSubJobDates = 0,
			string Infobar = null,
			int? CopyUetValues = 0)
		{
			JobTypeType _FromType = FromType;
			ListYesNoType _ExtScrap = ExtScrap;
			JobTypeType _ToType = ToType;
			JobType _FromJob = FromJob;
			SuffixType _FromSuffix = FromSuffix;
			DateType _EffectDate = EffectDate;
			JobType _NewJob = NewJob;
			SuffixType _NewSuffix = NewSuffix;
			OperNumType _MinOper = MinOper;
			OperNumType _MaxOper = MaxOper;
			RowPointerType _PSessionID = PSessionID;
			SiteType _Site = Site;
			ListYesNoType _FromMRP = FromMRP;
			MrpOrderTypeType _PLN_Ref_Type = PLN_Ref_Type;
			MrpOrderType _PLN_Ref_Num = PLN_Ref_Num;
			MrpOrderLineType _PLN_Ref_Suf = PLN_Ref_Suf;
			GenericDecimalType _HrsPerDay = HrsPerDay;
			ListYesNoType _CalcSubJobDates = CalcSubJobDates;
			InfobarType _Infobar = Infobar;
			ListYesNoType _CopyUetValues = CopyUetValues;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobCopyIndentedSp";
				
				appDB.AddCommandParameter(cmd, "FromType", _FromType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExtScrap", _ExtScrap, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToType", _ToType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromJob", _FromJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSuffix", _FromSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectDate", _EffectDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewJob", _NewJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NewSuffix", _NewSuffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MinOper", _MinOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaxOper", _MaxOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromMRP", _FromMRP, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLN_Ref_Type", _PLN_Ref_Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLN_Ref_Num", _PLN_Ref_Num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLN_Ref_Suf", _PLN_Ref_Suf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HrsPerDay", _HrsPerDay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalcSubJobDates", _CalcSubJobDates, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CopyUetValues", _CopyUetValues, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NewJob = _NewJob;
				NewSuffix = _NewSuffix;
				Infobar = _Infobar;
				
				return (Severity, NewJob, NewSuffix, Infobar);
			}
		}
	}
}
