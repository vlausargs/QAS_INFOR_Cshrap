//PROJECT NAME: Logistics
//CLASS NAME: ISSSOPMInit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISSSOPMInit
	{
		(int? ReturnCode,
			string Infobar) SSSOPMInitSp(
			string Infobar);
	}
}

