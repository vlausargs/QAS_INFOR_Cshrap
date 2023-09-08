//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetMATLRULECRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
    public interface ICLM_ApsGetMATLRULECRUD
    {
        bool Optional_ModuleForExists();
        ICollectionLoadResponse Optional_Module1Select();
        void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
        bool Tv_ALTGENForExists();
        (string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
        ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
        void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
        ICollectionLoadResponse DynamicparametersSelect(string SelectionClause, string FromClause, string WhereClause, string AdditionalClause, string Filter);
        void DynamicparametersInsert(ICollectionLoadResponse DynamicParametersLoadResponse);
        (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_ApsGetMATLRULESp(string AltExtGenSp, int? AltNo, string Filter);
    }
}

