//PROJECT NAME: Data
//CLASS NAME: IAPP_ExpandNumSortChar.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IAPP_ExpandNumSortChar
	{
		(ICollectionLoadResponse Data, int? ReturnCode,
			string ExpandedValue) APP_ExpandNumSortCharSp(
			int? Length,
			string UnexpandedValue,
			string IDOName,
			string PropertyName,
			string ExpandedValue);
	}
}

