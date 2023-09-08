//PROJECT NAME: CSIMaterial
//CLASS NAME: CostingAnalysisAlternativeRoll.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
    public interface ICostingAnalysisAlternativeRoll
    {
        (int? ReturnCode, string Infobar) CostingAnalysisAlternativeRollUp(string CostingAlt,
        string PMTCode,
        string ABCCode,
        string CostMethod,
        string MatlType,
        string ProductCodeStarting,
        string ProductCodeEnding,
        string ItemStarting,
        string ItemEnding,
        byte? IteminAlternativeList,
        string Infobar);
    }

    public class CostingAnalysisAlternativeRoll : ICostingAnalysisAlternativeRoll
    {
        readonly IApplicationDB appDB;

        public CostingAnalysisAlternativeRoll(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string Infobar) CostingAnalysisAlternativeRollUp(string CostingAlt,
        string PMTCode,
        string ABCCode,
        string CostMethod,
        string MatlType,
        string ProductCodeStarting,
        string ProductCodeEnding,
        string ItemStarting,
        string ItemEnding,
        byte? IteminAlternativeList,
        string Infobar)
        {
            CostingAlternativeType _CostingAlt = CostingAlt;
            StringType _PMTCode = PMTCode;
            StringType _ABCCode = ABCCode;
            StringType _CostMethod = CostMethod;
            StringType _MatlType = MatlType;
            ProductCodeType _ProductCodeStarting = ProductCodeStarting;
            ProductCodeType _ProductCodeEnding = ProductCodeEnding;
            ItemType _ItemStarting = ItemStarting;
            ItemType _ItemEnding = ItemEnding;
            ListYesNoType _IteminAlternativeList = IteminAlternativeList;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CostingAnalysisAlternativeRollUpSp";

                appDB.AddCommandParameter(cmd, "CostingAlt", _CostingAlt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PMTCode", _PMTCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ABCCode", _ABCCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CostMethod", _CostMethod, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "MatlType", _MatlType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ProductCodeStarting", _ProductCodeStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ProductCodeEnding", _ProductCodeEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "IteminAlternativeList", _IteminAlternativeList, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return (Severity, Infobar);
            }
        }
    }
}
