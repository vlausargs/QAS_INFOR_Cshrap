//PROJECT NAME: Data
//CLASS NAME: IDelCoSlsComm.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDelCoSlsComm
	{
		(int? ReturnCode,
			string Infobar) DelCoSlsCommSp(
			string CoNum,
			int? CoLine,
			string Infobar);
	}
}

