//PROJECT NAME: Logistics
//CLASS NAME: ValidateRmaLineStatus.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.Functions;

namespace CSI.Logistics.Customer
{
	public class ValidateRmaLineStatus : IValidateRmaLineStatus
	{
		readonly IApplicationDB appDB;

		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgApp iMsgApp;

		public ValidateRmaLineStatus(IApplicationDB appDB,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			IMsgApp iMsgApp)
		{
			this.appDB = appDB;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iMsgApp = iMsgApp;
		}

		public (int? ReturnCode, string Infobar) ValidateRmaLineStatusSp(string RmaNum, int? RmaLine, string Infobar)
		{
			int? Severity = null;
			RmaItemStatusType _RmaItemStat = DBNull.Value;
			Severity = 0;

			#region CRUD LoadToVariable
			var rmaitemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_RmaItemStat,"stat"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "rmaitem",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("rma_num = {1} AND rma_line = {0}", RmaLine, RmaNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			this.appDB.Load(rmaitemLoadRequest);
			#endregion  LoadToVariable

			if (sQLUtil.SQLEqual(stringUtil.CharIndex(_RmaItemStat, "OF"), 0) == true)
			{
				//BEGIN
				Infobar = null;

				#region CRUD ExecuteMethodCall

				var MsgApp = this.iMsgApp.MsgAppSp(Infobar: Infobar
					, BaseMsg: "E=MustCompareList"
					, Parm1: "@coitem.stat"
					, Parm2: "@:CoitemStatus:O:F");

				Severity = MsgApp.ReturnCode;
				Infobar = MsgApp.Infobar;
				#endregion ExecuteMethodCall

				//END
			}
			return (Severity, Infobar);
		}
	}
}
