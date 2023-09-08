//PROJECT NAME: Logistics
//CLASS NAME: IExtInterfaceParms.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IExtInterfaceParms
	{
		(int? ReturnCode, string ExpDocDir,
		string ExpDocPrefix,
		string ExpDocExt,
		string Infobar) ExtInterfaceParmsSp(string ExpDocDir,
		string ExpDocPrefix,
		string ExpDocExt,
		string Infobar);
	}
}

