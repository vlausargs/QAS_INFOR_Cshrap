//PROJECT NAME: Data
//CLASS NAME: ITHAApptcvdb.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITHAApptcvdb
	{
		(int? ReturnCode,
			string Infobar) THAApptcvdbSp(
			string PFromSite,
			string PToSite,
			Guid? PAppmtdRowPointer,
			string Infobar);
	}
}

