//PROJECT NAME: Logistics
//CLASS NAME: SSSFSPartTmpLoad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSPartTmpLoad : ISSSFSPartTmpLoad
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSPartTmpLoad(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSPartTmpLoadSp(string SkillFilter,
		string LicertFilter,
		string DeptFilter,
		string AreaDescFilter,
		string CountryFilter,
		string StateFilter,
		string CountyFilter,
		string CityFilter,
		string ZipFilter)
		{
			LongListType _SkillFilter = SkillFilter;
			LongListType _LicertFilter = LicertFilter;
			LongListType _DeptFilter = DeptFilter;
			DescriptionType _AreaDescFilter = AreaDescFilter;
			CountryType _CountryFilter = CountryFilter;
			StateType _StateFilter = StateFilter;
			CountyType _CountyFilter = CountyFilter;
			CityType _CityFilter = CityFilter;
			PostalCodeType _ZipFilter = ZipFilter;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSPartTmpLoadSp";
				
				appDB.AddCommandParameter(cmd, "SkillFilter", _SkillFilter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LicertFilter", _LicertFilter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeptFilter", _DeptFilter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AreaDescFilter", _AreaDescFilter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CountryFilter", _CountryFilter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StateFilter", _StateFilter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CountyFilter", _CountyFilter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CityFilter", _CityFilter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ZipFilter", _ZipFilter, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
