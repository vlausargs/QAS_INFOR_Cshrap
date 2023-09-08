//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSContSetHdrBilledThru.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSContSetHdrBilledThru
	{
		(int? ReturnCode,
			string Infobar) SSSFSContSetHdrBilledThruSp(
			string Contract,
			string Infobar);
	}
}

