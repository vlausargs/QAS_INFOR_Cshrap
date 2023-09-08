//PROJECT NAME: Production
//CLASS NAME: IPmfPnMatIssuedCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
    public interface IPmfPnMatIssuedCRUD
    {
        (int? ReturnCode, string warning) AltExtGen_PmfPnMatIssuedSp(string AltExtGenSp, Guid? job_RowPointer, int? op_complete, string warning);
        decimal? JobSelect(Guid? job_RowPointer);
        void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
        ICollectionLoadResponse Optional_Module1Select();
        bool Optional_ModuleForExists();
        (string, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
        void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
        ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
        bool Tv_ALTGENForExists();
    }
}