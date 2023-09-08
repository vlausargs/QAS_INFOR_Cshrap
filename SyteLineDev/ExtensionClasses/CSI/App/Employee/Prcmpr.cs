//PROJECT NAME: CSIEmployee
//CLASS NAME: Prcmpr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface IPrcmpr
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) PrcmprSp(string PText,
		DateTime? PBegCheckDate,
		DateTime? PEndCheckDate,
		string PBegDept,
		string PEndDept,
		string Infobar,
		short? StartingCheckDateOffset = null,
		short? EndingCheckDateOffset = null);
	}
	
	public class Prcmpr : IPrcmpr
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Prcmpr(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) PrcmprSp(string PText,
		DateTime? PBegCheckDate,
		DateTime? PEndCheckDate,
		string PBegDept,
		string PEndDept,
		string Infobar,
		short? StartingCheckDateOffset = null,
		short? EndingCheckDateOffset = null)
		{
			LongListType _PText = PText;
			DateType _PBegCheckDate = PBegCheckDate;
			DateType _PEndCheckDate = PEndCheckDate;
			DeptType _PBegDept = PBegDept;
			DeptType _PEndDept = PEndDept;
			Infobar _Infobar = Infobar;
			DateOffsetType _StartingCheckDateOffset = StartingCheckDateOffset;
			DateOffsetType _EndingCheckDateOffset = EndingCheckDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PrcmprSp";
				
				appDB.AddCommandParameter(cmd, "PText", _PText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBegCheckDate", _PBegCheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndCheckDate", _PEndCheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBegDept", _PBegDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndDept", _PEndDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingCheckDateOffset", _StartingCheckDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingCheckDateOffset", _EndingCheckDateOffset, ParameterDirection.Input);
				
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
