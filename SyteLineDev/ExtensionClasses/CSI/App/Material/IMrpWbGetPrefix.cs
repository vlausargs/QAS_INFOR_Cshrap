//PROJECT NAME: Material
//CLASS NAME: IMrpWbGetPrefix.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMrpWbGetPrefix
	{
		(int? ReturnCode, string PoparmsPoPrefix,
		string PoparmsPoChange,
		string PoparmsPrqPrefix,
		string InvparmsTrnPrefix,
		string SfcparmsWoPrefix,
		string SfcparmsPsPrefix) MrpWbGetPrefixSp(string PoparmsPoPrefix,
		string PoparmsPoChange,
		string PoparmsPrqPrefix,
		string InvparmsTrnPrefix,
		string SfcparmsWoPrefix,
		string SfcparmsPsPrefix);
	}
}

