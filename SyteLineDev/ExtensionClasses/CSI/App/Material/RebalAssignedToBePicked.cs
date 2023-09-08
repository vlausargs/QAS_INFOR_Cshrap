//PROJECT NAME: Material
//CLASS NAME: RebalAssignedToBePicked.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Data.SQL;

namespace CSI.Material
{
	public interface IRebalAssignedToBePicked
	{
		(int? ReturnCode,string Infobar) RebalAssignedToBePickedSp(string Infobar);
	}
	public class RebalAssignedToBePicked : IRebalAssignedToBePicked
	{
		readonly IApplicationDB appDB;

		readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;

		public RebalAssignedToBePicked(IApplicationDB appDB,
			ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil)
		{
			this.appDB = appDB;
			this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
		}

		public (
			int? ReturnCode,
			string Infobar)
		RebalAssignedToBePickedSp(
			string Infobar)
		{

			int? Severity = 0;
			int numOfRowsItemLocAffected = 0;
			int numOfRowsLotLocAffected = 0;
			int numOfRowsSerialAffected = 0;

			#region ALTGEN

			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			if (existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory?.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory?.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('RebalAssignedToBePickedSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"))
			)
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");

				#region CRUD LoadToRecord
				var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"SpName","CAST (NULL AS NVARCHAR)"},
						{"u0","[om].[ModuleName]"},
					},
					loadForChange: false,
					lockingType: LockingType.None,
					tableName: "optional_module",
					fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('RebalAssignedToBePickedSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("RebalAssignedToBePickedSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};

				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
					items: optional_module1LoadResponse.Items);

				this.appDB.Insert(optional_module1InsertRequest);
				#endregion InsertByRecords

				while (existsChecker.Exists(tableName: "#tv_ALTGEN",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause(""))
				)
				{

					#region CRUD LoadToVariable
					var tv_ALTGEN1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
						{
							{_ALTGEN_SpName,"[SpName]"},
						},
						loadForChange: false,
						lockingType: LockingType.None,
						maximumRows: 1,
						tableName: "#tv_ALTGEN",
						fromClause: collectionLoadRequestFactory.Clause(""),
						whereClause: collectionLoadRequestFactory.Clause(""),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
					if (tv_ALTGEN1LoadResponse.Items.Count > 0)
					{
						ALTGEN_SpName = _ALTGEN_SpName;
					}
					#endregion  LoadToVariable

					var ALTGEN = AltExtGen_RebalAssignedToBePickedSp(ALTGEN_SpName,
						Infobar);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, Infobar);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					#region CRUD LoadToRecord
					var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
						{
							{"[SpName]","[SpName]"},
						},
						loadForChange: true,
						lockingType: LockingType.None,
						tableName: "#tv_ALTGEN",
						fromClause: collectionLoadRequestFactory.Clause(""),
						whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}", ALTGEN_SpName),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					var tv_ALTGEN2LoadResponse = this.appDB.Load(tv_ALTGEN2LoadRequest);
					#endregion  LoadToRecord

