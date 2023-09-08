//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ReplDocumentExt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ReplDocumentExt
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ReplDocumentExtSp(string Item,
		string Ref_Type,
		string Ref_Num,
		int? Ref_Line_suf,
		int? Ref_Release,
		string DocumentName,
		string BODTagName);
	}
}

