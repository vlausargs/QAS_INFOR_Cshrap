//PROJECT NAME: MG.MGCore
//CLASS NAME: RemoteMethodForReplicationTargets.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class RemoteMethodForReplicationTargets : IRemoteMethodForReplicationTargets
    {
        IApplicationDB appDB;
        IBunchedLoadCollection bunchedLoadCollection;
        IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;

        public RemoteMethodForReplicationTargets(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) RemoteMethodForReplicationTargetsSp(string IdoName,
        string MethodName,
        string Infobar,
        string Parm1Value = "",
        string Parm2Value = "",
        string Parm3Value = "",
        string Parm4Value = "",
        string Parm5Value = "",
        string Parm6Value = "",
        string Parm7Value = "",
        string Parm8Value = "",
        string Parm9Value = "",
        string Parm10Value = "",
        string Parm11Value = "",
        string Parm12Value = "",
        string Parm13Value = "",
        string Parm14Value = "",
        string Parm15Value = "",
        string Parm16Value = "",
        string Parm17Value = "",
        string Parm18Value = "",
        string Parm19Value = "",
        string Parm20Value = "",
        string Parm21Value = "",
        string Parm22Value = "",
        string Parm23Value = "",
        string Parm24Value = "",
        string Parm25Value = "",
        string Parm26Value = "",
        string Parm27Value = "",
        string Parm28Value = "",
        string Parm29Value = "",
        string Parm30Value = "",
        string Parm31Value = "",
        string Parm32Value = "",
        string Parm33Value = "",
        string Parm34Value = "",
        string Parm35Value = "",
        string Parm36Value = "",
        string Parm37Value = "",
        string Parm38Value = "",
        string Parm39Value = "",
        string Parm40Value = "",
        string Parm41Value = "",
        string Parm42Value = "",
        string Parm43Value = "",
        string Parm44Value = "",
        string Parm45Value = "",
        string Parm46Value = "",
        string Parm47Value = "",
        string Parm48Value = "",
        string Parm49Value = "",
        string Parm50Value = "",
        string Parm51Value = "",
        string Parm52Value = "",
        string Parm53Value = "",
        string Parm54Value = "",
        string Parm55Value = "",
        string Parm56Value = "",
        string Parm57Value = "",
        string Parm58Value = "",
        string Parm59Value = "",
        string Parm60Value = "",
        Guid RefRowPointer = default(Guid))
        {
            StringType _IdoName = IdoName;
            StringType _MethodName = MethodName;
            InfobarType _Infobar = Infobar;
            VeryLongListType _Parm1Value = Parm1Value;
            VeryLongListType _Parm2Value = Parm2Value;
            VeryLongListType _Parm3Value = Parm3Value;
            VeryLongListType _Parm4Value = Parm4Value;
            VeryLongListType _Parm5Value = Parm5Value;
            VeryLongListType _Parm6Value = Parm6Value;
            VeryLongListType _Parm7Value = Parm7Value;
            VeryLongListType _Parm8Value = Parm8Value;
            VeryLongListType _Parm9Value = Parm9Value;
            VeryLongListType _Parm10Value = Parm10Value;
            VeryLongListType _Parm11Value = Parm11Value;
            VeryLongListType _Parm12Value = Parm12Value;
            VeryLongListType _Parm13Value = Parm13Value;
            VeryLongListType _Parm14Value = Parm14Value;
            VeryLongListType _Parm15Value = Parm15Value;
            VeryLongListType _Parm16Value = Parm16Value;
            VeryLongListType _Parm17Value = Parm17Value;
            VeryLongListType _Parm18Value = Parm18Value;
            VeryLongListType _Parm19Value = Parm19Value;
            VeryLongListType _Parm20Value = Parm20Value;
            VeryLongListType _Parm21Value = Parm21Value;
            VeryLongListType _Parm22Value = Parm22Value;
            VeryLongListType _Parm23Value = Parm23Value;
            VeryLongListType _Parm24Value = Parm24Value;
            VeryLongListType _Parm25Value = Parm25Value;
            VeryLongListType _Parm26Value = Parm26Value;
            VeryLongListType _Parm27Value = Parm27Value;
            VeryLongListType _Parm28Value = Parm28Value;
            VeryLongListType _Parm29Value = Parm29Value;
            VeryLongListType _Parm30Value = Parm30Value;
            VeryLongListType _Parm31Value = Parm31Value;
            VeryLongListType _Parm32Value = Parm32Value;
            VeryLongListType _Parm33Value = Parm33Value;
            VeryLongListType _Parm34Value = Parm34Value;
            VeryLongListType _Parm35Value = Parm35Value;
            VeryLongListType _Parm36Value = Parm36Value;
            VeryLongListType _Parm37Value = Parm37Value;
            VeryLongListType _Parm38Value = Parm38Value;
            VeryLongListType _Parm39Value = Parm39Value;
            VeryLongListType _Parm40Value = Parm40Value;
            VeryLongListType _Parm41Value = Parm41Value;
            VeryLongListType _Parm42Value = Parm42Value;
            VeryLongListType _Parm43Value = Parm43Value;
            VeryLongListType _Parm44Value = Parm44Value;
            VeryLongListType _Parm45Value = Parm45Value;
            VeryLongListType _Parm46Value = Parm46Value;
            VeryLongListType _Parm47Value = Parm47Value;
            VeryLongListType _Parm48Value = Parm48Value;
            VeryLongListType _Parm49Value = Parm49Value;
            VeryLongListType _Parm50Value = Parm50Value;
            VeryLongListType _Parm51Value = Parm51Value;
            VeryLongListType _Parm52Value = Parm52Value;
            VeryLongListType _Parm53Value = Parm53Value;
            VeryLongListType _Parm54Value = Parm54Value;
            VeryLongListType _Parm55Value = Parm55Value;
            VeryLongListType _Parm56Value = Parm56Value;
            VeryLongListType _Parm57Value = Parm57Value;
            VeryLongListType _Parm58Value = Parm58Value;
            VeryLongListType _Parm59Value = Parm59Value;
            VeryLongListType _Parm60Value = Parm60Value;
            RowPointerType _RefRowPointer = RefRowPointer;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RemoteMethodForReplicationTargetsSp";

                appDB.AddCommandParameter(cmd, "IdoName", _IdoName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "MethodName", _MethodName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Parm1Value", _Parm1Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm2Value", _Parm2Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm3Value", _Parm3Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm4Value", _Parm4Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm5Value", _Parm5Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm6Value", _Parm6Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm7Value", _Parm7Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm8Value", _Parm8Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm9Value", _Parm9Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm10Value", _Parm10Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm11Value", _Parm11Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm12Value", _Parm12Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm13Value", _Parm13Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm14Value", _Parm14Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm15Value", _Parm15Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm16Value", _Parm16Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm17Value", _Parm17Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm18Value", _Parm18Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm19Value", _Parm19Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm20Value", _Parm20Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm21Value", _Parm21Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm22Value", _Parm22Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm23Value", _Parm23Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm24Value", _Parm24Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm25Value", _Parm25Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm26Value", _Parm26Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm27Value", _Parm27Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm28Value", _Parm28Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm29Value", _Parm29Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm30Value", _Parm30Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm31Value", _Parm31Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm32Value", _Parm32Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm33Value", _Parm33Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm34Value", _Parm34Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm35Value", _Parm35Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm36Value", _Parm36Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm37Value", _Parm37Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm38Value", _Parm38Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm39Value", _Parm39Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm40Value", _Parm40Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm41Value", _Parm41Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm42Value", _Parm42Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm43Value", _Parm43Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm44Value", _Parm44Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm45Value", _Parm45Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm46Value", _Parm46Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm47Value", _Parm47Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm48Value", _Parm48Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm49Value", _Parm49Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm50Value", _Parm50Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm51Value", _Parm51Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm52Value", _Parm52Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm53Value", _Parm53Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm54Value", _Parm54Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm55Value", _Parm55Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm56Value", _Parm56Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm57Value", _Parm57Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm58Value", _Parm58Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm59Value", _Parm59Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Parm60Value", _Parm60Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefRowPointer", _RefRowPointer, ParameterDirection.Input);

                IntType returnVal = 0;
                IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
                dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                Infobar = _Infobar;

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
            }
        }
    }
}
