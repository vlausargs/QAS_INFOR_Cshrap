//PROJECT NAME: Logistics
//CLASS NAME: SchedLoadPartnerFilter.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISchedLoadPartnerFilter
	{
		(int? ReturnCode, string PartnerList,
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
		string Infobar) SchedLoadPartnerFilterSp(string Username,
		string FilterName,
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
	
	public class SchedLoadPartnerFilter : ISchedLoadPartnerFilter
	{
		readonly IApplicationDB appDB;
		
		public SchedLoadPartnerFilter(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PartnerList,
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
		string Infobar) SchedLoadPartnerFilterSp(string Username,
		string FilterName,
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
			StringType _Username = Username;
			StringType _FilterName = FilterName;
			IntType _FilterType = FilterType;
			LongListType _PartnerList = PartnerList;
			LongListType _CertList = CertList;
			LongListType _SkillList = SkillList;
			LongListType _DeptList = DeptList;
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
				cmd.CommandText = "SchedLoadPartnerFilterSp";
				
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterName", _FilterName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterType", _FilterType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerList", _PartnerList, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CertList", _CertList, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SkillList", _SkillList, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DeptList", _DeptList, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UseCoverage", _UseCoverage, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "County", _County, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Region", _Region, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PartnerList = _PartnerList;
				CertList = _CertList;
				SkillList = _SkillList;
				DeptList = _DeptList;
				UseCoverage = _UseCoverage;
				Country = _Country;
				State = _State;
				City = _City;
				Zip = _Zip;
				County = _County;
				Region = _Region;
				Infobar = _Infobar;
				
				return (Severity, PartnerList, CertList, SkillList, DeptList, UseCoverage, Country, State, City, Zip, County, Region, Infobar);
			}
		}
	}
}
