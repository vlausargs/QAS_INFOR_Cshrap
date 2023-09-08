//PROJECT NAME: Codes
//CLASS NAME: ICLM_DimensionAttributes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ICLM_DimensionAttributes
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_DimensionAttributesSp(string ObectName,
		string DimName,
		string ParentDimension);
	}
}

