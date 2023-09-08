//PROJECT NAME: Production
//CLASS NAME: IApsGetSeqCustName.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsGetSeqCustName
	{
		string ApsGetSeqCustNameFn(
			string PCustNum);
	}
}

