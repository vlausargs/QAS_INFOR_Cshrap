//PROJECT NAME: Production
//CLASS NAME: IEngWBGetJobVar.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IEngWBGetJobVar
	{
		(int? ReturnCode, string Job) EngWBGetJobVarSp(string Job = null);
	}
}

