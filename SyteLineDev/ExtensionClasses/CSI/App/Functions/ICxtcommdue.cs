//PROJECT NAME: Data
//CLASS NAME: ICxtcommdue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICxtcommdue
	{
		(int? ReturnCode,
			string Infobar) CxtcommdueSp(
			string CustNum,
			string Infobar);
	}
}

