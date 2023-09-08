//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSPartTmpLoad.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISSSFSPartTmpLoad
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSPartTmpLoadSp(string SkillFilter,
		string LicertFilter,
		string DeptFilter,
		string AreaDescFilter,
		string CountryFilter,
		string StateFilter,
		string CountyFilter,
		string CityFilter,
		string ZipFilter);
	}
}

