//PROJECT NAME: CSIMaterial
//CLASS NAME: EcniMaterialValues.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IEcniMaterialValues
    {
        int EcniMaterialValuesSp(JobType InJob,
                                 SuffixType InSuffix,
                                 OperNumType InOperNum,
                                 JobmatlSequenceType InSequence,
                                 ref WcType OutWc,
                                 ref DescriptionType OutWcDesc,
                                 ref JobmatlSequenceType OutSequence,
                                 ref ItemType OutItem,
                                 ref DescriptionType OutItmDesc,
                                 ref MatlTypeType OutMatlType,
                                 ref QtyPerType OutMatlQtyConv,
                                 ref JobmatlUnitsType OutUnits,
                                 ref UMType OutUM,
                                 ref EcnBomSeqType OutBomSeq,
                                 ref ScrapFactorType OutScrapFact,
                                 ref RefTypeIJKPRTType OutRefType,
                                 ref FeatureType OutFeature,
                                 ref OptCodeType OutOptCode,
                                 ref ProbableType OutProbable,
                                 ref CostPrcType OutIncPriceConv,
                                 ref DateType OutEffectDate,
                                 ref DateType OutObsDate,
                                 ref CostPrcType OutMatlCostConv,
                                 ref CostPrcType OutLbrCostConv,
                                 ref CostPrcType OutFovhdCostConv,
                                 ref CostPrcType OutVovhdCostConv,
                                 ref CostPrcType OutOutCostConv,
                                 ref CostPrcType OutCostConv,
                                 ref JobmatlSequenceType OutAltGroup,
                                 ref JobmatlRankType OutAltGroupRank);
    }

    public class EcniMaterialValues : IEcniMaterialValues
    {
        readonly IApplicationDB appDB;

        public EcniMaterialValues(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EcniMaterialValuesSp(JobType InJob,
                                        SuffixType InSuffix,
                                        OperNumType InOperNum,
                                        JobmatlSequenceType InSequence,
                                        ref WcType OutWc,
                                        ref DescriptionType OutWcDesc,
                                        ref JobmatlSequenceType OutSequence,
                                        ref ItemType OutItem,
                                        ref DescriptionType OutItmDesc,
                                        ref MatlTypeType OutMatlType,
                                        ref QtyPerType OutMatlQtyConv,
                                        ref JobmatlUnitsType OutUnits,
                                        ref UMType OutUM,
                                        ref EcnBomSeqType OutBomSeq,
                                        ref ScrapFactorType OutScrapFact,
                                        ref RefTypeIJKPRTType OutRefType,
                                        ref FeatureType OutFeature,
                                        ref OptCodeType OutOptCode,
                                        ref ProbableType OutProbable,
                                        ref CostPrcType OutIncPriceConv,
                                        ref DateType OutEffectDate,
                                        ref DateType OutObsDate,
                                        ref CostPrcType OutMatlCostConv,
                                        ref CostPrcType OutLbrCostConv,
                                        ref CostPrcType OutFovhdCostConv,
                                        ref CostPrcType OutVovhdCostConv,
                                        ref CostPrcType OutOutCostConv,
                                        ref CostPrcType OutCostConv,
                                        ref JobmatlSequenceType OutAltGroup,
                                        ref JobmatlRankType OutAltGroupRank)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EcniMaterialValuesSp";

                appDB.AddCommandParameter(cmd, "InJob", InJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InSuffix", InSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InOperNum", InOperNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InSequence", InSequence, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OutWc", OutWc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutWcDesc", OutWcDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutSequence", OutSequence, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutItem", OutItem, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutItmDesc", OutItmDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutMatlType", OutMatlType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutMatlQtyConv", OutMatlQtyConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutUnits", OutUnits, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutUM", OutUM, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutBomSeq", OutBomSeq, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutScrapFact", OutScrapFact, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutRefType", OutRefType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutFeature", OutFeature, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutOptCode", OutOptCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutProbable", OutProbable, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutIncPriceConv", OutIncPriceConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutEffectDate", OutEffectDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutObsDate", OutObsDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutMatlCostConv", OutMatlCostConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutLbrCostConv", OutLbrCostConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutFovhdCostConv", OutFovhdCostConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutVovhdCostConv", OutVovhdCostConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutOutCostConv", OutOutCostConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutCostConv", OutCostConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutAltGroup", OutAltGroup, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutAltGroupRank", OutAltGroupRank, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
