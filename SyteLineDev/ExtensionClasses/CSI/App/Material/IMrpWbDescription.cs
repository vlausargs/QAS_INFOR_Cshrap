//PROJECT NAME: Material
//CLASS NAME: IMrpWbDescription.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMrpWbDescription
	{
		string MrpWbDescriptionFn(
			string MrpWbRefType,
			string MrpWbRefNum,
			int? MrpWbRefLineSuf,
			int? MrpWbRefRelease,
			int? MrpWbRefSeq,
			string MrpWbItem);
	}
}

