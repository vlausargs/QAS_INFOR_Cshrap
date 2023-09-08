//PROJECT NAME: Logistics
//CLASS NAME: ICLM_LastStagePipelineCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface ICLM_LastStagePipelineCRUD
    {
        bool Optional_ModuleForExists();
        ICollectionLoadResponse Optional_Module1Select();
        void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
        bool Tv_ALTGENForExists();
        (string, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
        ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
        void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
        (int?, int? rowCount) Opportunity_StageasosLoad(int? MaxChanceToClose);
        (string, int? rowCount) Opportunity_Stageasos1Load(int? MaxChanceToClose, string LastOppStage);
        (decimal?, int? rowCount) OpportunityasoppLoad(string LastOppStage, int? MaxChanceToClose, decimal? LastStagePipeline);
        ICollectionLoadResponse NontableSelect(decimal? LastStagePipeline);
        (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_LastStagePipelineSp(string AltExtGenSp);
    }
}

