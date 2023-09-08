//PROJECT NAME: Data
//CLASS NAME: IMaskSsnByHrParms.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMaskSsnByHrParms
	{
		string MaskSsnByHrParmsFn(
			string PSsn);
	}
}

