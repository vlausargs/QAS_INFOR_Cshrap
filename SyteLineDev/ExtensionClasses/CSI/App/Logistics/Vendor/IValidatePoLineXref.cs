//PROJECT NAME: Logistics
//CLASS NAME: IValidatePoLineXref.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IValidatePoLineXref
	{
			(int? ReturnCode, string PromptMsg,
			string Infobar) 
		ValidatePoLineXrefSp(string PoNum,
			int? PoLine,
			int? PoRelease,
			string PoItem,
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			string PromptMsg,
			string Infobar);
	}
}

