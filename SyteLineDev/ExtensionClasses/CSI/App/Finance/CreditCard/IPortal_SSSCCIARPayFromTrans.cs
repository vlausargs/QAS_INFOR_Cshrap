//PROJECT NAME: Finance
//CLASS NAME: IPortal_SSSCCIARPayFromTrans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.CreditCard
{
	public interface IPortal_SSSCCIARPayFromTrans
	{
		(int? ReturnCode, string Infobar) Portal_SSSCCIARPayFromTransSp(
			Guid? CCIRowPointer,
			string Infobar);
	}
}

