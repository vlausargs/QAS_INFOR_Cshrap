//PROJECT NAME: Material
//CLASS NAME: IPhyinvValEmployee.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IPhyinvValEmployee
	{
		(int? ReturnCode, string Infobar) PhyinvValEmployeeSp(string Employee,
		string Validate,
		int? MType,
		string Infobar);
	}
}

