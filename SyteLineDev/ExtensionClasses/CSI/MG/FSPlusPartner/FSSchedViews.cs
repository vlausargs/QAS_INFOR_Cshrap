//PROJECT NAME: FSPlusPartnerExt
//CLASS NAME: FSSchedViews.cs

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
    [IDOExtensionClass("FSSchedViews")]
    public class FSSchedViews : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SchedGetFiltersSp(string Username,
                                     string ScheduleID,
                                     int? FilterGroup,
                                     ref byte? InclInc,
                                     ref byte? InclSro,
                                     ref byte? InclSroLine,
                                     ref byte? InclSroOper,
                                     ref byte? InclPlanLabor,
                                     ref string Owner,
                                     ref string SroType,
                                     ref byte? InclMiscTime,
                                     ref string City,
                                     ref string State,
                                     ref string Zip,
                                     ref string County,
                                     ref string Country,
                                     ref string TerritoryRegion,
                                     ref byte? UseRegion,
                                     ref string Dept)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSchedGetFiltersExt = new SchedGetFiltersFactory().Create(appDb);

                ListYesNoType oInclInc = InclInc;
                ListYesNoType oInclSro = InclSro;
                ListYesNoType oInclSroLine = InclSroLine;
                ListYesNoType oInclSroOper = InclSroOper;
                ListYesNoType oInclPlanLabor = InclPlanLabor;
                FSPartnerType oOwner = Owner;
                FSSROTypeType oSroType = SroType;
                ListYesNoType oInclMiscTime = InclMiscTime;
                CityType oCity = City;
                StateType oState = State;
                PostalCodeType oZip = Zip;
                CountyType oCounty = County;
                CountryType oCountry = Country;
                FSRegionType oTerritoryRegion = TerritoryRegion;
                ListYesNoType oUseRegion = UseRegion;
                DeptType oDept = Dept;

                int Severity = iSchedGetFiltersExt.SchedGetFiltersSp(Username,
                                                                     ScheduleID,
                                                                     FilterGroup,
                                                                     ref oInclInc,
                                                                     ref oInclSro,
                                                                     ref oInclSroLine,
                                                                     ref oInclSroOper,
                                                                     ref oInclPlanLabor,
                                                                     ref oOwner,
                                                                     ref oSroType,
                                                                     ref oInclMiscTime,
                                                                     ref oCity,
                                                                     ref oState,
                                                                     ref oZip,
                                                                     ref oCounty,
                                                                     ref oCountry,
                                                                     ref oTerritoryRegion,
                                                                     ref oUseRegion,
                                                                     ref oDept);

                InclInc = oInclInc;
                InclSro = oInclSro;
                InclSroLine = oInclSroLine;
                InclSroOper = oInclSroOper;
                InclPlanLabor = oInclPlanLabor;
                Owner = oOwner;
                SroType = oSroType;
                InclMiscTime = oInclMiscTime;
                City = oCity;
                State = oState;
                Zip = oZip;
                County = oCounty;
                Country = oCountry;
                TerritoryRegion = oTerritoryRegion;
                UseRegion = oUseRegion;
                Dept = oDept;


                return Severity;
            }
        }










		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_LocalAppointmentsSp([Optional, DefaultParameterValue(0)] int? IncludeAppointment,
		[Optional, DefaultParameterValue(0)] int? IncludeFutureService,
		[Optional, DefaultParameterValue(0)] int? DaysAhead,
		[Optional, DefaultParameterValue(0)] int? UnassignedOnly,
		[Optional, DefaultParameterValue(0)] int? IncludeSROLine,
		[Optional, DefaultParameterValue(0)] int? IncludeSROOperation,
		[Optional] string FCity,
		[Optional] string FState,
		[Optional] string FZip,
		[Optional] string FCounty,
		[Optional] string FCountry,
		[Optional] string FTerritoryRegion,
		[Optional] string FPartnerID,
		[Optional] string FDept,
		[Optional] string FSroType)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_LocalAppointmentsExt = new CLM_LocalAppointmentsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_LocalAppointmentsExt.CLM_LocalAppointmentsSp(IncludeAppointment,
				IncludeFutureService,
				DaysAhead,
				UnassignedOnly,
				IncludeSROLine,
				IncludeSROOperation,
				FCity,
				FState,
				FZip,
				FCounty,
				FCountry,
				FTerritoryRegion,
				FPartnerID,
				FDept,
				FSroType);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_SchedGetEventsSp(string Username,
		string ProfileUsername,
		string ScheduleID,
		string FilterUsername,
		string FilterName,
		int? FilterType,
		int? ColorCoding,
		DateTime? StartDate,
		DateTime? EndDate,
		int? PartnerFilterOverride,
		string SelectedPartnerList,
		int? TaskFilterOverride,
		string SelectedTaskList,
		[Optional, DefaultParameterValue(0)] int? View,
		[Optional, DefaultParameterValue(200)] int? RecordCap)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_SchedGetEventsExt = new CLM_SchedGetEventsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_SchedGetEventsExt.CLM_SchedGetEventsSp(Username,
				ProfileUsername,
				ScheduleID,
				FilterUsername,
				FilterName,
				FilterType,
				ColorCoding,
				StartDate,
				EndDate,
				PartnerFilterOverride,
				SelectedPartnerList,
				TaskFilterOverride,
				SelectedTaskList,
				View,
				RecordCap);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_SchedGetToBeSchedAddlSp([Optional] string SroNum,
		[Optional] int? SroLine,
		[Optional] int? SroOper,
		[Optional] int? TransNum,
		[Optional] string IncNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_SchedGetToBeSchedAddlExt = new CLM_SchedGetToBeSchedAddlFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_SchedGetToBeSchedAddlExt.CLM_SchedGetToBeSchedAddlSp(SroNum,
				SroLine,
				SroOper,
				TransNum,
				IncNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_SchedGetToBeSchedSp([Optional] int? InclInc,
		[Optional] int? InclSro,
		[Optional] int? InclSroLine,
		[Optional] int? InclSroOper,
		[Optional] int? InclPlanLabor,
		[Optional] string Owner,
		[Optional] string SroType,
		[Optional] int? InclMiscTime,
		[Optional] string City,
		[Optional] string State,
		[Optional] string Zip,
		[Optional] string County,
		[Optional] string Country,
		[Optional] string TerritoryRegion,
		[Optional] int? UseRegion,
		[Optional] string Dept)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_SchedGetToBeSchedExt = new CLM_SchedGetToBeSchedFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_SchedGetToBeSchedExt.CLM_SchedGetToBeSchedSp(InclInc,
				InclSro,
				InclSroLine,
				InclSroOper,
				InclPlanLabor,
				Owner,
				SroType,
				InclMiscTime,
				City,
				State,
				Zip,
				County,
				Country,
				TerritoryRegion,
				UseRegion,
				Dept);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}

