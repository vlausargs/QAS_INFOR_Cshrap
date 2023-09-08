//PROJECT NAME: Data
//CLASS NAME: IDeleteMpsRcpts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDeleteMpsRcpts
	{
		(int? ReturnCode,
			string Infobar) DeleteMpsRcptsSp(
			string Item,
			int? MpsFlag,
			string Infobar);
	}
}

