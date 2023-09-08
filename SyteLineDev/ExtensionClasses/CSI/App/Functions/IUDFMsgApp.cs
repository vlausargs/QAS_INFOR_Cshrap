//PROJECT NAME: Data
//CLASS NAME: IUDFMsgApp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUDFMsgApp
	{
		string UDFMsgAppFn(
			string Infobar,
			string BaseMsg,
			string Parm1 = "",
			string Parm2 = "",
			string Parm3 = "",
			string Parm4 = "",
			string Parm5 = "",
			string Parm6 = "",
			string Parm7 = "",
			string Parm8 = "",
			string Parm9 = "",
			string Parm10 = "",
			string Parm11 = "",
			string Parm12 = "",
			string Parm13 = "",
			string Parm14 = "",
			string Parm15 = "");
	}
}

