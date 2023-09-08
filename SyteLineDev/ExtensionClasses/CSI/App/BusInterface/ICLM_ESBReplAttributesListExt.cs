//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBReplAttributesListExt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBReplAttributesListExt
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBReplAttributesListExtSp(
			string BODNoun,
			string BODVerb,
			string DocumentID,
			int? ParentNodeID,
			string BODTagName,
			string InfoBar);
	}
}

