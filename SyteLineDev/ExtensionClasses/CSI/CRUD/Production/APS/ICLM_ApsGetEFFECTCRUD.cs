//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetEFFECTCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
    public interface ICLM_ApsGetEFFECTCRUD
    {
        bool Optional_ModuleForExists();
        void DeclareALTGENTABLE();
        ICollectionLoadResponse Optional_Module1Select();
        void Optional_Module1Insert();
        bool Tv_ALTGENForExists();
        (string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
        void DeclareDynamicParameterTable();
        ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
        void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
        ICollectionLoadResponse DynamicparametersSelect(string SelectionClause, string FromClause, string Filter);
        void DynamicparametersInsert(string SelectionClause, string FromClause, string Filter);
        (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_ApsGetEFFECTSp(string AltExtGenSp, int? AltNo, string Filter);
    }
}

