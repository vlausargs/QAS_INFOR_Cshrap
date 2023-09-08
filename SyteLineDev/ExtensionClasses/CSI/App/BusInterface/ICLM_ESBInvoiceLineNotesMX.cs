//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBInvoiceLineNotesMX.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBInvoiceLineNotesMX
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBInvoiceLineNotesMXSp(
			string InvNum,
			int? InvSeq,
			int? Line);
	}
}

