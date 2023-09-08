//PROJECT NAME: Production
//CLASS NAME: IPP_SaveJobProperties.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPP_SaveJobProperties
	{
		(int? ReturnCode, string Infobar) PP_SaveJobPropertiesSp(string Job,
		int? suffix,
		int? Out,
		int? Up,
		string Infobar);
	}
}

