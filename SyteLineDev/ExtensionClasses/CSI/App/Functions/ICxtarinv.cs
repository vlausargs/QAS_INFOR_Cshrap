//PROJECT NAME: Data
//CLASS NAME: ICxtarinv.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICxtarinv
	{
		(int? ReturnCode,
			string Infobar) CxtarinvSp(
			string CustNum,
			string Infobar);
	}
}

