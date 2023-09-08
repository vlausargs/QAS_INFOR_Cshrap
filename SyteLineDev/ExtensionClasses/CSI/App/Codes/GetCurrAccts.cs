//PROJECT NAME: CSICodes
//CLASS NAME: GetCurrAccts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
    public interface IGetCurrAccts
    {
        int GetCurrAcctsSp(ref AcctType UngainAcct,
                           ref UnitCode1Type UngainUnit1,
                           ref UnitCode2Type UngainUnit2,
                           ref UnitCode3Type UngainUnit3,
                           ref UnitCode4Type UngainUnit4,
                           ref DescriptionType UngainDesc,
                           ref AcctType UnlossAcct,
                           ref UnitCode1Type UnlossUnit1,
                           ref UnitCode2Type UnlossUnit2,
                           ref UnitCode3Type UnlossUnit3,
                           ref UnitCode4Type UnlossUnit4,
                           ref DescriptionType UnlossDesc,
                           ref AcctType AroffAcct,
                           ref UnitCode1Type AroffUnit1,
                           ref UnitCode2Type AroffUnit2,
                           ref UnitCode3Type AroffUnit3,
                           ref UnitCode4Type AroffUnit4,
                           ref DescriptionType AroffDesc,
                           ref AcctType ApoffAcct,
                           ref UnitCode1Type ApoffUnit1,
                           ref UnitCode2Type ApoffUnit2,
                           ref UnitCode3Type ApoffUnit3,
                           ref UnitCode4Type ApoffUnit4,
                           ref DescriptionType ApoffDesc,
                           ref AcctType VchoffAcct,
                           ref UnitCode1Type VchoffUnit1,
                           ref UnitCode2Type VchoffUnit2,
                           ref UnitCode3Type VchoffUnit3,
                           ref UnitCode4Type VchoffUnit4,
                           ref DescriptionType VchoffDesc,
                           ref AcctType GainAcct,
                           ref UnitCode1Type GainUnit1,
                           ref UnitCode2Type GainUnit2,
                           ref UnitCode3Type GainUnit3,
                           ref UnitCode4Type GainUnit4,
                           ref DescriptionType GainDesc,
                           ref AcctType LossAcct,
                           ref UnitCode1Type LossUnit1,
                           ref UnitCode2Type LossUnit2,
                           ref UnitCode3Type LossUnit3,
                           ref UnitCode4Type LossUnit4,
                           ref DescriptionType LossDesc,
                           ref AcctType NonApAcct,
                           ref UnitCode1Type NonApUnit1,
                           ref UnitCode2Type NonApUnit2,
                           ref UnitCode3Type NonApUnit3,
                           ref UnitCode4Type NonApUnit4,
                           ref DescriptionType NonApDesc,
                           ref AcctType NonArAcct,
                           ref UnitCode1Type NonArUnit1,
                           ref UnitCode2Type NonArUnit2,
                           ref UnitCode3Type NonArUnit3,
                           ref UnitCode4Type NonArUnit4,
                           ref DescriptionType NonArDesc);
    }

    public class GetCurrAccts : IGetCurrAccts
    {
        readonly IApplicationDB appDB;

        public GetCurrAccts(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetCurrAcctsSp(ref AcctType UngainAcct,
                                  ref UnitCode1Type UngainUnit1,
                                  ref UnitCode2Type UngainUnit2,
                                  ref UnitCode3Type UngainUnit3,
                                  ref UnitCode4Type UngainUnit4,
                                  ref DescriptionType UngainDesc,
                                  ref AcctType UnlossAcct,
                                  ref UnitCode1Type UnlossUnit1,
                                  ref UnitCode2Type UnlossUnit2,
                                  ref UnitCode3Type UnlossUnit3,
                                  ref UnitCode4Type UnlossUnit4,
                                  ref DescriptionType UnlossDesc,
                                  ref AcctType AroffAcct,
                                  ref UnitCode1Type AroffUnit1,
                                  ref UnitCode2Type AroffUnit2,
                                  ref UnitCode3Type AroffUnit3,
                                  ref UnitCode4Type AroffUnit4,
                                  ref DescriptionType AroffDesc,
                                  ref AcctType ApoffAcct,
                                  ref UnitCode1Type ApoffUnit1,
                                  ref UnitCode2Type ApoffUnit2,
                                  ref UnitCode3Type ApoffUnit3,
                                  ref UnitCode4Type ApoffUnit4,
                                  ref DescriptionType ApoffDesc,
                                  ref AcctType VchoffAcct,
                                  ref UnitCode1Type VchoffUnit1,
                                  ref UnitCode2Type VchoffUnit2,
                                  ref UnitCode3Type VchoffUnit3,
                                  ref UnitCode4Type VchoffUnit4,
                                  ref DescriptionType VchoffDesc,
                                  ref AcctType GainAcct,
                                  ref UnitCode1Type GainUnit1,
                                  ref UnitCode2Type GainUnit2,
                                  ref UnitCode3Type GainUnit3,
                                  ref UnitCode4Type GainUnit4,
                                  ref DescriptionType GainDesc,
                                  ref AcctType LossAcct,
                                  ref UnitCode1Type LossUnit1,
                                  ref UnitCode2Type LossUnit2,
                                  ref UnitCode3Type LossUnit3,
                                  ref UnitCode4Type LossUnit4,
                                  ref DescriptionType LossDesc,
                                  ref AcctType NonApAcct,
                                  ref UnitCode1Type NonApUnit1,
                                  ref UnitCode2Type NonApUnit2,
                                  ref UnitCode3Type NonApUnit3,
                                  ref UnitCode4Type NonApUnit4,
                                  ref DescriptionType NonApDesc,
                                  ref AcctType NonArAcct,
                                  ref UnitCode1Type NonArUnit1,
                                  ref UnitCode2Type NonArUnit2,
                                  ref UnitCode3Type NonArUnit3,
                                  ref UnitCode4Type NonArUnit4,
                                  ref DescriptionType NonArDesc)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetCurrAcctsSp";

                appDB.AddCommandParameter(cmd, "UngainAcct", UngainAcct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UngainUnit1", UngainUnit1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UngainUnit2", UngainUnit2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UngainUnit3", UngainUnit3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UngainUnit4", UngainUnit4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UngainDesc", UngainDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UnlossAcct", UnlossAcct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UnlossUnit1", UnlossUnit1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UnlossUnit2", UnlossUnit2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UnlossUnit3", UnlossUnit3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UnlossUnit4", UnlossUnit4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UnlossDesc", UnlossDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AroffAcct", AroffAcct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AroffUnit1", AroffUnit1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AroffUnit2", AroffUnit2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AroffUnit3", AroffUnit3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AroffUnit4", AroffUnit4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AroffDesc", AroffDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ApoffAcct", ApoffAcct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ApoffUnit1", ApoffUnit1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ApoffUnit2", ApoffUnit2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ApoffUnit3", ApoffUnit3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ApoffUnit4", ApoffUnit4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ApoffDesc", ApoffDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "VchoffAcct", VchoffAcct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "VchoffUnit1", VchoffUnit1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "VchoffUnit2", VchoffUnit2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "VchoffUnit3", VchoffUnit3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "VchoffUnit4", VchoffUnit4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "VchoffDesc", VchoffDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "GainAcct", GainAcct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "GainUnit1", GainUnit1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "GainUnit2", GainUnit2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "GainUnit3", GainUnit3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "GainUnit4", GainUnit4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "GainDesc", GainDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LossAcct", LossAcct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LossUnit1", LossUnit1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LossUnit2", LossUnit2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LossUnit3", LossUnit3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LossUnit4", LossUnit4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LossDesc", LossDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "NonApAcct", NonApAcct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "NonApUnit1", NonApUnit1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "NonApUnit2", NonApUnit2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "NonApUnit3", NonApUnit3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "NonApUnit4", NonApUnit4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "NonApDesc", NonApDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "NonArAcct", NonArAcct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "NonArUnit1", NonArUnit1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "NonArUnit2", NonArUnit2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "NonArUnit3", NonArUnit3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "NonArUnit4", NonArUnit4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "NonArDesc", NonArDesc, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
