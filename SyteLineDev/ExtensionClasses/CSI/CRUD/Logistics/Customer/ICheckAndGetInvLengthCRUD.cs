//PROJECT NAME: Logistics
//CLASS NAME: ICheckAndGetInvLengthCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICheckAndGetInvLengthCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse SelectOptional_ModuleForInsert();
		void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
		ICollectionLoadResponse SelectTv_ALTGENForDelete(string ALTGEN_SpName);
		void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(int? PromptTaxDisc, int? rowCount) LoadTaxparms(int? PromptTaxDisc);
		(int? ReturnCode, int? Result, int? KeyLength, int? PromptTaxDisc, string Infobar) AltExtGen_CheckAndGetInvLength(string AltExtGenSp, string KeyName, int? Result, int? KeyLength, int? PromptTaxDisc, string Infobar);
	}
}

