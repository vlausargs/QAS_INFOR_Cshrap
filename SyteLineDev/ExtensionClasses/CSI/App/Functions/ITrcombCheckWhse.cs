//PROJECT NAME: Data
//CLASS NAME: ITrcombCheckWhse.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITrcombCheckWhse
	{
		(int? ReturnCode,
			string Infobar) TrcombCheckWhseSp(
			string FromSite,
			string FromWhse,
			string ToSite,
			string ToWhse,
			string Infobar);
	}
}

