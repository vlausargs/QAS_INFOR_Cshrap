//PROJECT NAME: Finance
//CLASS NAME: ISSSCCIARPayFromTrans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.CreditCard
{
	public interface ISSSCCIARPayFromTrans
	{
		(int? ReturnCode,
			string Infobar) SSSCCIARPayFromTransSp(
			Guid? CCIRowPointer,
			string Infobar);
	}
}

