//PROJECT NAME: Production
//CLASS NAME: ICheckOperationExists.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICheckOperationExists
	{
		(int? ReturnCode, string Infobar) CheckOperationExistsSp(string Job,
		int? Suffix,
		int? OperNum,
		string Item,
		string Infobar);
	}
}

