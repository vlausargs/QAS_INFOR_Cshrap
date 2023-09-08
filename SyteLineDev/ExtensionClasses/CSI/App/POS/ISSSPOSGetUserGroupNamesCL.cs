//PROJECT NAME: POS
//CLASS NAME: ISSSPOSGetUserGroupNamesCL.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSGetUserGroupNamesCL
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSPOSGetUserGroupNamesCLSp();
	}
}

