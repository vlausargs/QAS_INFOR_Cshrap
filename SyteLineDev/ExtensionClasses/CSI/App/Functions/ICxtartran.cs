//PROJECT NAME: Data
//CLASS NAME: ICxtartran.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICxtartran
	{
		(int? ReturnCode,
			string Infobar) CxtartranSp(
			string CustNum,
			string Infobar);
	}
}

