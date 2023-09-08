//PROJECT NAME: ChineseFinancialsExt
//CLASS NAME: CHUsrRgts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance.Chinese;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.ChineseFinancials
{
	[IDOExtensionClass("CHUsrRgts")]
	public class CHUsrRgts : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CHSIncrementCndtItemSp(string Sym_group,
		                                  string Sym_User,
		                                  string DataType,
		                                  ref int? Cndtitem)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCHSIncrementCndtItemExt = new CHSIncrementCndtItemFactory().Create(appDb);
				
				int Severity = iCHSIncrementCndtItemExt.CHSIncrementCndtItemSp(Sym_group,
				                                                               Sym_User,
				                                                               DataType,
				                                                               ref Cndtitem);
				
				return Severity;
			}
		}
	}
}
