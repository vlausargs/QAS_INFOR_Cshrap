//PROJECT NAME: Finance
//CLASS NAME: IArTermDueGetDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArTermDueGetDate
	{
		ICollectionLoadResponse ArTermDueGetDateFn(
			string PCustNum,
			string PInvNum,
			int? PInvSeq);
	}
}

