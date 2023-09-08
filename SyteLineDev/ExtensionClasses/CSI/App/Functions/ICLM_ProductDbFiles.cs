//PROJECT NAME: Data
//CLASS NAME: ICLM_ProductDbFiles.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICLM_ProductDbFiles
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ProductDbFilesSp(
			string filterString = null,
			string DatabaseName = null,
			string pSite = null);
	}
}

