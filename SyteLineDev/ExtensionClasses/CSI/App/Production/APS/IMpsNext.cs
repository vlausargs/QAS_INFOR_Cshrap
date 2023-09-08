//PROJECT NAME: Production
//CLASS NAME: IMpsNext.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IMpsNext
	{
		(int? ReturnCode, string PLastTran) MpsNextSp(string PLastTran);
	}
}

