//PROJECT NAME: Finance
//CLASS NAME: IVoidPayUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IVoidPayUpdate
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) VoidPayUpdateSp(Guid? pRowPointer,
		string SessionIDChar,
		int? ProcessFlag,
		string Infobar);
	}
}

