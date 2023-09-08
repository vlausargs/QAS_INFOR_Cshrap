//PROJECT NAME: CSIFinance
//CLASS NAME: MultiFSBGlPostS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IMultiFSBGlPostS
    {
        int MultiFSBGlPostSp3(ListYesNoType DateOpt,
                              DateType FixDate,
                              DateType NextPer,
                              ListYesNoType DelOpt,
                              StringType ExOptacCompressLevel,
                              CurrentDateType TPerStart,
                              CurrentDateType TPerEnd,
                              DateType TFirstDate,
                              DateType TLastDate,
                              FlagNyType TReadonly,
                              DateType TPostDate,
                              TokenType UserID,
                              JournalIdType CurId,
                              RowPointer PSessionID,
                              ref InfobarType Infobar,
                              DateType PostThroughDate,
                              FSBNameType FSBName);
    }

    public class MultiFSBGlPostS : IMultiFSBGlPostS
    {
        readonly IApplicationDB appDB;

        public MultiFSBGlPostS(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int MultiFSBGlPostSp3(ListYesNoType DateOpt,
                                     DateType FixDate,
                                     DateType NextPer,
                                     ListYesNoType DelOpt,
                                     StringType ExOptacCompressLevel,
                                     CurrentDateType TPerStart,
                                     CurrentDateType TPerEnd,
                                     DateType TFirstDate,
                                     DateType TLastDate,
                                     FlagNyType TReadonly,
                                     DateType TPostDate,
                                     TokenType UserID,
                                     JournalIdType CurId,
                                     RowPointer PSessionID,
                                     ref InfobarType Infobar,
                                     DateType PostThroughDate,
                                     FSBNameType FSBName)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MultiFSBGlPostSp3";

                appDB.AddCommandParameter(cmd, "DateOpt", DateOpt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FixDate", FixDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NextPer", NextPer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DelOpt", DelOpt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptacCompressLevel", ExOptacCompressLevel, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TPerStart", TPerStart, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TPerEnd", TPerEnd, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TFirstDate", TFirstDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TLastDate", TLastDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TReadonly", TReadonly, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TPostDate", TPostDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UserID", UserID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CurId", CurId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSessionID", PSessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PostThroughDate", PostThroughDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FSBName", FSBName, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}