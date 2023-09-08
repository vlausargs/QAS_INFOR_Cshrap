//PROJECT NAME: Data
//CLASS NAME: IEdiDateToStrings.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiDateToStrings
	{
		(int? ReturnCode,
			string strDate,
			string strTime) EdiDateToStringsSp(
			DateTime? InputDate,
			string strDate,
			string strTime);
	}
}

