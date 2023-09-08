//PROJECT NAME: Logistics
//CLASS NAME: IChangeVendorContractPriceStatusCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IChangeVendorContractPriceStatusCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		bool ItemvendpriceForExists(string Stat, string Item, string VendNum, DateTime? EffectDate);
		(int? ReturnCode, string Infobar) AltExtGen_ChangeVendorContractPriceStatusSp(string AltExtGenSp, string Item, string VendNum, DateTime? EffectDate, string Stat, string Infobar);
	}
}

