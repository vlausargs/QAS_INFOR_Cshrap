//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSMultiSiteSroCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public interface ISSSFSMultiSiteSroCopy
    {
        int SSSFSMultiSiteSroCopySp(SiteType iToSite,
                                    FSSRONumType iFromSroNum,
                                    FSSRONumType iToSroNum,
                                    ListYesNoType iCloseSourceSro,
                                    ListYesNoType iDeleteSourceSro,
                                    ListYesNoType iCopyNotes,
                                    StringType iValSroType,
                                    StringType iValSlsman,
                                    StringType iValPartner,
                                    StringType iValOperCode,
                                    ref Infobar Infobar);
    }

    public class SSSFSMultiSiteSroCopy : ISSSFSMultiSiteSroCopy
    {
        readonly IApplicationDB appDB;

        public SSSFSMultiSiteSroCopy(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSMultiSiteSroCopySp(SiteType iToSite,
                                           FSSRONumType iFromSroNum,
                                           FSSRONumType iToSroNum,
                                           ListYesNoType iCloseSourceSro,
                                           ListYesNoType iDeleteSourceSro,
                                           ListYesNoType iCopyNotes,
                                           StringType iValSroType,
                                           StringType iValSlsman,
                                           StringType iValPartner,
                                           StringType iValOperCode,
                                           ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSMultiSiteSroCopySp";

                appDB.AddCommandParameter(cmd, "iToSite", iToSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iFromSroNum", iFromSroNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iToSroNum", iToSroNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iCloseSourceSro", iCloseSourceSro, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iDeleteSourceSro", iDeleteSourceSro, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iCopyNotes", iCopyNotes, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iValSroType", iValSroType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iValSlsman", iValSlsman, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iValPartner", iValPartner, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iValOperCode", iValOperCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
