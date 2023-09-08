//PROJECT NAME: Finance
//CLASS NAME: IArOpenType.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArOpenType
	{
		string ArOpenTypeFn(
			string PCustNum,
			int? PCheckNum);
	}
}

