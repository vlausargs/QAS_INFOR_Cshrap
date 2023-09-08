//PROJECT NAME: Admin
//CLASS NAME: INextControlNumber.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface INextControlNumber
	{
		(int? ReturnCode, string ControlPrefix,
		string ControlSite,
		int? ControlYear,
		int? ControlPeriod,
		decimal? ControlNumber,
		string Infobar,
		decimal? OldControlNumber) NextControlNumberSp(string SubKey = null,
		string JournalId = null,
		int? UpdatePeriodsSeqOnly = 0,
		string ControlPrefix = null,
		string ControlSite = null,
		DateTime? TransDate = null,
		int? ControlYear = null,
		int? ControlPeriod = null,
		string SequenceBy = null,
		decimal? ControlNumber = null,
		string Infobar = null,
		decimal? OldControlNumber = null);
	}
}

