//PROJECT NAME: Finance
//CLASS NAME: IFinRptXMLError.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFinRptXMLError
	{
		(int? ReturnCode,
			string Infobar) FinRptXMLErrorSp(
			string ObjectName,
			string ToSite,
			int? Transactional,
			string Infobar);
	}
}

