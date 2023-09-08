//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IItemCopy
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ItemCopySp(string Process,
		string FromItem,
		string ToItem,
		string FromItemLabel,
		string ToItemLabel,
		byte? CopyUDF,
		byte? CopyLoc,
		byte? CopyBOM,
		DateTime? EffectDate,
		string Infobar,
		byte? CopyUetValues = (byte)0,
		string FilterString = null);
	}
	
	public class ItemCopy : IItemCopy
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ItemCopy(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ItemCopySp(string Process,
		string FromItem,
		string ToItem,
		string FromItemLabel,
		string ToItemLabel,
		byte? CopyUDF,
		byte? CopyLoc,
		byte? CopyBOM,
		DateTime? EffectDate,
		string Infobar,
		byte? CopyUetValues = (byte)0,
		string FilterString = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				StringType _Process = Process;
				ItemType _FromItem = FromItem;
				StringType _ToItem = ToItem;
				StringType _FromItemLabel = FromItemLabel;
				StringType _ToItemLabel = ToItemLabel;
				ListYesNoType _CopyUDF = CopyUDF;
				ListYesNoType _CopyLoc = CopyLoc;
				ListYesNoType _CopyBOM = CopyBOM;
				DateType _EffectDate = EffectDate;
				InfobarType _Infobar = Infobar;
				ListYesNoType _CopyUetValues = CopyUetValues;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "ItemCopySp";
					
					appDB.AddCommandParameter(cmd, "Process", _Process, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FromItem", _FromItem, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ToItem", _ToItem, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FromItemLabel", _FromItemLabel, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ToItemLabel", _ToItemLabel, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CopyUDF", _CopyUDF, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CopyLoc", _CopyLoc, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CopyBOM", _CopyBOM, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EffectDate", _EffectDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
					appDB.AddCommandParameter(cmd, "CopyUetValues", _CopyUetValues, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;

                    dtReturn = appDB.ExecuteQuery(cmd);

                    Infobar = _Infobar;
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
