//PROJECT NAME: Finance
//CLASS NAME: ApiSernumvi.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AP
{
	public class ApiSernumvi : IApiSernumvi
	{
		readonly IApplicationDB appDB;
		
		public ApiSernumvi(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? PReturnCode,
			string Infobatty) ApiSernumviSp(
			string PType,
			string PWhseType,
			string PWhse,
			string PItem,
			string PLoc,
			string PLot = null,
			string PTrnNum = null,
			int? PTrnLine = null,
			string PStat = null,
			decimal? PRsvdNum = null,
			string PSerNum = null,
			string PRefType = null,
			string PRefNum = null,
			int? PRefLine = null,
			int? PRefRelease = null,
			string PDoNum = null,
			int? PDoLine = null,
			int? PReturnCode = null,
			string Infobatty = null,
			string PImportDocId = null)
		{
			StringType _PType = PType;
			StringType _PWhseType = PWhseType;
			WhseType _PWhse = PWhse;
			ItemType _PItem = PItem;
			LocType _PLoc = PLoc;
			LotType _PLot = PLot;
			TrnNumType _PTrnNum = PTrnNum;
			TrnLineType _PTrnLine = PTrnLine;
			StringType _PStat = PStat;
			RsvdNumType _PRsvdNum = PRsvdNum;
			SerNumType _PSerNum = PSerNum;
			RefTypeOType _PRefType = PRefType;
			CoNumType _PRefNum = PRefNum;
			CoLineType _PRefLine = PRefLine;
			CoReleaseType _PRefRelease = PRefRelease;
			DoNumType _PDoNum = PDoNum;
			DoLineType _PDoLine = PDoLine;
			ListYesNoType _PReturnCode = PReturnCode;
			InfobarType _Infobatty = Infobatty;
			ImportDocIdType _PImportDocId = PImportDocId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApiSernumviSp";
				
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhseType", _PWhseType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLoc", _PLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLot", _PLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnNum", _PTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnLine", _PTrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStat", _PStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRsvdNum", _PRsvdNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSerNum", _PSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefType", _PRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefNum", _PRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefLine", _PRefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefRelease", _PRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDoNum", _PDoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDoLine", _PDoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReturnCode", _PReturnCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobatty", _Infobatty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PImportDocId", _PImportDocId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PReturnCode = _PReturnCode;
				Infobatty = _Infobatty;
				
				return (Severity, PReturnCode, Infobatty);
			}
		}
	}
}
