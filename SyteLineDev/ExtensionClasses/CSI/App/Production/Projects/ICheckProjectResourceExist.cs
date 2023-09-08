//PROJECT NAME: Production
//CLASS NAME: ICheckProjectResourceExist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface ICheckProjectResourceExist
	{
		(int? ReturnCode, string Infobar) CheckProjectResourceExistSp(string ProjNum,
		int? TaskNum,
		string CostCode,
		string Type,
		string CostCodeType,
		string Infobar);
	}
}

