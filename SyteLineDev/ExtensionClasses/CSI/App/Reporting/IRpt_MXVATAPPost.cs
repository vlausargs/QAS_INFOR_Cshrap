//PROJECT NAME: Reporting
//CLASS NAME: IRpt_MXVATAPPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_MXVATAPPost
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_MXVATAPPostSp();
	}
}

