//PROJECT NAME: Data
//CLASS NAME: IecniItemDescription.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IecniItemDescription
	{
		string ecniItemDescriptionFn(
			string EcnItemType,
			string Job,
			int? Suffix,
			string Item);
	}
}

