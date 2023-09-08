//PROJECT NAME: Production
//CLASS NAME: ValidatePurchasedItems.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.Functions;

namespace CSI.Production.APS
{
	public class ValidatePurchasedItems : IValidatePurchasedItems
	{
		readonly IApplicationDB appDB;

		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgApp iMsgApp;
		
		public ValidatePurchasedItems(IApplicationDB appDB,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			ISQLValueComparerUtil sQLUtil,
			IMsgApp iMsgApp)
		{
			this.appDB = appDB;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.sQLUtil = sQLUtil;
			this.iMsgApp = iMsgApp;
		}
		
		public (int? ReturnCode, string Infobar) ValidatePurchasedItemsSp (string ItemNum, string Infobar)
		{
			int? Severity = null;
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_ValidatePurchasedItemsSp") != null)
			{
				var EXTGEN = AltExtGen_ValidatePurchasedItemsSp("dbo.EXTGEN_ValidatePurchasedItemsSp",
					ItemNum,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.Infobar);
				}
			}
			
			Severity = 0;
			if (sQLUtil.SQLBool(sQLUtil.SQLNotEqual(ItemNum, "")))
			{
				//BEGIN
				if (sQLUtil.SQLBool(sQLUtil.SQLNot(existsChecker.Exists(
					tableName:"item",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("p_m_t_code = 'P' AND item.item = {0}",ItemNum)))))
				{
					//BEGIN
					Infobar = null;
					
					#region CRUD ExecuteMethodCall
					
					var MsgApp = this.iMsgApp.MsgAppSp(Infobar: Infobar
						, BaseMsg: "E=Invalid"
						, Parm1: "@item.item");
					
					Severity = MsgApp.ReturnCode;
					Infobar = MsgApp.Infobar;
					#endregion ExecuteMethodCall
					
					//END
				}
				//END
			}
			return (Severity, Infobar);
			
		}

		public (int? ReturnCode, string Infobar) AltExtGen_ValidatePurchasedItemsSp(string AltExtGenSp,
			string ItemNum,
			string Infobar)
		{
			ItemType _ItemNum = ItemNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "ItemNum", _ItemNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
