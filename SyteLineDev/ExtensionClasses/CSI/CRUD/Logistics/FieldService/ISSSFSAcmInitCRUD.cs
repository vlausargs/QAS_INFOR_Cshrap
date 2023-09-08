//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSAcmInitCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
    public interface ISSSFSAcmInitCRUD
    {
        bool Optional_ModuleForExists();
        ICollectionLoadResponse Optional_Module1Select();
        void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
        bool Tv_ALTGENForExists();
        string Tv_ALTGEN1Load();
        ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
        void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
        (string Id, int? TotalPeriods) Fs_ParmsLoad();
        (int? ReturnCode, string Id, int? TotalPeriods, string Infobar) AltExtGen_SSSFSAcmInitSp(string AltExtGenSp, string Id, int? TotalPeriods, string Infobar);
    }
}

