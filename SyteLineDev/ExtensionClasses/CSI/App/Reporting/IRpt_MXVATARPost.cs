//PROJECT NAME: Reporting
//CLASS NAME: IRpt_MXVATARPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_MXVATARPost
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_MXVATARPostSp();
	}
}

