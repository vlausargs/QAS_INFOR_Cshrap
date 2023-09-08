using System;
using System.Collections.Generic;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using System.Data;
using System.Text;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface ICalcFreightAmountsCRUD
    {
        decimal? GetCarrierUpchargePct(string CustNum, int CustSeq);

    }
    public class CalcFreightAmountsCRUD: ICalcFreightAmountsCRUD
    {
        ICollectionLoadRequestFactory collectionLoadRequestFactory;
        IApplicationDB appDB;


        public CalcFreightAmountsCRUD(
            ICollectionLoadRequestFactory collectionLoadRequestFactory, 
             IApplicationDB appDB)
        {
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.appDB = appDB;

        }

        public decimal? GetCarrierUpchargePct(string CustNum, int CustSeq)
        {
            CarrierUpchargePercentType _CarrierUpchargePercent = DBNull.Value;
            decimal? CarrierUpchargePercent = 0M;

            #region CRUD LoadToVariable
            var coparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_CarrierUpchargePercent,"carrier_upcharge_pct"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "custaddr",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("cust_num={0} AND cust_seq={1}", CustNum, CustSeq),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var coparmsLoadResponse = this.appDB.Load(coparmsLoadRequest);
            if (coparmsLoadResponse.Items.Count > 0)
            {
                CarrierUpchargePercent = _CarrierUpchargePercent;
            }
            #endregion  LoadToVariable

            return CarrierUpchargePercent;
        }


    }
}
