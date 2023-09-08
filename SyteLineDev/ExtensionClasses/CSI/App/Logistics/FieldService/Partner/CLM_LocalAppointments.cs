//PROJECT NAME: Logistics
//CLASS NAME: CLM_LocalAppointments.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class CLM_LocalAppointments : ICLM_LocalAppointments
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_LocalAppointments(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_LocalAppointmentsSp(int? IncludeAppointment = 0,
		int? IncludeFutureService = 0,
		int? DaysAhead = 0,
		int? UnassignedOnly = 0,
		int? IncludeSROLine = 0,
		int? IncludeSROOperation = 0,
		string FCity = null,
		string FState = null,
		string FZip = null,
		string FCounty = null,
		string FCountry = null,
		string FTerritoryRegion = null,
		string FPartnerID = null,
		string FDept = null,
		string FSroType = null)
		{
			ListYesNoType _IncludeAppointment = IncludeAppointment;
			ListYesNoType _IncludeFutureService = IncludeFutureService;
			DateOffsetType _DaysAhead = DaysAhead;
			ListYesNoType _UnassignedOnly = UnassignedOnly;
			ListYesNoType _IncludeSROLine = IncludeSROLine;
			ListYesNoType _IncludeSROOperation = IncludeSROOperation;
			CityType _FCity = FCity;
			StateType _FState = FState;
			PostalCodeType _FZip = FZip;
			CountyType _FCounty = FCounty;
			CountryType _FCountry = FCountry;
			FSRegionType _FTerritoryRegion = FTerritoryRegion;
			FSPartnerType _FPartnerID = FPartnerID;
			DeptType _FDept = FDept;
			LongListType _FSroType = FSroType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_LocalAppointmentsSp";
				
				appDB.AddCommandParameter(cmd, "IncludeAppointment", _IncludeAppointment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeFutureService", _IncludeFutureService, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DaysAhead", _DaysAhead, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnassignedOnly", _UnassignedOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeSROLine", _IncludeSROLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeSROOperation", _IncludeSROOperation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FCity", _FCity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FState", _FState, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FZip", _FZip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FCounty", _FCounty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FCountry", _FCountry, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FTerritoryRegion", _FTerritoryRegion, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FPartnerID", _FPartnerID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FDept", _FDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FSroType", _FSroType, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
