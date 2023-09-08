//PROJECT NAME: Production
//CLASS NAME: IPsitemItemValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPsitemItemValid
	{
		(int? ReturnCode, string Item,
		string Revision,
		string Description,
		int? StdBOMExists,
		string Infobar) PsitemItemValidSp(string PsNum,
		string Item,
		string Revision,
		string Description,
		int? StdBOMExists,
		string Infobar);
	}
}

