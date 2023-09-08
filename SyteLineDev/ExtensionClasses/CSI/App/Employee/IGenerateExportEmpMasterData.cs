//PROJECT NAME: Employee
//CLASS NAME: IGenerateExportEmpMasterData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IGenerateExportEmpMasterData
	{
		(ICollectionLoadResponse Data, int? ReturnCode) GenerateExportEmpMasterDataSp(string StartingDept = null,
		string EndingDept = null,
		string StartingEmpNum = null,
		string EndingEmpNum = null,
		int? IsExportChangedOnly = 0,
		int? UseEffectiveDateOverride = 0,
		DateTime? EffectiveDateOverride = null,
		int? EffectiveDateOverrideOffSet = null,
		int? UseEndDateOverride = 0,
		DateTime? EndDateOverride = null,
		int? EndDateOverrideOffSet = null,
		decimal? UserId = null);
	}
}

