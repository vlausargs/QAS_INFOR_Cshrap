using CSI.CRUD.Reporting;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Material;
using CSI.MG.MGCore;
using System;

namespace CSI.App.Reporting.Rpt_ShipmentProFormaInvoice
{
    public class ProfileShipmentProFormaInvoice : IProfileShipmentProFormaInvoice
    {
        private readonly IStringUtil _stringUtil;
        private readonly ILowInt _lowInt;
        private readonly IHighInt _highInt;
        private readonly ILowCharacter _lowCharacter;
        private readonly IHighCharacter _highCharacter;
        private readonly IExpandKyByType _expandKyByType;
        private readonly IApplyDateOffset _applyDateOffset;
        private readonly IProfileShipmentProFormaInvoiceCRUD _profileShipmentProFormaInvoiceCRUD;

        public ProfileShipmentProFormaInvoice(IStringUtil stringUtil,
            ILowInt lowInt,
            IHighInt highInt,
            ILowCharacter lowCharacter,
            IHighCharacter highCharacter,
            IExpandKyByType expandKyByType,
            IApplyDateOffset applyDateOffset,
            IProfileShipmentProFormaInvoiceCRUD profileShipmentProFormaInvoiceCRUD)
        {
            _stringUtil = stringUtil;
            _lowInt = lowInt;
            _highInt = highInt;
            _lowCharacter = lowCharacter;
            _highCharacter = highCharacter;
            _expandKyByType = expandKyByType;
            _applyDateOffset = applyDateOffset;
            _profileShipmentProFormaInvoiceCRUD = profileShipmentProFormaInvoiceCRUD;
        }

        public (ICollectionLoadResponse Data,
            int? ReturnCode) ProfileShipmentProFormaInvoiceSp(decimal? shipmentStarting = null,
                decimal? shipmentEnding = null,
                string customerStarting = null,
                string customerEnding = null,
                int? shipToStarting = null,
                int? shipToEnding = null,
                DateTime? pickupDateStarting = null,
                DateTime? pickupDateEnding = null)
        {
            var lowIntValue = _lowInt.LowIntFn();
            var highIntValue = _highInt.HighIntFn();

            shipmentStarting = _stringUtil.IsNull(shipmentStarting, lowIntValue);
            shipmentEnding = _stringUtil.IsNull(shipmentEnding, highIntValue);

            string custNumTypeVaule = "CustNumType";
            var lowCharacter = _lowCharacter.LowCharacterFn();
            var highCharacter = _highCharacter.HighCharacterFn();
            var expandKyByType1 = _expandKyByType.ExpandKyByTypeFn(custNumTypeVaule, customerStarting);
            var expandKyByType2 = _expandKyByType.ExpandKyByTypeFn(custNumTypeVaule, customerEnding);
            customerStarting = _stringUtil.IsNull(expandKyByType1, lowCharacter);
            customerEnding = _stringUtil.IsNull(expandKyByType2, highCharacter);

            shipToStarting = _stringUtil.IsNull(shipToStarting, lowIntValue);
            shipToEnding = _stringUtil.IsNull(shipToEnding, highIntValue);

            var applyDateOffset1 = _applyDateOffset.ApplyDateOffsetSp(Date: pickupDateStarting, IsEndDate: 0);
            var applyDateOffset2 = _applyDateOffset.ApplyDateOffsetSp(Date: pickupDateEnding, IsEndDate: 1);
            pickupDateStarting = applyDateOffset1.Date;
            pickupDateEnding = applyDateOffset2.Date;

            int? returnCode = 0;
            var data = _profileShipmentProFormaInvoiceCRUD.GetProfiles(shipmentStarting,
                shipmentEnding,
                customerStarting,
                customerEnding,
                shipToStarting,
                shipToEnding,
                pickupDateStarting,
                pickupDateEnding);
            return (data, returnCode);
            // throw new NotImplementedException();
        }
    }

    public interface IProfileShipmentProFormaInvoice
    {   
        (ICollectionLoadResponse Data,
            int? ReturnCode)
        ProfileShipmentProFormaInvoiceSp(decimal? shipmentStarting = null,
            decimal? shipmentEnding = null,
            string customerStarting = null,
            string customerEnding = null,
            int? shipToStarting = null,
            int? shipToEnding = null,
            DateTime? pickupDateStarting = null,
            DateTime? pickupDateEnding = null);
    }
}
