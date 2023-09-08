//PROJECT NAME: Logistics
//CLASS NAME: IHome_CustomerAnalysisCRUD.cs

using System;
using System.Collections.Generic;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.CRUD.Logistics.Customer
{
    public interface IHome_CustomerAnalysisCRUD
    {
        bool Optional_ModuleForExists();
        ICollectionLoadResponse SelectOptional_Module();
        void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse);
        bool Tv_ALTGENForExists();
        (string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
        ICollectionLoadResponse SelectTv_ALTGEN(string ALTGEN_SpName);
        void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
        ICollectionLoadResponse SelectSiteRef(string SiteGroup);
        //void InsertSiteRef(ICollectionLoadResponse nonTableLoadResponse);
        ICollectionLoadResponse SelectSites(string SiteGroup);
        //void InsertSites(ICollectionLoadResponse Sites1LoadResponse);
        ICollectionLoadResponse SelectProperties(string FilterString);
        ICollectionLoadResponse SelectDynamicparameters(string SelectionClause, string FromClause, string WhereClause, string AdditionalClause, string KeyColumns, string FilterCust);
        void InsertDynamicparameters(ICollectionLoadResponse DynamicParametersLoadResponse);
        void InsertCustagingWithNonTrigger(IList<string> SiteGroupVar, string filterStringForWhere, IList<object> parmList);
        (int? InitialCount, int? rowCount) LoadCustaging(int? InitialCount);
        (string LastSite, string LastCustNum, int? rowCount) LoadCustaging2(string LastSite, string LastCustNum);
        (int? NumCustomerBlocks, int? rowCount) LoadCustomer_All(int? NumCustomerBlocks, IList<string> SiteGroupVar);
        //ICollectionLoadResponse SelectDynamicparameters2();
        void UpdateDynamicparametersWithNonTrigger(string FilterAging);
        void InsertCustaging2(ICollectionLoadResponse CustAging21ExecResultLoadResponse);
        //ICollectionLoadResponse SelectCa();
        void DeleteCaWithNonTrigger();
        (int? PostAgeCount, int? rowCount) LoadCustaging3(int? PostAgeCount);
        //ICollectionLoadResponse SelectCustaging();
        void UpdateCustagingWithNonTrigger();
        //ICollectionLoadResponse SelectDynamicparameters3();
        void Dynamicparameters2UpdateWithNonTrigger(string LastSite, string LastCustNum, string FilterCust, IList<string> SiteGroupVar);
        void InsertCustaging3(ICollectionLoadResponse CustAging4ExecResultLoadResponse);
        (string LastSite, string LastCustNum, int? rowCount) LoadCustaging4(string LastCustNum, string LastSite);
        ICollectionLoadResponse SelectCustaging2(int? InitialCount);
        (string LastSite, string LastCustNum) SelectSubq(int? InitialCount);
        (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) AltExtGen_Home_CustomerAnalysisSp(string AltExtGenSp, string FilterString, string SiteGroup, string Infobar);
    }
}