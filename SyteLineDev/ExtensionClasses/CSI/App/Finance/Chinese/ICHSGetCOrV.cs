//PROJECT NAME: Finance
//CLASS NAME: ICHSGetCOrV.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSGetCOrV
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CHSGetCOrVSp(int? CorV,
		string Infobar,
		string FilterString = null);
	}
}

