using CSI.Data.CRUD;

namespace CSI.Employee
{
    public interface ICLM_PayrollCheckDateChartCRUD
    {
        (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_PayrollCheckDateChartSp(string AltExtGenSp, string EmpNum);
        void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
        ICollectionLoadResponse Optional_Module1Select();
        bool Optional_ModuleForExists();
        (string, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
        void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
        ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
        bool Tv_ALTGENForExists();
        void Tv_Results_Tbl1Insert(ICollectionLoadResponse tv_results_tbl1ExecResultLoadResponse);
        ICollectionLoadResponse Tv_Results_Tbl2Select();
        void Tv_Results_TblDelete(ICollectionLoadResponse tv_results_tblLoadResponse);
        ICollectionLoadResponse Tv_Results_TblSelect();
    }
}