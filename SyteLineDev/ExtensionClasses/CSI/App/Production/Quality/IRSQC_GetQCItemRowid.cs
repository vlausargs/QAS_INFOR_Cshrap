//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetQCItemRowid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetQCItemRowid
	{
		(int? ReturnCode, Guid? o_RowPointer,
		string Infobar) RSQC_GetQCItemRowidSp(string i_Item,
		string i_RefType,
		string i_VendNum,
		string i_CustNum,
		int? i_OperNum,
		int? i_TestSeq,
		Guid? o_RowPointer,
		string Infobar);
	}
}

