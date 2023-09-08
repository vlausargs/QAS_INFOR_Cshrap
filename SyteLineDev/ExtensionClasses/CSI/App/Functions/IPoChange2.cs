//PROJECT NAME: Data
//CLASS NAME: IPoChange2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPoChange2
	{
		(int? ReturnCode,
			int? PoChange,
			int? PoChangePrompt2User) PoChange2Sp(
			string PoNum,
			string PoStatus,
			int? PoChange,
			int? PoChangePrompt2User);
	}
}

