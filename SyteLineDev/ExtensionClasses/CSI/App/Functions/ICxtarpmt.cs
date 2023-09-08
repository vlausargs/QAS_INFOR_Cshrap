//PROJECT NAME: Data
//CLASS NAME: ICxtarpmt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICxtarpmt
	{
		(int? ReturnCode,
			string Infobar) CxtarpmtSp(
			string CustNum,
			string Infobar);
	}
}

