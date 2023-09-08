//PROJECT NAME: Logistics
//CLASS NAME: IUpdateApparms.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IUpdateApparms
	{
		int? UpdateApparmsSp(string PEFTFile,
		DateTime? PEFTFileDate,
		string PFileFormat);
	}
}

