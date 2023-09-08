//PROJECT NAME: Admin
//CLASS NAME: ICLM_StartFormSubForms.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface ICLM_StartFormSubForms
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_StartFormSubFormsSp();
	}
}

