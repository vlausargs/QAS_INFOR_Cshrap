//PROJECT NAME: Logistics
//CLASS NAME: CLM_SchedGetToBeSched.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class CLM_SchedGetToBeSched : ICLM_SchedGetToBeSched
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_SchedGetToBeSched(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_SchedGetToBeSchedSp(int? InclInc = null,
		int? InclSro = null,
		int? InclSroLine = null,
		int? InclSroOper = null,
		int? InclPlanLabor = null,
		string Owner = null,
		string SroType = null,
		int? InclMiscTime = null,
		string City = null,
		string State = null,
		string Zip = null,
		string County = null,
		string Country = null,
		string TerritoryRegion = null,
		int? UseRegion = null,
		string Dept = null)
		{
			ListYesNoType _InclInc = InclInc;
			ListYesNoType _InclSro = InclSro;
			ListYesNoType _InclSroLine = InclSroLine;
			ListYesNoType _InclSroOper = InclSroOper;
			ListYesNoType _InclPlanLabor = InclPlanLabor;
			FSPartnerType _Owner = Owner;
			FSSROTypeType _SroType = SroType;
			ListYesNoType _InclMiscTime = InclMiscTime;
			CityType _City = City;
			StateType _State = State;
			PostalCodeType _Zip = Zip;
			CountyType _County = County;
			CountryType _Country = Country;
			FSRegionType _TerritoryRegion = TerritoryRegion;
			ListYesNoType _UseRegion = UseRegion;
			DeptType _Dept = Dept;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_SchedGetToBeSchedSp";
				
				appDB.AddCommandParameter(cmd, "InclInc", _InclInc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclSro", _InclSro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclSroLine", _InclSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclSroOper", _InclSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclPlanLabor", _InclPlanLabor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Owner", _Owner, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroType", _SroType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclMiscTime", _InclMiscTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "County", _County, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TerritoryRegion", _TerritoryRegion, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseRegion", _UseRegion, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Dept", _Dept, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
