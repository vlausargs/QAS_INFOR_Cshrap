//PROJECT NAME: Finance
//CLASS NAME: ICHSGetUnitCodeDesc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSGetUnitCodeDesc
	{
		string CHSGetUnitCodeDescFn(
			string PUnitCode,
			int? CodeNo);
	}
}

