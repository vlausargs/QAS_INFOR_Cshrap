//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ReplDocumentExt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class CLM_ReplDocumentExt : ICLM_ReplDocumentExt
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ReplDocumentExt(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ReplDocumentExtSp(string Item,
		string Ref_Type,
		string Ref_Num,
		int? Ref_Line_suf,
		int? Ref_Release,
		string DocumentName,
		string BODTagName)
		{
			ItemType _Item = Item;
			RefTypeIJKOPRSTWType _Ref_Type = Ref_Type;
			EmpJobCoPoRmaProjPsTrnNumType _Ref_Num = Ref_Num;
			CoLineSuffixPoLineProjTaskRmaTrnLineType _Ref_Line_suf = Ref_Line_suf;
			CoReleaseOperNumPoReleaseType _Ref_Release = Ref_Release;
			MarkupDocumentNameType _DocumentName = DocumentName;
			MarkupElementTagNameType _BODTagName = BODTagName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_ReplDocumentExtSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Ref_Type", _Ref_Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Ref_Num", _Ref_Num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Ref_Line_suf", _Ref_Line_suf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Ref_Release", _Ref_Release, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentName", _DocumentName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BODTagName", _BODTagName, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
