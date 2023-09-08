//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroCopyUseIt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public interface ISSSFSSroCopyUseIt_ST
    {
        int? SSSFSSroCopyUseItem(string iTemplateSroNum,
                                 int? iTemplateSroLine,
                                 string iItem,
                                 byte? ChkShowAllOper,
                                 string iSerNum,
                                 string Infobar,
                                 string FilterString = null);
    }

    public class SSSFSSroCopyUseIt_ST : ISSSFSSroCopyUseIt_ST
    {
        readonly IApplicationDB appDB;

        public SSSFSSroCopyUseIt_ST(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int? SSSFSSroCopyUseItem(string iTemplateSroNum,
                                        int? iTemplateSroLine,
                                        string iItem,
                                        byte? ChkShowAllOper,
                                        string iSerNum,
                                        string Infobar,
                                        string FilterString = null)
        {
            FSSRONumType _iTemplateSroNum = iTemplateSroNum;
            FSSROLineType _iTemplateSroLine = iTemplateSroLine;
            ItemType _iItem = iItem;
            ListYesNoType _ChkShowAllOper = ChkShowAllOper;
            SerNumType _iSerNum = iSerNum;
            Infobar _Infobar = Infobar;
            LongListType _FilterString = FilterString;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSSroCopyUseItem";

                appDB.AddCommandParameter(cmd, "iTemplateSroNum", _iTemplateSroNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iTemplateSroLine", _iTemplateSroLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iItem", _iItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ChkShowAllOper", _ChkShowAllOper, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iSerNum", _iSerNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return (Severity);
            }
        }
    }
}
