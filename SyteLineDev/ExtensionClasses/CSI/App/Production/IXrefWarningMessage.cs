//PROJECT NAME: Production
//CLASS NAME: IXrefWarningMessage.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IXrefWarningMessage
	{
		(int? ReturnCode, string WarningMsg) XrefWarningMessageSp(string NewRefType,
		string NewRefNum,
		int? NewRefLineSuf,
		int? NewRefRel,
		string WarningMsg);
	}
}

