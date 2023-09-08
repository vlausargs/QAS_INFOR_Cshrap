//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBReplAttributeElementsPivotExt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBReplAttributeElementsPivotExt
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) CLM_ESBReplAttributeElementsPivotExtSp(string BODNoun,
		string BODVerb,
		string DocumentID,
		int? ParentNodeID,
		string BODTagName,
		string InfoBar);
	}
}

