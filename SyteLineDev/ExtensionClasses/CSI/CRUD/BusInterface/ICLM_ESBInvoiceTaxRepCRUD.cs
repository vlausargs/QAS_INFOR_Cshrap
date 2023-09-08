//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBInvoiceTaxRepCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
    public interface ICLM_ESBInvoiceTaxRepCRUD
    {
        bool Optional_ModuleForExists();
        ICollectionLoadResponse Optional_Module1Select();
        void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
        bool Tv_ALTGENForExists();
        (string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
        ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
        void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
        ICollectionLoadResponse EsbinvoicetaxrepviewSelect(string InvNum, int? InvSeq);
        (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_ESBInvoiceTaxRepSp(string AltExtGenSp, string InvNum, int? InvSeq);
    }
}

