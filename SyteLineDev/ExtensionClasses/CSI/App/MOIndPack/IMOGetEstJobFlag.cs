//PROJECT NAME: MOIndPack
//CLASS NAME: IMOGetEstJobFlag.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MOIndPack
{
	public interface IMOGetEstJobFlag
	{
		int? MOGetEstJobFlagFn(
			string CoNum);
	}
}

