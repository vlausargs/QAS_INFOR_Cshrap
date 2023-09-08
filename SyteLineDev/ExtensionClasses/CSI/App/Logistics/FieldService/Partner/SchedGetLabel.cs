//PROJECT NAME: Logistics
//CLASS NAME: SchedGetLabel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SchedGetLabel : ISchedGetLabel
	{
		readonly IApplicationDB appDB;
		
		public SchedGetLabel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SchedGetLabelSp(
			string Username,
			string ScheduleID,
			string ReferenceLabel,
			string PartnerIdLabel,
			string PartnerNameLabel,
			string DescriptionLabel,
			string ApptStatLabel,
			string StatCodeLabel,
			string PriorCodeLabel,
			string CustNameLabel,
			string SroTypeLabel,
			string ApptStartDateLabel,
			string ApptLengthLabel,
			string TerritoryRegionLabel,
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			int? RefSeq,
			string PartnerId,
			string PartnerName,
			string Description,
			string ApptStat,
			string StatCode,
			string PriorCode,
			string CustName,
			string SroType,
			DateTime? ApptStartDate,
			string ApptLength,
			string TerritoryRegion)
		{
			StringType _Username = Username;
			StringType _ScheduleID = ScheduleID;
			LongListType _ReferenceLabel = ReferenceLabel;
			LongListType _PartnerIdLabel = PartnerIdLabel;
			LongListType _PartnerNameLabel = PartnerNameLabel;
			LongListType _DescriptionLabel = DescriptionLabel;
			LongListType _ApptStatLabel = ApptStatLabel;
			LongListType _StatCodeLabel = StatCodeLabel;
			LongListType _PriorCodeLabel = PriorCodeLabel;
			LongListType _CustNameLabel = CustNameLabel;
			LongListType _SroTypeLabel = SroTypeLabel;
			LongListType _ApptStartDateLabel = ApptStartDateLabel;
			LongListType _ApptLengthLabel = ApptLengthLabel;
			LongListType _TerritoryRegionLabel = TerritoryRegionLabel;
			DescriptionType _RefType = RefType;
			FSRefNumType _RefNum = RefNum;
			FSRefLineType _RefLineSuf = RefLineSuf;
			FSRefReleaseType _RefRelease = RefRelease;
			FSSeqType _RefSeq = RefSeq;
			FSPartnerType _PartnerId = PartnerId;
			NameType _PartnerName = PartnerName;
			DescriptionType _Description = Description;
			FSApptStatType _ApptStat = ApptStat;
			FSStatCodeType _StatCode = StatCode;
			FSIncPriorCodeType _PriorCode = PriorCode;
			NameType _CustName = CustName;
			FSSROTypeType _SroType = SroType;
			DateType _ApptStartDate = ApptStartDate;
			NameType _ApptLength = ApptLength;
			FSRegionType _TerritoryRegion = TerritoryRegion;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SchedGetLabelSp](@Username, @ScheduleID, @ReferenceLabel, @PartnerIdLabel, @PartnerNameLabel, @DescriptionLabel, @ApptStatLabel, @StatCodeLabel, @PriorCodeLabel, @CustNameLabel, @SroTypeLabel, @ApptStartDateLabel, @ApptLengthLabel, @TerritoryRegionLabel, @RefType, @RefNum, @RefLineSuf, @RefRelease, @RefSeq, @PartnerId, @PartnerName, @Description, @ApptStat, @StatCode, @PriorCode, @CustName, @SroType, @ApptStartDate, @ApptLength, @TerritoryRegion)";
				
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScheduleID", _ScheduleID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReferenceLabel", _ReferenceLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerIdLabel", _PartnerIdLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerNameLabel", _PartnerNameLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DescriptionLabel", _DescriptionLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApptStatLabel", _ApptStatLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatCodeLabel", _StatCodeLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriorCodeLabel", _PriorCodeLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNameLabel", _CustNameLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroTypeLabel", _SroTypeLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApptStartDateLabel", _ApptStartDateLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApptLengthLabel", _ApptLengthLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TerritoryRegionLabel", _TerritoryRegionLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefSeq", _RefSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerName", _PartnerName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApptStat", _ApptStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatCode", _StatCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriorCode", _PriorCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustName", _CustName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroType", _SroType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApptStartDate", _ApptStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApptLength", _ApptLength, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TerritoryRegion", _TerritoryRegion, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
