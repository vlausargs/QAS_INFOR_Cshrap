//PROJECT NAME: BusInterface
//CLASS NAME: ILoadESBPersonnel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ILoadESBPersonnel
	{
		(int? ReturnCode, string Infobar) LoadESBPersonnelSp(string ActionExpression = null,
		string EmpNum = null,
		string Fname = null,
		string Nickname = null,
		string Mi = null,
		string Lname = null,
		string Sname = null,
		string GenderCode = null,
		string MaritalStatusCode = null,
		DateTime? BirthDate = null,
		string Nationality = null,
		string CitizenshipCountry = null,
		string Addr1 = null,
		string Addr2 = null,
		string Addr3 = null,
		string Addr4 = null,
		string City = null,
		string State = null,
		string ISOCountryCode = null,
		string Zip = null,
		string Phone = null,
		DateTime? HireDate = null,
		string Status = null,
		string CostCenterCode = null,
		string PosJobTitle = null,
		string EmpposJobId = null,
		DateTime? EmpAssignDate = null,
		string Extension = null,
		string EmailAddress = null,
		string Shift = null,
		string PayFreq = null,
		string BankName = null,
		string AccountID = null,
		string AccountType = null,
		string MilitaryDesc = null,
		string Military = null,
		string EthnicId = null,
		string Handicap = null,
		string Supervisor = null,
		decimal? DepAmount = null,
		decimal? DepPct = null,
		string Infobar = null);
	}
}