					#region CRUD DeleteByRecord
					var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
						items: tv_ALTGEN2LoadResponse.Items);
					this.appDB.Delete(tv_ALTGEN2DeleteRequest);
					#endregion DeleteByRecord

					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_RebalAssignedToBePickedSp") != null)
			{
				var EXTGEN = AltExtGen_RebalAssignedToBePickedSp("dbo.EXTGEN_RebalAssignedToBePickedSp",
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.Infobar);
				}
			}
			#endregion ALTGEN

			#region CRUD LoadArbitrary
			var itemlocLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"assigned_to_be_picked_qty","I.assigned_to_be_picked_qty"},
					{"atbp","Summary.atbp"},
					{"item","I.item"},
					{"whse","I.whse"},
					{"loc","I.loc"},
				},
				selectStatement: collectionLoadRequestFactory.Clause(BuildItemLocUpdateQuery()));

			var itemlocLoadResponse = this.appDB.Load(itemlocLoadRequest);
			#endregion  LoadArbitrary

			#region CRUD UpdateByRecord

			if (itemlocLoadResponse != null && itemlocLoadResponse.Items?.Count != 0)
			{
				foreach (var itemlocItem in itemlocLoadResponse?.Items)
				{
					itemlocItem.SetValue<int?>("assigned_to_be_picked_qty", stringUtil.IsNull(
						itemlocItem.GetDeletedValue<int?>("atbp"),
						0));
				};

				var itemlocRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "itemloc",
				items: itemlocLoadResponse.Items);

				numOfRowsItemLocAffected = itemlocLoadResponse.Items.Count;

				this.appDB.Update(itemlocRequestUpdate);
			}
			
			#endregion UpdateByRecord

			#region CRUD LoadArbitrary
			var Lot_locLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"assigned_to_be_picked_qty","I.assigned_to_be_picked_qty"},
					{"atbp","Summary.atbp"},
					{"item","I.item"},
					{"whse","I.whse"},
					{"loc","I.loc"},
					{"lot","I.lot"},
				},
				selectStatement: collectionLoadRequestFactory.Clause(BuildLotLocUpdateQuery()));

			var Lot_locLoadResponse = this.appDB.Load(Lot_locLoadRequest);
			#endregion  LoadArbitrary

			#region CRUD UpdateByRecord
			if (Lot_locLoadResponse != null && Lot_locLoadResponse.Items?.Count != 0)
			{

				foreach (var Lot_locItem in Lot_locLoadResponse.Items)
				{
					Lot_locItem.SetValue<int?>("assigned_to_be_picked_qty", stringUtil.IsNull(
						Lot_locItem.GetDeletedValue<int?>("atbp"),
						0));
				};

				var Lot_locRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "Lot_loc",
					items: Lot_locLoadResponse.Items);

				this.appDB.Update(Lot_locRequestUpdate);
				numOfRowsLotLocAffected = Lot_locLoadResponse.Items.Count;
			}
			#endregion UpdateByRecord

			#region CRUD LoadArbitrary
			var SerialLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"Assigned_To_be_Picked","I.Assigned_To_be_Picked"},
					{"picked","Summary.picked"},
					{"item","I.item"},
					{"ser_num","I.ser_num"},
				},
				selectStatement: collectionLoadRequestFactory.Clause(BuildSerialUpdateQuery()));

			var SerialLoadResponse = this.appDB.Load(SerialLoadRequest);
			#endregion  LoadArbitrary

			#region CRUD UpdateByRecord
			if (SerialLoadResponse != null && SerialLoadResponse?.Items?.Count != 0)
			{

				foreach (var SerialItem in SerialLoadResponse.Items)
				{
					SerialItem.SetValue<int?>("Assigned_To_be_Picked", stringUtil.IsNull(
						SerialItem.GetDeletedValue<int?>("picked"),
						0));
				};

				var SerialRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "Serial",
					items: SerialLoadResponse.Items);

				this.appDB.Update(SerialRequestUpdate);
				numOfRowsSerialAffected = SerialLoadResponse.Items.Count;
			}
			#endregion UpdateByRecord

			Infobar = (numOfRowsItemLocAffected + numOfRowsLotLocAffected + numOfRowsSerialAffected).ToString();
			return (Severity, Infobar);
		}

		/// <summary>
		/// This function build the SQL Statement to update itemloc table
		/// with calculated assigned-to-be-picked qty.
		/// existing assigned-to-be-picked qty overwritten only when calculated qty is
		/// different from the the existing one.
		/// </summary>
		/// <returns>SQL Statement</returns>
		public string BuildItemLocUpdateQuery()
		{
			return
				$";WITH transSource AS(  {BuildSubQuery()})" +
				@", Summary AS(
	                    SELECT item,
                               whse,
                               loc,
                               Sum(atbp) AS atbp
                        FROM   transSource
                        GROUP  BY whse,
                               item,
                               loc
                    )
                    SELECT @selectList
                    FROM   itemloc AS I
                           LEFT JOIN Summary
	                                  ON I.whse = Summary.whse 
				                     AND I.item = Summary.item
                                     AND I.loc  = Summary.loc
                    WHERE  I.assigned_to_be_picked_qty <> Isnull(Summary.atbp, 0)";


		}

		/// <summary>
		/// This function build the SQL Statement to update lotloc table
		/// with calculated assigned-to-be-picked qty.
		/// existing assigned-to-be-picked qty overwritten only when calculated qty is
		/// different from the the existing one.
		/// </summary>
		/// <returns>SQL Statement</returns>
		public string BuildLotLocUpdateQuery()
		{
			return
				$";WITH transSource AS(  {BuildSubQuery()})" +
				@", Summary AS(
	                    SELECT whse,
                               item,
                               loc,
		                       lot,
                               Sum(atbp) AS atbp
                        FROM   transSource
                        GROUP  BY whse,
                               item,
                               loc,
		                       lot
                    )
                    SELECT @selectList
                    FROM   Lot_loc I
                           LEFT JOIN Summary
	                                  ON I.whse = Summary.whse 
				                     AND I.item = Summary.item
                                     AND I.loc  = Summary.loc
				                     AND I.lot  = Summary.lot
                    WHERE  I.assigned_to_be_picked_qty <> Isnull(Summary.atbp, 0)";
		}

		/// <summary>
		/// This function build the SQL Statement to update serial table
		/// with calculated assigned-to-be-picked qty.
		/// existing assigned-to-be-picked qty overwritten only when calculated qty is
		/// different from the the existing one.
		/// </summary>
		/// <returns>SQL Statement</returns>
		public string BuildSerialUpdateQuery()
		{
			return
				@";WITH transSource AS(
	            	SELECT
					coitem.item
					,ser.ser_num
					,ser.picked ^ 1 as picked
				FROM
					pick_list pick
					join pick_list_ref ref ON ref.pick_list_id = pick.pick_list_id
					join pick_list_loc loc ON loc.pick_list_id = ref.pick_list_id
					and loc.sequence = ref.sequence
					join pick_list_serial ser  ON ser.pick_list_id = loc.pick_list_id
					AND ser.sequence = loc.sequence
					join coitem ON coitem.co_num = ref.ref_num
					and coitem.co_line = ref.ref_line_suf
					and coitem.co_release = ref.ref_release 
				 WHERE
					pick.status = N'O'     -- Open Status
					OR pick.status = N'P'  -- Picked Status
                ), 
			    Summary
					AS (SELECT item,
						ser_num,
						picked
						FROM   transSource)
					SELECT @selectList
					FROM Serial AS I
					LEFT OUTER JOIN
					Summary
					ON I.item = Summary.item
					AND I.ser_num = Summary.ser_num
					WHERE I.Assigned_To_be_Picked <> Isnull(Summary.picked, 0)
					AND I.item = summary.item";
		}

		/// <summary>
		/// Sub-query creates source for pick-pack-ship transaction
		/// which will be used for calculating  assigned-to-be-picked qty
		/// </summary>
		/// <returns>SQL Statement</returns>
		private string BuildSubQuery()
		{
			string Sql1 =
				 //  -- PICK Location 
				 @" SELECT  
          	         pick.whse 
              	    ,loc.loc as loc 
              	    ,loc.lot 
            	    ,coitem.item 
                    ,(loc.qty_to_pick - loc.qty_picked - isnull(rsvd_inv.qty_rsvd, 0)) as atbp 
                 FROM 
                    pick_list pick 
                    join pick_list_ref ref ON ref.pick_list_id = pick.pick_list_id 
                    join pick_list_loc loc ON loc.pick_list_id = ref.pick_list_id 
                         and loc.sequence = ref.sequence 
                    left join rsvd_inv ON rsvd_inv.whse = pick.whse 
                        AND rsvd_inv.loc = loc.loc 
                        AND rsvd_inv.ref_num = ref.ref_num 
                        AND rsvd_inv.ref_line = ref.ref_line_suf 
                        AND rsvd_inv.ref_release = ref.ref_release 
                    join coitem ON coitem.co_num = ref.ref_num
                        and coitem.co_line = ref.ref_line_suf 
                        and coitem.co_release = ref.ref_release 
                   WHERE 
                      pick.status = N'O'  
                   OR pick.status = N'P' ";

			String Sql2 =
			 //  -- PACK Location 
			 @" UNION ALL
				SELECT ALL
					 pick.whse
					,pick.pack_loc as loc
					,loc.lot
					,coitem.item
					,loc.qty_picked - isnull(rsvd_inv.qty_rsvd, 0) as atbp
				FROM
					pick_list pick
					join pick_list_ref ref ON ref.pick_list_id = pick.pick_list_id
					join pick_list_loc loc ON loc.pick_list_id = ref.pick_list_id
					and loc.sequence = ref.sequence
					left join rsvd_inv ON rsvd_inv.whse = pick.whse
					AND rsvd_inv.loc = pick.pack_loc
					AND rsvd_inv.ref_num = ref.ref_num
					AND rsvd_inv.ref_line = ref.ref_line_suf
					AND rsvd_inv.ref_release = ref.ref_release
					join coitem ON coitem.co_num = ref.ref_num
					and coitem.co_line = ref.ref_line_suf
					and coitem.co_release = ref.ref_release 
				WHERE
					   pick.status = N'O'  
					OR pick.status = N'P'  ";



			String Sql3 =
				//  -- SHIP Location 
				@" UNION ALL
				SELECT ALL
					 ship.whse
					,seq.loc
					,seq.lot
					,coitem.item
					,seq.qty_picked - seq.qty_shipped as atbp
				FROM
					shipment ship
					JOIN shipment_line line ON ship.shipment_id = line.shipment_id
					JOIN shipment_seq  seq  ON seq.shipment_id  = line.shipment_id
					     AND seq.shipment_line = line.shipment_line
						 AND ISNULL(seq.rsvd_num, 0) = 0
					JOIN pick_list_ref pick ON line.pick_list_id = pick.pick_list_id
					AND line.pick_list_ref_sequence = pick.sequence
					JOIN coitem ON pick.ref_num = coitem.co_num
					AND pick.ref_line_suf = coitem.co_line
					AND pick.ref_release = coitem.co_release 
				WHERE
				       ship.status = N'O' 
					OR ship.status = N'R' ";

			return Sql1 + Sql2 + Sql3;
		}
		public (int? ReturnCode,
			string Infobar)
		AltExtGen_RebalAssignedToBePickedSp(
			string AltExtGenSp,
			string Infobar)
		{
			InfobarType _Infobar = Infobar;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				Infobar = _Infobar;

				return (Severity, Infobar);
			}
		}

	}
}
