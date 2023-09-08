//PROJECT NAME: Logistics
//CLASS NAME: CheckAssignedLocations.cs

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

namespace CSI.Logistics.Customer
{
	public class CheckAssignedLocations : ICheckAssignedLocations
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgApp iMsgApp;
		readonly ICheckAssignedLocationsCRUD iCheckAssignedLocationsCRUD;

		public CheckAssignedLocations(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			ISQLValueComparerUtil sQLUtil,
			IMsgApp iMsgApp,
			ICheckAssignedLocationsCRUD iCheckAssignedLocationsCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.sQLUtil = sQLUtil;
			this.iMsgApp = iMsgApp;
			this.iCheckAssignedLocationsCRUD = iCheckAssignedLocationsCRUD;
		}

		public (
			int? ReturnCode,
			string Infobar)
		CheckAssignedLocationsSp(
			Guid? ProcessId,
			string Infobar)
		{

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			decimal? PQtyToPick = null;
			string PCoitemCoNum = null;
			int? PCoitemCoLine = null;
			int? PCoitemCoRelease = null;
			string PCoitemItem = null;
			string PCoitemLoc = null;
			if (this.iCheckAssignedLocationsCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCheckAssignedLocationsCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iCheckAssignedLocationsCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iCheckAssignedLocationsCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCheckAssignedLocationsCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iCheckAssignedLocationsCRUD.AltExtGen_CheckAssignedLocationsSp(ALTGEN_SpName,
						ProcessId,
						Infobar);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, Infobar);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCheckAssignedLocationsCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iCheckAssignedLocationsCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CheckAssignedLocationsSp") != null)
			{
				var EXTGEN = this.iCheckAssignedLocationsCRUD.AltExtGen_CheckAssignedLocationsSp("dbo.EXTGEN_CheckAssignedLocationsSp",
					ProcessId,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.Infobar);
				}
			}

			Severity = 0;
			if (this.iCheckAssignedLocationsCRUD.Tmp_Pick_List_LocForExists(ProcessId))
			{
				(PCoitemCoNum, PCoitemCoLine, PCoitemCoRelease, PCoitemItem, PCoitemLoc, PQtyToPick, rowCount) = this.iCheckAssignedLocationsCRUD.Tmp_Pick_List_Loc1Load(ProcessId, PQtyToPick, PCoitemCoNum, PCoitemCoLine, PCoitemCoRelease, PCoitemItem, PCoitemLoc);

				#region CRUD ExecuteMethodCall

				var MsgApp = this.iMsgApp.MsgAppSp(
					Infobar: Infobar,
					BaseMsg: "E=NoCompare<",
					Parm1: "@pick_list_ref.qty_to_pick",
					Parm2: "@!Zero");
				Infobar = MsgApp.Infobar;

				#endregion ExecuteMethodCall

				#region CRUD ExecuteMethodCall

				var MsgApp1 = this.iMsgApp.MsgAppSp(
					Infobar: Infobar,
					BaseMsg: "E=NoCompare4",
					Parm1: "@pick_list_ref.qty_to_pick",
					Parm2: convertToUtil.ToString(PQtyToPick),
					Parm3: "@!PickList",
					Parm4: "@coitem.co_num",
					Parm5: PCoitemCoNum,
					Parm6: "@coitem.co_line",
					Parm7: convertToUtil.ToString(PCoitemCoLine),
					Parm8: "@coitem.co_release",
					Parm9: convertToUtil.ToString(PCoitemCoRelease),
					Parm10: "@itemloc",
					Parm11: PCoitemLoc);
				Severity = MsgApp1.ReturnCode;
				Infobar = MsgApp1.Infobar;

				#endregion ExecuteMethodCall

			}
			return (Severity, Infobar);

		}

	}
}
