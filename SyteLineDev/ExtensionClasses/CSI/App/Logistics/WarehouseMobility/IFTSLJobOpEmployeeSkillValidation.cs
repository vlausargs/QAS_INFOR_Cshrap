//PROJECT NAME: Logistics
//CLASS NAME: IFTSLJobOpEmployeeSkillValidation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLJobOpEmployeeSkillValidation
	{
		(int? ReturnCode, string Infobar) FTSLJobOpEmployeeSkillValidationSp(string EmpNum,
		string Job,
		int? Suffix,
		int? Operation,
		string Infobar,
		DateTime? PunchDate,
		string ERPQueryResponseString);
	}
}

