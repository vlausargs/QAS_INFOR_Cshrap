//PROJECT NAME: Logistics
//CLASS NAME: ICustomerQuoteExistsWarningCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICustomerQuoteExistsWarningCRUD
	{
		bool CheckOptional_ModuleExists();
		ICollectionLoadResponse SelectOptional_Module();
		void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse);
		bool CheckTv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
		ICollectionLoadResponse SelectTv_ALTGEN(string ALTGEN_SpName);
		void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		bool CheckCustNumForExists(string CoNum, string CustQuote, string CustNum);
		bool CheckProspectIdForExists(string CoNum, string CustQuote, string ProspectId);
		(int? ReturnCode, string Infobar) AltExtGen_CustomerQuoteExistsWarningSp(string AltExtGenSp, string CoNum, string CustQuote, string CustNum, string ProspectId, string Infobar);
	}
}

