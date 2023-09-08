//PROJECT NAME: Data
//CLASS NAME: ICxtarfin.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICxtarfin
	{
		(int? ReturnCode,
			string Infobar) CxtarfinSp(
			string CustNum,
			string Infobar);
	}
}

