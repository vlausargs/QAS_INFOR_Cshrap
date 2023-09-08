//PROJECT NAME: Data
//CLASS NAME: INextCampaign.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextCampaign
	{
		(int? ReturnCode,
			string Key,
			string Infobar) NextCampaignSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

