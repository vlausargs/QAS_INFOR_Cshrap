//PROJECT NAME: CSIProduct
//CLASS NAME: CopyBomJobChange.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface ICopyBomJobChange
    {
        int CopyBomJobChangeSp(string FromCategory,
                               ref string Job,
                               ref short? Suffix,
                               ref string PsNum,
                               ref string Item,
                               ref string ItemRev,
                               ref int? StartOper,
                               ref int? EndOper,
                               ref byte? CopyBom,
                               ref byte? CoProductMix,
                               ref string Model,
                               ref string ConfigId,
                               ref string ConfigGid,
                               ref string OrdNum,
                               ref short? OrdLine,
                               ref string OrdType,
                               ref string Infobar);
    }

    public class CopyBomJobChange : ICopyBomJobChange
    {
        readonly IApplicationDB appDB;

        public CopyBomJobChange(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CopyBomJobChangeSp(string FromCategory,
                                      ref string Job,
                                      ref short? Suffix,
                                      ref string PsNum,
                                      ref string Item,
                                      ref string ItemRev,
                                      ref int? StartOper,
                                      ref int? EndOper,
                                      ref byte? CopyBom,
                                      ref byte? CoProductMix,
                                      ref string Model,
                                      ref string ConfigId,
                                      ref string ConfigGid,
                                      ref string OrdNum,
                                      ref short? OrdLine,
                                      ref string OrdType,
                                      ref string Infobar)
        {
            StringType _FromCategory = FromCategory;
            JobType _Job = Job;
            SuffixType _Suffix = Suffix;
            PsNumType _PsNum = PsNum;
            ItemType _Item = Item;
            RevisionType _ItemRev = ItemRev;
            OperNumType _StartOper = StartOper;
            OperNumType _EndOper = EndOper;
            ListYesNoType _CopyBom = CopyBom;
            ListYesNoType _CoProductMix = CoProductMix;
            ConfigModelType _Model = Model;
            ConfigIdType _ConfigId = ConfigId;
            ConfigGIDType _ConfigGid = ConfigGid;
            CoProjTrnNumType _OrdNum = OrdNum;
            CoProjTaskTrnLineType _OrdLine = OrdLine;
            RefTypeIKOTType _OrdType = OrdType;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CopyBomJobChangeSp";

                appDB.AddCommandParameter(cmd, "FromCategory", _FromCategory, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PsNum", _PsNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemRev", _ItemRev, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "StartOper", _StartOper, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "EndOper", _EndOper, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CopyBom", _CopyBom, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoProductMix", _CoProductMix, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Model", _Model, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ConfigId", _ConfigId, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ConfigGid", _ConfigGid, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OrdNum", _OrdNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OrdLine", _OrdLine, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OrdType", _OrdType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Job = _Job;
                Suffix = _Suffix;
                PsNum = _PsNum;
                Item = _Item;
                ItemRev = _ItemRev;
                StartOper = _StartOper;
                EndOper = _EndOper;
                CopyBom = _CopyBom;
                CoProductMix = _CoProductMix;
                Model = _Model;
                ConfigId = _ConfigId;
                ConfigGid = _ConfigGid;
                OrdNum = _OrdNum;
                OrdLine = _OrdLine;
                OrdType = _OrdType;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
