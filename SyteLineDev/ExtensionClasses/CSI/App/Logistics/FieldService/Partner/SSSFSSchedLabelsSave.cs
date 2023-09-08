//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSchedLabelsSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISSSFSSchedLabelsSave
	{
		int? SSSFSSchedLabelsSaveSp(string UserName,
		                            string SechID,
		                            string ReferenceLabel,
		                            string ReferenceValue,
		                            string ReferenceEnter,
		                            string PartnerIDLabel,
		                            string PartnerIDValue,
		                            string PartnerIDEnter,
		                            string PartnerNameLabel,
		                            string PartnerNameValue,
		                            string PartnerNameEnter,
		                            string DescriptionLabel,
		                            string DescriptionValue,
		                            string DescriptionEnter,
		                            string ApptStatusLabel,
		                            string ApptStatusValue,
		                            string ApptStatusEnter,
		                            string RefStatusLabel,
		                            string RefStatusValue,
		                            string RefStatusEnter,
		                            string PriorityLabel,
		                            string PriorityValue,
		                            string PriorityEnter,
		                            string CustNameLabel,
		                            string CustNameValue,
		                            string CustNameEnter,
		                            string SROTypeLabel,
		                            string SROTypeValue,
		                            string SROTypeEnter,
		                            string ApptDateTimeLabel,
		                            string ApptDateTimeValue,
		                            string ApptDateTimeEnter,
		                            string ApptHoursLabel,
		                            string ApptHoursValue,
		                            string ApptHoursEnter,
		                            string TerritoryRegionLabel,
		                            string TerritoryRegionValue,
		                            string TerritoryRegionEnter);
	}
	
	public class SSSFSSchedLabelsSave : ISSSFSSchedLabelsSave
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSchedLabelsSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSSchedLabelsSaveSp(string UserName,
		                                   string SechID,
		                                   string ReferenceLabel,
		                                   string ReferenceValue,
		                                   string ReferenceEnter,
		                                   string PartnerIDLabel,
		                                   string PartnerIDValue,
		                                   string PartnerIDEnter,
		                                   string PartnerNameLabel,
		                                   string PartnerNameValue,
		                                   string PartnerNameEnter,
		                                   string DescriptionLabel,
		                                   string DescriptionValue,
		                                   string DescriptionEnter,
		                                   string ApptStatusLabel,
		                                   string ApptStatusValue,
		                                   string ApptStatusEnter,
		                                   string RefStatusLabel,
		                                   string RefStatusValue,
		                                   string RefStatusEnter,
		                                   string PriorityLabel,
		                                   string PriorityValue,
		                                   string PriorityEnter,
		                                   string CustNameLabel,
		                                   string CustNameValue,
		                                   string CustNameEnter,
		                                   string SROTypeLabel,
		                                   string SROTypeValue,
		                                   string SROTypeEnter,
		                                   string ApptDateTimeLabel,
		                                   string ApptDateTimeValue,
		                                   string ApptDateTimeEnter,
		                                   string ApptHoursLabel,
		                                   string ApptHoursValue,
		                                   string ApptHoursEnter,
		                                   string TerritoryRegionLabel,
		                                   string TerritoryRegionValue,
		                                   string TerritoryRegionEnter)
		{
			UsernameType _UserName = UserName;
			SerNumType _SechID = SechID;
			BolNumType _ReferenceLabel = ReferenceLabel;
			BolNumType _ReferenceValue = ReferenceValue;
			BolNumType _ReferenceEnter = ReferenceEnter;
			BolNumType _PartnerIDLabel = PartnerIDLabel;
			BolNumType _PartnerIDValue = PartnerIDValue;
			BolNumType _PartnerIDEnter = PartnerIDEnter;
			BolNumType _PartnerNameLabel = PartnerNameLabel;
			BolNumType _PartnerNameValue = PartnerNameValue;
			BolNumType _PartnerNameEnter = PartnerNameEnter;
			BolNumType _DescriptionLabel = DescriptionLabel;
			BolNumType _DescriptionValue = DescriptionValue;
			BolNumType _DescriptionEnter = DescriptionEnter;
			BolNumType _ApptStatusLabel = ApptStatusLabel;
			BolNumType _ApptStatusValue = ApptStatusValue;
			BolNumType _ApptStatusEnter = ApptStatusEnter;
			BolNumType _RefStatusLabel = RefStatusLabel;
			BolNumType _RefStatusValue = RefStatusValue;
			BolNumType _RefStatusEnter = RefStatusEnter;
			BolNumType _PriorityLabel = PriorityLabel;
			BolNumType _PriorityValue = PriorityValue;
			BolNumType _PriorityEnter = PriorityEnter;
			BolNumType _CustNameLabel = CustNameLabel;
			BolNumType _CustNameValue = CustNameValue;
			BolNumType _CustNameEnter = CustNameEnter;
			BolNumType _SROTypeLabel = SROTypeLabel;
			BolNumType _SROTypeValue = SROTypeValue;
			BolNumType _SROTypeEnter = SROTypeEnter;
			BolNumType _ApptDateTimeLabel = ApptDateTimeLabel;
			BolNumType _ApptDateTimeValue = ApptDateTimeValue;
			BolNumType _ApptDateTimeEnter = ApptDateTimeEnter;
			BolNumType _ApptHoursLabel = ApptHoursLabel;
			BolNumType _ApptHoursValue = ApptHoursValue;
			BolNumType _ApptHoursEnter = ApptHoursEnter;
			BolNumType _TerritoryRegionLabel = TerritoryRegionLabel;
			BolNumType _TerritoryRegionValue = TerritoryRegionValue;
			BolNumType _TerritoryRegionEnter = TerritoryRegionEnter;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSchedLabelsSaveSp";
				
				appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SechID", _SechID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReferenceLabel", _ReferenceLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReferenceValue", _ReferenceValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReferenceEnter", _ReferenceEnter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerIDLabel", _PartnerIDLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerIDValue", _PartnerIDValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerIDEnter", _PartnerIDEnter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerNameLabel", _PartnerNameLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerNameValue", _PartnerNameValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerNameEnter", _PartnerNameEnter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DescriptionLabel", _DescriptionLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DescriptionValue", _DescriptionValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DescriptionEnter", _DescriptionEnter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApptStatusLabel", _ApptStatusLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApptStatusValue", _ApptStatusValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApptStatusEnter", _ApptStatusEnter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefStatusLabel", _RefStatusLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefStatusValue", _RefStatusValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefStatusEnter", _RefStatusEnter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriorityLabel", _PriorityLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriorityValue", _PriorityValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriorityEnter", _PriorityEnter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNameLabel", _CustNameLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNameValue", _CustNameValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNameEnter", _CustNameEnter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROTypeLabel", _SROTypeLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROTypeValue", _SROTypeValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROTypeEnter", _SROTypeEnter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApptDateTimeLabel", _ApptDateTimeLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApptDateTimeValue", _ApptDateTimeValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApptDateTimeEnter", _ApptDateTimeEnter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApptHoursLabel", _ApptHoursLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApptHoursValue", _ApptHoursValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApptHoursEnter", _ApptHoursEnter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TerritoryRegionLabel", _TerritoryRegionLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TerritoryRegionValue", _TerritoryRegionValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TerritoryRegionEnter", _TerritoryRegionEnter, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
