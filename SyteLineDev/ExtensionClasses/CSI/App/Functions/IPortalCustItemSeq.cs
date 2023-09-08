//PROJECT NAME: Data
//CLASS NAME: IPortalCustItemSeq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPortalCustItemSeq
	{
		int? PortalCustItemSeqFn(
			string item,
			string custnum);
	}
}

