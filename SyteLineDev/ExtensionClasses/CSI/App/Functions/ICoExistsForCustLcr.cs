//PROJECT NAME: Data
//CLASS NAME: ICoExistsForCustLcr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICoExistsForCustLcr
	{
		(int? ReturnCode,
			string Infobar) CoExistsForCustLcrSp(
			string CustNum,
			string LcrNum,
			string Infobar);
	}
}

