//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBInteractionNote.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBInteractionNote
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBInteractionNoteSp(string InteractionType,
		string InteractionRefNum);
	}
}

