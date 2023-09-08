//PROJECT NAME: Data
//CLASS NAME: ICopyCustomerNotesToCO.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICopyCustomerNotesToCO
	{
		(int? ReturnCode,
			string Infobar) CopyCustomerNotesToCOSp(
			Guid? CORowPointer,
			string CustNum,
			string Infobar);
	}
}

