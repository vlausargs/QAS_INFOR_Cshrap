//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSchedPartnerFilterSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISSSFSSchedPartnerFilterSave
	{
		(int? ReturnCode, string Infobar) SSSFSSchedPartnerFilterSaveSp(string FilterName,
		string Username,
		int? FilterType,
		string PartnerList,
		string CertList,
		string SkillList,
		string DeptList,
		byte? UseCoverage,
		string Country,
		string State,
		string City,
		string Zip,
		string County,
		string Region,
		string Infobar);
	}
	
	public class SSSFSSchedPartnerFilterSave : ISSSFSSchedPartnerFilterSave
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSchedPartnerFilterSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSFSSchedPartnerFilterSaveSp(string FilterName,
		string Username,
		int? FilterType,
		string PartnerList,
		string CertList,
		string SkillList,
		string DeptList,
		byte? UseCoverage,
		string Country,
		string State,
		string City,
		string Zip,
		string County,
		string Region,
		string Infobar)
		{
			StringType _FilterName = FilterName;
			UsernameType _Username = Username;
			IntType _FilterType = FilterType;
			StringType _PartnerList = PartnerList;
			StringType _CertList = CertList;
			StringType _SkillList = SkillList;
			StringType _DeptList = DeptList;
			ListYesNoType _UseCoverage = UseCoverage;
			CountryType _Country = Country;
			StateType _State = State;
			CityType _City = City;
			PostalCodeType _Zip = Zip;
			CountyType _County = County;
			FSRegionType _Region = Region;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSchedPartnerFilterSaveSp";
				
				appDB.AddCommandParameter(cmd, "FilterName", _FilterName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterType", _FilterType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerList", _PartnerList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CertList", _CertList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SkillList", _SkillList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeptList", _DeptList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseCoverage", _UseCoverage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "County", _County, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Region", _Region, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
