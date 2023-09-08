//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSGetCustDef.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISSSFSGetCustDef
	{
		(int? ReturnCode, string TransNat,
		string Delterm,
		string ProcessInd,
		string Infobar) SSSFSGetCustDefSp(string CustNum,
		string TransNat,
		string Delterm,
		string ProcessInd,
		string Infobar);
	}
}

