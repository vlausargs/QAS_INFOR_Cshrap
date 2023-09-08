//PROJECT NAME: ChineseFinancialsExt
//CLASS NAME: CHVchTpes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.SQL;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance.Chinese;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.ChineseFinancials
{
    [IDOExtensionClass("CHVchTpes")]
    public class CHVchTpes : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CHSValidateVchTypeCodeSp(string TypeCode,
                                            ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCHSValidateVchTypeCodeExt = new CHSValidateVchTypeCodeFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iCHSValidateVchTypeCodeExt.CHSValidateVchTypeCodeSp(TypeCode,
                                                                                   ref oInfobar);

                Infobar = oInfobar;

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CHSCLM_VoucherTypeCodeListSp([Optional] string TypeCodeFilter)
		{
			var iCHSCLM_VoucherTypeCodeListExt = this.GetService<ICHSCLM_VoucherTypeCodeList>();
			
			var result = iCHSCLM_VoucherTypeCodeListExt.CHSCLM_VoucherTypeCodeListSp(TypeCodeFilter);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

    }
}