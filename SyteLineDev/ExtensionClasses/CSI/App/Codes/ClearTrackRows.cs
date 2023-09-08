//PROJECT NAME: Codes
//CLASS NAME: ClearTrackRows.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.Functions;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class ClearTrackRows : IClearTrackRows
	{
		readonly IApplicationDB appDB;
		
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		
		public ClearTrackRows(IApplicationDB appDB,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil)
		{
			this.appDB = appDB;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
		}
		
		public (
			int? ReturnCode,
			string Infobar)
		ClearTrackRowsSp (
			Guid? SessionID,
			string TrackedOperType,
			string Infobar = null)
		{
			int? Severity = 0;
			
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_ClearTrackRowsSp") != null)
			{
				var EXTGEN = AltExtGen_ClearTrackRowsSp("dbo.EXTGEN_ClearTrackRowsSp",
					SessionID,
					TrackedOperType,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.Infobar);
				}
			}
			
			/*Needs to load at least one column from the table: TrackRows for delete, Loads the record based on its where and from clause, then deletes it by record.*/
			#region CRUD LoadToRecord
			var TrackRowsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"col0","1"},
				},
				tableName:"TrackRows", 
                loadForChange: true, 
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("[SessionID] = {1} AND [TrackedOperType] = {0}",TrackedOperType,SessionID),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var TrackRowsLoadResponse = this.appDB.Load(TrackRowsLoadRequest);
			#endregion  LoadToRecord
			
			#region CRUD DeleteByRecord
			var TrackRowsDeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "TrackRows",
				items: TrackRowsLoadResponse.Items);
			this.appDB.Delete(TrackRowsDeleteRequest);
			#endregion DeleteByRecord
			
			if (sQLUtil.SQLNotEqual(this.scalarFunction.Execute<int>("@@ERROR"), 0) == true)
			{
				Infobar = "Deleting data from Trackrows failed";
			}
			
			return (Severity, Infobar);
		}

		public (int? ReturnCode,
			string Infobar)
		AltExtGen_ClearTrackRowsSp(
			string AltExtGenSp,
			Guid? SessionID,
			string TrackedOperType,
			string Infobar = null)
		{
			RowPointerType _SessionID = SessionID;
			EventVariableValueType _TrackedOperType = TrackedOperType;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrackedOperType", _TrackedOperType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);

				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
