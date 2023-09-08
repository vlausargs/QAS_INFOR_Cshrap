//PROJECT NAME: Data
//CLASS NAME: IEdiOutPlnpoC.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiOutPlnpoC
	{
		(int? ReturnCode,
			int? RecCount,
			string Infobar) EdiOutPlnpoCSp(
			Guid? PItemVendRecid,
			int? RecCount,
			string Infobar);
	}
}

