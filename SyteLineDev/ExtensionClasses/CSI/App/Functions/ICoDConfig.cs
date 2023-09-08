//PROJECT NAME: Data
//CLASS NAME: ICoDConfig.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICoDConfig
	{
		ICollectionLoadResponse CoDConfigFn(
			string PCoitemCoNum,
			int? PCoitemCoLine,
			int? PCoitemCoRelease,
			string PCoitemItem,
			string PCoitemShipSite,
			DateTime? PCoOrderDate,
			string PCoitemFeatStr);
	}
}

