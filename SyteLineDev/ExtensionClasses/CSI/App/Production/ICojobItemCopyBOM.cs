//PROJECT NAME: Production
//CLASS NAME: ICojobItemCopyBOM.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICojobItemCopyBOM
	{
		(int? ReturnCode, string Infobar) CojobItemCopyBOMSp(string Job,
		int? Suffix,
		string Item,
		string AlternateID,
		string Infobar);
	}
}

