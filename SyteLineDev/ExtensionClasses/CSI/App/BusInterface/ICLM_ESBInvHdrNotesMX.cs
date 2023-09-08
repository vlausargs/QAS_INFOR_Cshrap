//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBInvHdrNotesMX.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBInvHdrNotesMX
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBInvHdrNotesMXSp(
			string InvNum,
			int? InvSeq);
	}
}

