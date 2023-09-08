//PROJECT NAME: Logistics
//CLASS NAME: ICLM_GetCoNumCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_GetCoNumCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		bool Customer_Bank_AccountForExists(string BankRouting, string BankAccount);
		ICollectionLoadResponse Customer_Bank_Account2Select(string CustNum, string BankRouting, string BankAccount);
		ICollectionLoadResponse Customer1Select(string CustNum);
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_GetCoNumSp(string AltExtGenSp, string CustNum, string BankRouting, string BankAccount);
	}
}

