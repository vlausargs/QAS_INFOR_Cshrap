//PROJECT NAME: Logistics
//CLASS NAME: IAptrxVerifyInvNumCRUD.cs

using System;
using System.Collections.Generic;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
    public interface IAptrxVerifyInvNumCRUD
    {
        bool Optional_ModuleForExists();
        ICollectionLoadResponse Optional_Module1Select();
        void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
        bool Tv_ALTGENForExists();
        (string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
        ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
        void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
        ICollectionLoadResponse SitesSelect();
      //  void SitesInsert(ICollectionLoadResponse SitesLoadResponse);
        (string SiteRef, int? Voucher, int? rowCount) Aptrxp_AllLoad(string PVendNum, string PInvNum, string SiteRef, int? Voucher, IList<string> SiteGroupVar);
        (string SiteRef, int? Voucher, int? rowCount) Aptrx_AllLoad(string PVendNum, string PInvNum, string SiteRef, int? Voucher, IList<string> SiteGroupVar);
        (int? ReturnCode, string Infobar) AltExtGen_AptrxVerifyInvNumSp(string AltExtGenSp, string PVendNum, string PInvNum, string Infobar);
    }
}

