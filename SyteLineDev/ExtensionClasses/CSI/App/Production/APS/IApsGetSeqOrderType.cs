//PROJECT NAME: Production
//CLASS NAME: IApsGetSeqOrderType.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsGetSeqOrderType
	{
		string ApsGetSeqOrderTypeFn(
			string POrderTypeVal);
	}
}

