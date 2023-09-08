//PROJECT NAME: Codes
//CLASS NAME: ICustSpecificUnitPriceExistsCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.CRUD.Codes
{
	public interface ICustSpecificUnitPriceExistsCRUD
	{
		bool CheckOptional_ModuleForExists();
		ICollectionLoadResponse SelectOptional_Module();
		void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse);
		bool CheckTv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
		ICollectionLoadResponse SelectTv_ALTGEN(string ALTGEN_SpName);
		void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(int? ReturnCode, int? CustSpecificUnitPriceExists, string Infobar) AltExtGen_CustSpecificUnitPriceExistsSp(string AltExtGenSp, string CurrCode, string CustNum, string Item, int? CustSpecificUnitPriceExists, string Infobar);
	}
}

