//PROJECT NAME: Material
//CLASS NAME: ICLM_ContainerShipping.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICLM_ContainerShipping
	{
		(ICollectionLoadResponse Data, int? ReturnCode,
			string Infobar) CLM_ContainerShippingSp(
			string CoNum = null,
			string ContainerNum = null,
			string CurWhse = null,
			string Infobar = null);
	}
}

