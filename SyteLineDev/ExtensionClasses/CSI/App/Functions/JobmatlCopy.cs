//PROJECT NAME: Data
//CLASS NAME: JobmatlCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JobmatlCopy : IJobmatlCopy
	{
		readonly IApplicationDB appDB;
		
		public JobmatlCopy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? ToSequence,
			string Infobar) JobmatlCopySp(
			string FromType,
			string FromJob,
			int? FromSuffix,
			int? FromOperStart,
			int? FromOperEnd,
			decimal? FromQtyReleased,
			DateTime? EffectDate,
			string ToType,
			string ToItem,
			string ToJob,
			int? ToSuffix,
			int? ToOperNum,
			int? ToSequence,
			decimal? MatlQty,
			string Units,
			decimal? ScrapFact,
			int? SetQtyAllocJob = 1,
			Guid? PSessionID = null,
			string Infobar = null,
			string Site = null,
			int? PostponeJobmatlInsert = 0,
			int? FromMRP = 0,
			string PLN_Ref_Type = null,
			string PLN_Ref_Num = null,
			int? PLN_ref_suf = null,
			string FeatStr = null,
			int? CopyUetValues = 0,
			string UseJobmatlFeature = null,
			string UseJobmatlOptCode = null,
			string CoNum = null,
			int? CoLine = null)
		{
			StringType _FromType = FromType;
			JobType _FromJob = FromJob;
			SuffixType _FromSuffix = FromSuffix;
			OperNumType _FromOperStart = FromOperStart;
			OperNumType _FromOperEnd = FromOperEnd;
			QtyUnitType _FromQtyReleased = FromQtyReleased;
			DateType _EffectDate = EffectDate;
			StringType _ToType = ToType;
			ItemType _ToItem = ToItem;
			JobType _ToJob = ToJob;
			SuffixType _ToSuffix = ToSuffix;
			OperNumType _ToOperNum = ToOperNum;
			JobmatlSequenceType _ToSequence = ToSequence;
			QtyUnitType _MatlQty = MatlQty;
			JobmatlUnitsType _Units = Units;
			ScrapFactorType _ScrapFact = ScrapFact;
			ListYesNoType _SetQtyAllocJob = SetQtyAllocJob;
			RowPointerType _PSessionID = PSessionID;
			InfobarType _Infobar = Infobar;
			SiteType _Site = Site;
			ListYesNoType _PostponeJobmatlInsert = PostponeJobmatlInsert;
			ListYesNoType _FromMRP = FromMRP;
			MrpOrderTypeType _PLN_Ref_Type = PLN_Ref_Type;
			MrpOrderType _PLN_Ref_Num = PLN_Ref_Num;
			MrpOrderLineType _PLN_ref_suf = PLN_ref_suf;
			FeatStrType _FeatStr = FeatStr;
			ListYesNoType _CopyUetValues = CopyUetValues;
			FeatureType _UseJobmatlFeature = UseJobmatlFeature;
			OptCodeType _UseJobmatlOptCode = UseJobmatlOptCode;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobmatlCopySp";
				
				appDB.AddCommandParameter(cmd, "FromType", _FromType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromJob", _FromJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSuffix", _FromSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromOperStart", _FromOperStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromOperEnd", _FromOperEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromQtyReleased", _FromQtyReleased, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectDate", _EffectDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToType", _ToType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToItem", _ToItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToJob", _ToJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSuffix", _ToSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToOperNum", _ToOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSequence", _ToSequence, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MatlQty", _MatlQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Units", _Units, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScrapFact", _ScrapFact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetQtyAllocJob", _SetQtyAllocJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostponeJobmatlInsert", _PostponeJobmatlInsert, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromMRP", _FromMRP, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLN_Ref_Type", _PLN_Ref_Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLN_Ref_Num", _PLN_Ref_Num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLN_ref_suf", _PLN_ref_suf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FeatStr", _FeatStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyUetValues", _CopyUetValues, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseJobmatlFeature", _UseJobmatlFeature, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseJobmatlOptCode", _UseJobmatlOptCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ToSequence = _ToSequence;
				Infobar = _Infobar;
				
				return (Severity, ToSequence, Infobar);
			}
		}
	}
}
