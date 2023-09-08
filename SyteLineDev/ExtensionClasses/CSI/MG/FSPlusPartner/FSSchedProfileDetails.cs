//PROJECT NAME: FSPlusPartnerExt
//CLASS NAME: FSSchedProfileDetails.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.Partner;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.FSPlusPartner
{
    [IDOExtensionClass("FSSchedProfileDetails")]
    public class FSSchedProfileDetails : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSSchedProfileFilterTaskGroupSaveServerSp(string List,
                                                                ref string InfoBar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSSchedProfileFilterTaskGroupSaveServerExt = new SSSFSSchedProfileFilterTaskGroupSaveServerFactory().Create(appDb);

                Infobar oInfoBar = InfoBar;

                int Severity = iSSSFSSchedProfileFilterTaskGroupSaveServerExt.SSSFSSchedProfileFilterTaskGroupSaveServerSp(List,
                                                                                                                           ref oInfoBar);

                InfoBar = oInfoBar;

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSSchedLabelsINITSp(string UserName,
		                                string SechID,
		                                ref string ReferenceLabel,
		                                ref string ReferenceValue,
		                                ref string ReferenceEnter,
		                                ref string PartnerIDLabel,
		                                ref string PartnerIDValue,
		                                ref string PartnerIDEnter,
		                                ref string PartnerNameLabel,
		                                ref string PartnerNameValue,
		                                ref string PartnerNameEnter,
		                                ref string DescriptionLabel,
		                                ref string DescriptionValue,
		                                ref string DescriptionEnter,
		                                ref string ApptStatusLabel,
		                                ref string ApptStatusValue,
		                                ref string ApptStatusEnter,
		                                ref string RefStatusLabel,
		                                ref string RefStatusValue,
		                                ref string RefStatusEnter,
		                                ref string PriorityLabel,
		                                ref string PriorityValue,
		                                ref string PriorityEnter,
		                                ref string CustNameLabel,
		                                ref string CustNameValue,
		                                ref string CustNameEnter,
		                                ref string SROTypeLabel,
		                                ref string SROTypeValue,
		                                ref string SROTypeEnter,
		                                ref string ApptDateTimeLabel,
		                                ref string ApptDateTimeValue,
		                                ref string ApptDateTimeEnter,
		                                ref string ApptHoursLabel,
		                                ref string ApptHoursValue,
		                                ref string ApptHoursEnter,
		                                ref string TerritoryRegionLabel,
		                                ref string TerritoryRegionValue,
		                                ref string TerritoryRegionEnter)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSchedLabelsINITExt = new SSSFSSchedLabelsINITFactory().Create(appDb);
				
				var result = iSSSFSSchedLabelsINITExt.SSSFSSchedLabelsINITSp(UserName,
				                                                             SechID,
				                                                             ReferenceLabel,
				                                                             ReferenceValue,
				                                                             ReferenceEnter,
				                                                             PartnerIDLabel,
				                                                             PartnerIDValue,
				                                                             PartnerIDEnter,
				                                                             PartnerNameLabel,
				                                                             PartnerNameValue,
				                                                             PartnerNameEnter,
				                                                             DescriptionLabel,
				                                                             DescriptionValue,
				                                                             DescriptionEnter,
				                                                             ApptStatusLabel,
				                                                             ApptStatusValue,
				                                                             ApptStatusEnter,
				                                                             RefStatusLabel,
				                                                             RefStatusValue,
				                                                             RefStatusEnter,
				                                                             PriorityLabel,
				                                                             PriorityValue,
				                                                             PriorityEnter,
				                                                             CustNameLabel,
				                                                             CustNameValue,
				                                                             CustNameEnter,
				                                                             SROTypeLabel,
				                                                             SROTypeValue,
				                                                             SROTypeEnter,
				                                                             ApptDateTimeLabel,
				                                                             ApptDateTimeValue,
				                                                             ApptDateTimeEnter,
				                                                             ApptHoursLabel,
				                                                             ApptHoursValue,
				                                                             ApptHoursEnter,
				                                                             TerritoryRegionLabel,
				                                                             TerritoryRegionValue,
				                                                             TerritoryRegionEnter);
				
				int Severity = result.ReturnCode.Value;
				ReferenceLabel = result.ReferenceLabel;
				ReferenceValue = result.ReferenceValue;
				ReferenceEnter = result.ReferenceEnter;
				PartnerIDLabel = result.PartnerIDLabel;
				PartnerIDValue = result.PartnerIDValue;
				PartnerIDEnter = result.PartnerIDEnter;
				PartnerNameLabel = result.PartnerNameLabel;
				PartnerNameValue = result.PartnerNameValue;
				PartnerNameEnter = result.PartnerNameEnter;
				DescriptionLabel = result.DescriptionLabel;
				DescriptionValue = result.DescriptionValue;
				DescriptionEnter = result.DescriptionEnter;
				ApptStatusLabel = result.ApptStatusLabel;
				ApptStatusValue = result.ApptStatusValue;
				ApptStatusEnter = result.ApptStatusEnter;
				RefStatusLabel = result.RefStatusLabel;
				RefStatusValue = result.RefStatusValue;
				RefStatusEnter = result.RefStatusEnter;
				PriorityLabel = result.PriorityLabel;
				PriorityValue = result.PriorityValue;
				PriorityEnter = result.PriorityEnter;
				CustNameLabel = result.CustNameLabel;
				CustNameValue = result.CustNameValue;
				CustNameEnter = result.CustNameEnter;
				SROTypeLabel = result.SROTypeLabel;
				SROTypeValue = result.SROTypeValue;
				SROTypeEnter = result.SROTypeEnter;
				ApptDateTimeLabel = result.ApptDateTimeLabel;
				ApptDateTimeValue = result.ApptDateTimeValue;
				ApptDateTimeEnter = result.ApptDateTimeEnter;
				ApptHoursLabel = result.ApptHoursLabel;
				ApptHoursValue = result.ApptHoursValue;
				ApptHoursEnter = result.ApptHoursEnter;
				TerritoryRegionLabel = result.TerritoryRegionLabel;
				TerritoryRegionValue = result.TerritoryRegionValue;
				TerritoryRegionEnter = result.TerritoryRegionEnter;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSSchedLabelsSaveSp(string UserName,
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
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSchedLabelsSaveExt = new SSSFSSchedLabelsSaveFactory().Create(appDb);
				
				var result = iSSSFSSchedLabelsSaveExt.SSSFSSchedLabelsSaveSp(UserName,
				                                                             SechID,
				                                                             ReferenceLabel,
				                                                             ReferenceValue,
				                                                             ReferenceEnter,
				                                                             PartnerIDLabel,
				                                                             PartnerIDValue,
				                                                             PartnerIDEnter,
				                                                             PartnerNameLabel,
				                                                             PartnerNameValue,
				                                                             PartnerNameEnter,
				                                                             DescriptionLabel,
				                                                             DescriptionValue,
				                                                             DescriptionEnter,
				                                                             ApptStatusLabel,
				                                                             ApptStatusValue,
				                                                             ApptStatusEnter,
				                                                             RefStatusLabel,
				                                                             RefStatusValue,
				                                                             RefStatusEnter,
				                                                             PriorityLabel,
				                                                             PriorityValue,
				                                                             PriorityEnter,
				                                                             CustNameLabel,
				                                                             CustNameValue,
				                                                             CustNameEnter,
				                                                             SROTypeLabel,
				                                                             SROTypeValue,
				                                                             SROTypeEnter,
				                                                             ApptDateTimeLabel,
				                                                             ApptDateTimeValue,
				                                                             ApptDateTimeEnter,
				                                                             ApptHoursLabel,
				                                                             ApptHoursValue,
				                                                             ApptHoursEnter,
				                                                             TerritoryRegionLabel,
				                                                             TerritoryRegionValue,
				                                                             TerritoryRegionEnter);
				
				
				return result.Value;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSchedProfileFiltersServerSP(string List, ref string InfoBar)
		{
			var iSSSFSSchedProfileFiltersServerExt = new SSSFSSchedProfileFiltersServerFactory().Create(this, true);
			
			var result = iSSSFSSchedProfileFiltersServerExt.SSSFSSchedProfileFiltersServerSp(List, InfoBar);
			
			InfoBar = result.InfoBar;
			
			return result.ReturnCode??0;
		}

    }
}
