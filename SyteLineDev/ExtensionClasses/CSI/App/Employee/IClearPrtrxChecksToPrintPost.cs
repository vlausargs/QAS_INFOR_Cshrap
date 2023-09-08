//PROJECT NAME: Employee
//CLASS NAME: IClearPrtrxChecksToPrintPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IClearPrtrxChecksToPrintPost
	{
		int? ClearPrtrxChecksToPrintPostSp(Guid? pSessionID = null);
	}
}

