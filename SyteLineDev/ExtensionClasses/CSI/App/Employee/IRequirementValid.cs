//PROJECT NAME: Employee
//CLASS NAME: IRequirementValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IRequirementValid
	{
		(int? ReturnCode, string DerDescription,
		string Infobar) RequirementValidSp(string ReqType,
		string Requirement,
		string DerDescription,
		string Infobar);
	}
}

