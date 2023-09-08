//PROJECT NAME: Production
//CLASS NAME: CopyBomDoProcess.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class CopyBomDoProcess : ICopyBomDoProcess
	{
		readonly IApplicationDB appDB;
		
		
		public CopyBomDoProcess(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ToJob,
		int? ToSuffix,
		string Infobar) CopyBomDoProcessSp(string FromJobCategory,
		string FromJob,
		int? FromSuffix,
		string FromItem,
		int? StartOper,
		int? EndOper,
		string LMBVar,
		string Revision,
		int? ScrapFactor,
		int? CopyBom,
		string ToJobCategory,
		string ToItem,
		string ToJob,
		int? ToSuffix,
		DateTime? EffectDate,
		string OptionType,
		int? AfterOper,
		int? CopyToPSReleaseBOM,
		string Infobar,
		int? CopyUetValues = 0)
		{
			StringType _FromJobCategory = FromJobCategory;
			JobType _FromJob = FromJob;
			SuffixType _FromSuffix = FromSuffix;
			ItemType _FromItem = FromItem;
			OperNumType _StartOper = StartOper;
			OperNumType _EndOper = EndOper;
			StringType _LMBVar = LMBVar;
			RevisionType _Revision = Revision;
			ListYesNoType _ScrapFactor = ScrapFactor;
			ListYesNoType _CopyBom = CopyBom;
			StringType _ToJobCategory = ToJobCategory;
			ItemType _ToItem = ToItem;
			JobType _ToJob = ToJob;
			SuffixType _ToSuffix = ToSuffix;
			DateType _EffectDate = EffectDate;
			StringType _OptionType = OptionType;
			OperNumType _AfterOper = AfterOper;
			ListYesNoType _CopyToPSReleaseBOM = CopyToPSReleaseBOM;
			InfobarType _Infobar = Infobar;
			ListYesNoType _CopyUetValues = CopyUetValues;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CopyBomDoProcessSp";
				
				appDB.AddCommandParameter(cmd, "FromJobCategory", _FromJobCategory, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromJob", _FromJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSuffix", _FromSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromItem", _FromItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartOper", _StartOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOper", _EndOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LMBVar", _LMBVar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Revision", _Revision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScrapFactor", _ScrapFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyBom", _CopyBom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToJobCategory", _ToJobCategory, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToItem", _ToItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToJob", _ToJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToSuffix", _ToSuffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EffectDate", _EffectDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OptionType", _OptionType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AfterOper", _AfterOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyToPSReleaseBOM", _CopyToPSReleaseBOM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
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
