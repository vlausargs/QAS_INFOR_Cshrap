//PROJECT NAME: Codes
//CLASS NAME: IBuyerValidCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IBuyerValidCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse SelectOptional_ModuleForInsert();
		void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
		ICollectionLoadResponse SelectTv_ALTGENForDelete(string ALTGEN_SpName);
		void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(Guid? BuyerAvail, int? rowCount) LoadUsernames(string Buyer, Guid? BuyerAvail);
		(int? ReturnCode, string Infobar) AltExtGen_BuyerValidSp(string AltExtGenSp, string Buyer, string Infobar);
	}
}

