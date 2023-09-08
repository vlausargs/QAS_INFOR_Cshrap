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
using System.ComponentModel;
using CSI.Logistics.Customer;

namespace CSI.App.Logistics.Customer
{
	public class CustomerOrderCount : ICustomerOrderCount
	{
        private readonly ICustomerOrderCountCRUD customerOrderCountCRUD;
        public CustomerOrderCount(ICustomerOrderCountCRUD customerOrderCountCRUD)
		
		{
            this.customerOrderCountCRUD = customerOrderCountCRUD;

		}

		public (int? Severity, int? OrderCount, string Infobar) 
			GetCustomerOrderCount(string orderType,
			string filterType,
			string customer,
			int? shipTo,
			int? days,
			ref int OrderCount,
			ref string Infobar)
		{

			var result = customerOrderCountCRUD.GetCustomerOrderCount(orderType, filterType, customer, shipTo,days);
			return (result.Severity, result.OrderCount, result.Infobar);
		}
	}
}

public interface ICustomerOrderCount
	{
		(int? Severity, int? OrderCount, string Infobar) GetCustomerOrderCount(
			string OrderType,
			string FilterType,
			string Customer,
			int? ShipTo,
			int? days,
			ref int OrderCount,
			ref string Infobar);
	}

	
