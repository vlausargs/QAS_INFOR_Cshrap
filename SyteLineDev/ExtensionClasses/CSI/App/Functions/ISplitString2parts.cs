//PROJECT NAME: Data
//CLASS NAME: ISplitString2parts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISplitString2parts
	{
		string SplitString2partsFn(
			string Delimiter,
			string List,
			int? PartNumber);
	}
}

