//PROJECT NAME: Logistics
//CLASS NAME: IEstimateLinesValidateUM.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IEstimateLinesValidateUM
	{
		(int? ReturnCode, string Infobar) EstimateLinesValidateUMSp(string PUM,
		string PItem,
		string Infobar);
	}
}

