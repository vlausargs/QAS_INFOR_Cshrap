//PROJECT NAME: Material
//CLASS NAME: ICLM_AttributeValue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICLM_AttributeValue
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_AttributeValueSp(Guid? RowPointer,
		string AttrGroup,
		string AttrGroupClass,
		string FilterString = null);
	}
}

