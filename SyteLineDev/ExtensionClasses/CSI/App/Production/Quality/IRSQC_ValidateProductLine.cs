//PROJECT NAME: Production
//CLASS NAME: IRSQC_ValidateProductLi.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_ValidateProductLi
	{
		(int? ReturnCode, string Coordinator,
		string Resolver,
		string Infobar) RSQC_ValidateProductLine(string ProductLine,
		string ReasonCode,
		string Coordinator,
		string Resolver,
		string Infobar);
	}
}

