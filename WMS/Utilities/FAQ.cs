using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Framework;
using System.IO;

public class FAQ
{
    static Dictionary<String, Dictionary<String, String>> dbConnectionSettings;

    public static DataTable GetRecord(String SQL)
    {
        var dt = DataSupport.RunDataSet(SQL).Tables[0];
        return dt;
    }

    public static DataTable GetReleasedOrders(String release_id)
    {
        var dt = DataSupport.RunDataSet("SELECT order_id FROM ReleaseDetails WHERE release = '" + release_id + "'").Tables[0];

        return dt;
    }

    public static Boolean IsAlreadyDownloaded(String oms_shipment_id)
    {
        DataTable dt = DataSupport.RunDataSet("SELECT order_id FROM ReleaseOrders WHERE oms_shipment_id = '"+oms_shipment_id+"'").Tables[0];
        if (dt.Rows.Count > 0)
            return true;
        return false;
    }

    public static DataTable GetOMSOutgoing()
    {
        Utils.SetConnectionDetails();
        dbConnectionSettings = Utils.DBConnection;
        DataSupport oms_dh = new DataSupport("Initial Catalog=" + Utils.DBConnection["OMS"]["DBNAME"] + ";Data Source=" + Utils.DBConnection["OMS"]["SERVER"] + ";User Id = " + Utils.DBConnection["OMS"]["USERNAME"] + "; Password = " + Utils.DBConnection["OMS"]["PASSWORD"]);
        DataSet set = oms_dh.ExecuteDataSet(@"SELECT * FROM OutgoingShipmentRequests WHERE status = 'FOR STOCK CHECKING' AND warehouse = '" + DataSupport.GetWarehouseCode() + "' ;");
        return set.Tables[0];
    }
    
    public static DataTable GetOMSIncoming()
    {
        Utils.SetConnectionDetails();
        dbConnectionSettings = Utils.DBConnection;
        DataSupport oms_dh = new DataSupport("Initial Catalog=" + Utils.DBConnection["OMS"]["DBNAME"] + ";Data Source=" + Utils.DBConnection["OMS"]["SERVER"] + ";User Id = " + Utils.DBConnection["OMS"]["USERNAME"] + "; Password = " + Utils.DBConnection["OMS"]["PASSWORD"]);
        DataSet set = oms_dh.ExecuteDataSet(@"SELECT shipment_id[Shipment ID],Client[Client Name],authorized_shipper[Authorize Shipper],document_reference[Document Reference #],shippedvia[Shipped Via],convert(varchar, document_reference_date, 107)[Doc. Ref. Date]  FROM IncomingShipmentRequests WHERE status = 'FOR RECEIVING' AND warehouse = '" + DataSupport.GetWarehouseCode()+"' ;");
        return set.Tables[0];
    }

    public static DataTable GetOMSOutgoingDetails(String shipment_id)
    {
        Utils.SetConnectionDetails();
        dbConnectionSettings = Utils.DBConnection;
        DataSupport oms_dh = new DataSupport("Initial Catalog=" + Utils.DBConnection["OMS"]["DBNAME"] + ";Data Source=" + Utils.DBConnection["OMS"]["SERVER"] + ";User Id = " + Utils.DBConnection["OMS"]["USERNAME"] + "; Password = " + Utils.DBConnection["OMS"]["PASSWORD"]);
        DataSet set = oms_dh.ExecuteDataSet(@"SELECT Product, Uom,  expected_qty  FROM OutgoingShipmentRequestDetails WHERE out_shipment = '" + shipment_id + "'");
        return set.Tables[0];

    }

    public static DataTable GetOMSIncomingDetails(String shipment_id)
    {
        Utils.SetConnectionDetails();
        dbConnectionSettings = Utils.DBConnection;
        DataSupport oms_dh = new DataSupport("Initial Catalog=" + Utils.DBConnection["OMS"]["DBNAME"] + ";Data Source=" + Utils.DBConnection["OMS"]["SERVER"] + ";User Id = " + Utils.DBConnection["OMS"]["USERNAME"] + "; Password = " + Utils.DBConnection["OMS"]["PASSWORD"]);
        DataSet set = oms_dh.ExecuteDataSet(@"SELECT Product, description,Uom, lot_no, expiry, expected_qty  FROM IncomingShipmentRequestDetails i JOIN products p ON p.product_id = i.product WHERE shipment = '"+shipment_id+"'");
        return set.Tables[0];
    }


    public static Boolean IsPicklistForDisposal(String picklist_id)
    {
        var dt = DataSupport.RunDataSet("SELECT * FROM ForDisposals WHERE disposed_to IS NULL AND trans_id = '" + picklist_id + "'").Tables[0];
        if (dt.Rows.Count > 0)
            return true;
        return false;
    }


    public static String GetPicklistID(String order_id)
    {
        return DataSupport.RunDataSet("SELECT picklist FROM PicklistDetails WHERE order_id = '"+order_id+"'; ").Tables[0].Rows[0][0].ToString();
    }

    public static DataTable GetPickedItems(String picklist,String order_id)
    {
        DataTable dt = DataSupport.RunDataSet(@"SELECT *
                            FROM
                            (
	                            SELECT *
	                            ,
	                              (SELECT  TOP 1 order_id 
		                            FROM ForResolutions B
		                            WHERE B.trans_id = A.picklist
		                              AND B.product = A.product
		                              AND B.uom = A.uom
		                              AND B.lot_no = A.lot_no
		                              AND B.expiry = A.expiry
	                               )
	                               [exist]
	                            FROM PicklistDetails A
	                            WHERE picklist='"+picklist+@"' AND order_id = '"+order_id+@"'
                            ) T 
                            WHERE exist IS NULL

   
                               "

                                        ).Tables[0];

        return dt;

    }


    public static DataTable GetLocationsFromPhysicalCount(String physical_count_id)
    {
        DataTable dt = DataSupport.RunDataSet("SELECT DISTINCT Location FROM PhysicalCountDetailItems WHERE phcount = '" + physical_count_id + "'").Tables[0];
       
        return dt;
    }


    public static Boolean DoesPhysicalCountExist(String physical_count_id)
    {
        DataTable dt = DataSupport.RunDataSet("SELECT phcount_id FROM PhysicalCounts WHERE phcount_id=@id", "id", physical_count_id).Tables[0];
        if (dt.Rows.Count <= 0)
            return false;
        return true;
    }




    public static String GetReleaseID(String trip_id)
    {
        return DataSupport.RunDataSet("SELECT release_id FROM Releases WHERE trip= @trip", "trip", trip_id).Tables[0].Rows[0][0].ToString();
    }

    public static DataTable GetPickedOrder(String order_id)
    {
        DataTable dt = DataSupport.RunDataSet("SELECT * FROM PicklistDetails WHERE order_id = @order_id ", "order_id", order_id).Tables[0];

        return dt;
    }

    public static Boolean DoesReleasingExist(String trip_id)
    {
        DataTable dt = DataSupport.RunDataSet("SELECT * FROM Releases WHERE trip = @trip; ", "trip", trip_id).Tables[0];
        if (dt.Rows.Count > 0)
            return true;
        return false;
    }


    public static DataTable GetTripDetails(String trip_id)
    {
        return DataSupport.RunDataSet("SELECT RD.trip, RD.order_id, RD.drop_sequence FROM ReleaseTripDetails RD INNER JOIN ReleaseOrders RO ON RD.order_id = RO.order_id  WHERE trip = @trip AND RO.status='FOR RELEASING' ORDER BY drop_sequence ; ", "trip", trip_id).Tables[0];
    }

    public static DataTable GetOrdersFromPicklist(String picklist_id)
    {
        return DataSupport.RunDataSet(@"SELECT order_id FROM PicklistDetails WHERE picklist=@picklist_id
                        ", "picklist_id", picklist_id).Tables[0];
    }

    public static DataTable WhereAreReservedProductsInWarehouse(String product, String uom)
    {
        return DataSupport.RunDataSet(@"SELECT location, lot_no, expiry, (reserved_qty - to_be_picked_qty)[reserved_qty]
                        FROM LocationProductsLedger 
                        WHERE  product = @product AND uom = @uom
                        AND (reserved_qty - to_be_picked_qty) > 0
                        ORDER BY expiry 
                        ", "product", product, "uom", uom).Tables[0];
    }


    public static DataTable WhereAreProductsInWarehouse(String product, String uom)
    {
        //DataTable result = new DataTable();
        //result.Columns.Add("location", typeof(String));
        //result.Columns.Add("lot_no", typeof(String));
        //result.Columns.Add("expiry", typeof(String));
        //result.Columns.Add("available_qty", typeof(int));

        //foreach(DataRow dRow in DataSupport.RunDataSet(String.Format(@"SELECT LPL.location, LPL.lot_no, LPL.expiry, (LPL.[available_qty]*PU.qty)available_qty,PU.qty
        //                FROM [LocationProductsLedger] LPL INNER JOIN [productuoms] PU ON PU.product = LPL.product AND  PU.uom = LPL.uom
        //                WHERE LPL.product = '{0}' AND available_qty > 0", product)).Tables[0].Rows)
        //{
        //    //DataRow tblRow = result.NewRow();
        //    result.Rows.Add(dRow);
        //}

        //return DataSupport.RunDataSet(String.Format(@"SELECT LPL.location, LPL.lot_no, LPL.expiry, (LPL.[available_qty]*PU.qty)available_qty, PU.qty[uomconv]
        //                FROM [LocationProductsLedger] LPL INNER JOIN [productuoms] PU ON PU.product = LPL.product AND  PU.uom = LPL.uom
        //                WHERE LPL.product = '{0}' AND available_qty > 0", product)).Tables[0];

        return DataSupport.RunDataSet(@"SELECT location, lot_no, expiry, available_qty
                        FROM LocationProductsLedger 
                        WHERE  product = @product AND uom = @uom
                        AND available_qty >0
                        ORDER BY expiry DESC
                        ", "product", product, "uom", uom).Tables[0];

        //return DataSupport.RunDataSet(@"SELECT location, lot_no, expiry, available_qty
        //                 FROM LocationProductsLedger 
        //                 WHERE  product = @product AND uom = @uom
        //                 AND available_qty >0
        //                 ORDER BY expiry DESC
        //                 ", "product", product, "uom", uom).Tables[0];
    }

    public static int HowManyPiecesInUOM(String product, String uom, int qty)
    {
        int result = 0;
        //String sql = @"SELECT *,
        //        case_barcode
        //       ,
        //        CASE 
        //           WHEN @uom='PCS'
        //         THEN  1
        //           WHEN @uom='PIECES'
        //         THEN  1
        //           WHEN @uom = 'CASES'
        //            THEN pcs_per_case
        //           ELSE
        //            (SELECT qty FROM ProductUOMs PU WHERE PU.product = L.product_id AND PU.uom = @uom ) 
        //        END
        //         [IN_PIECES]
        //        FROM Products L
        //        WHERE product_id = @product";
        String sql = @"SELECT isnull(qty,0) [IN_PIECES]
                FROM ProductUOMs 
                WHERE product = @product AND uom = @uom";

        DataTable dt = DataSupport.RunDataSet(sql, "product", product, "uom", uom).Tables[0];
        if(dt.Rows[0]["IN_PIECES"] != DBNull.Value)
            result = int.Parse(dt.Rows[0]["IN_PIECES"].ToString()) * qty;
        return result;
    }

    public static int HowManyPiecesInWarehouseWithReserved(String product_id)
    {
        int result = 0;
        //String sql = @"SELECT *
        //                ,CASE WHEN uom='CASES'
        //                   THEN (SELECT pcs_per_case FROM Products WHERE product = product_id) * available_qty
        //                   WHEN uom='PIECES'
        //                   THEN available_qty
        //                   WHEN uom='PCS'
        //                   THEN available_qty
        //                   ELSE 
        //                   (SELECT qty FROM ProductUOMs PU WHERE PU.product = L.product AND PU.uom = L.uom ) * available_qty
        //                 END
        //                 [IN_PIECES]
        //                FROM LocationProductsLedger L
        //                WHERE product= @product
        //                AND available_qty >0 AND expiry_status IS NULL"; //AND expiry > GETDATE()";
        String sql = @"SELECT *
                        ,CASE WHEN uom='CASES' OR uom='CASE' OR uom='CS'
                           THEN (SELECT qty FROM ProductUOMs PU WHERE PU.product = L.product AND PU.uom = L.uom ) * available_qty
                           WHEN uom='PIECES' OR uom='PC' OR uom='PIECE' OR uom='PC'
                           THEN available_qty
                         END
                         [IN_PIECES]
                        FROM LocationProductsLedger L
                        WHERE product= @product
                        AND available_qty >0 AND expiry_status IS NULL"; //AND expiry > GETDATE()";
        DataTable dt = DataSupport.RunDataSet(sql, "product", product_id).Tables[0];
        foreach (DataRow row in dt.Rows)
            if(row["IN_PIECES"] != DBNull .Value)
                result += int.Parse(row["IN_PIECES"].ToString());
        
        return result;
    }

    public static int HowManyPiecesInWarehouse(String product_id)
    {
        int result = 0;
        String sql = @"SELECT *
                        ,CASE WHEN uom='CASES'
			                        THEN (SELECT pcs_per_case FROM Products WHERE product = product_id) * qty
	                          WHEN uom='PIECES'
			                        THEN qty
	                          WHEN uom='PCS'
			                        THEN qty
	                          ELSE 
			                        (SELECT qty FROM ProductUOMs PU WHERE PU.product = L.product AND PU.uom = L.uom ) * qty
                         END
                         [IN_PIECES]
                        FROM LocationProductsLedger L
                        WHERE product= @product
                        AND available_qty >0 AND expiry_status IS NULL AND expiry > GETDATE()";
        DataTable dt = DataSupport.RunDataSet(sql, "product", product_id).Tables[0];
        foreach (DataRow row in dt.Rows)
            result += int.Parse( row["IN_PIECES"].ToString());
        return result;
    }

    public static DataTable GetOrderDetails(String order_id)
    {
        return DataSupport.RunDataSet(@"SELECT ROD.*,PU.qty[uomconv] FROM ReleaseOrderDetails ROD INNER JOIN 
                                        ProductUOMs PU ON ROD.product = PU .product and ROD.uom = PU.uom  
                                        WHERE release_order = @id", "id", order_id).Tables[0]; ;
    }

    public static Boolean DoesOrderHaveStocks(String order_id)
    {
        DataTable detailsDT = DataSupport.RunDataSet("SELECT * FROM ReleaseOrderDetails WHERE release_order = @id", "id", order_id).Tables[0];
        foreach (DataRow row in detailsDT.Rows)
        {
            int pieces_in_warehouse = FAQ.HowManyPiecesInWarehouseWithReserved(row["product"].ToString());
            int pieces_in_order = FAQ.HowManyPiecesInUOM(row["product"].ToString(), row["uom"].ToString(), int.Parse(row["qty"].ToString()));
            if (pieces_in_warehouse < pieces_in_order)
                return false;
        }

        return true;
    }

    public static DataTable GetLocations()
    {
        return DataSupport.RunDataSet("SELECT * FROM Locations WHERE status = 'ACTIVE'").Tables[0];
    }

    public static DataTable GetEmployees(String SQL)
    {
        var dt = DataSupport.RunDataSet(SQL).Tables[0];
        return dt;
    }
    
    public static String GetContainerType(String container_id)
    {
        return DataSupport.RunDataSet("SELECT type FROM Containers WHERE container_id='"+container_id+"' ").Tables[0].Rows[0][0].ToString();
    }

    public static String GetContainer(String putaway_id)
    {
        var dt = DataSupport.RunDataSet("SELECT * FROM Putaways WHERE putaway_id = '" + putaway_id + "' ").Tables[0];
        if (dt.Rows.Count > 0)
            return dt.Rows[0]["container"].ToString();

        return null;
    }  
    
    public static Boolean DoesPicklistExist(String picklist_id)
    {
        var dt = DataSupport.RunDataSet("SELECT * FROM Picklists WHERE picklist_id = '" + picklist_id + "' AND STATUS != 'DECLARED COMPLETE' AND [casebreak_id] IS NULL").Tables[0];
        if (dt.Rows.Count > 0)
            return true;
        return false;

    }

    public static Boolean DoesCaseBreakExist(String casebreak_id)
    {
        var dt = DataSupport.RunDataSet("SELECT * FROM CaseBreak WHERE casebreak_id = '" + casebreak_id + "' ").Tables[0];
        if (dt.Rows.Count > 0)
            return true;
        return false;

    }

    public static DataTable GetPutawayDetails(String putaway_id)
    {
        return DataSupport.RunDataSet("SELECT * FROM PutawayDetails WHERE putaway = '" + putaway_id + "'; ").Tables[0];
    }

    public static Boolean IsNewLine(String location, String product, String uom, String lot_no, String expiry)
    {
        DataTable dt = DataSupport.RunDataSet("SELECT * FROM LocationProductsLedger WHERE location = '" + location + "' AND product='" + product + "' AND uom ='" + uom + "' AND lot_no = '" + lot_no + "' AND expiry='" + expiry + "'").Tables[0];
        if (dt.Rows.Count > 0)
            return true;

        return false;
    }
    public static Boolean isbinproductledgerexist(String location, String product, String uom, String lot, String expiry)
    {
        foreach (DataRow drow in DataSupport.RunDataSet(String.Format("SELECT * FROM binproductledger WHERE location = '{0}' AND product = '{1}' AND uom = '{2}' AND  lot_no = '{3}' AND expiry = '{4}'", location, product, uom, lot, expiry)).Tables[0].Rows)
            return true;

        return false;
    }

    public static DataTable Getbintobereplenish()
    {
        return DataSupport.RunDataSet("SELECT l.*,u.qty[uomconv] FROM binproductledger l join binproducts b on b.product = l.product and b.location = l.location and b.uom = l.uom and l.actualqty <= l.min_qty join productuoms u on u.product = l.product and u.uom = l.uom").Tables[0];
    }
    public static DataTable Whatareproductstobereplenish()
    {
        DataTable result = new DataTable();
        result.Columns.Add("binid");
        result.Columns.Add("location");
        result.Columns.Add("product");
        result.Columns.Add("uom");
        result.Columns.Add("lot");
        result.Columns.Add("expiry");
        result.Columns.Add("qty");
        result.Columns.Add("binuom");
        result.Columns.Add("locuomconv");
        result.Columns.Add("binuomconv");

        foreach (DataRow dRow in Getbintobereplenish().Rows)
        {
            foreach(KeyValuePair<String,int> kvp in stocksinwarehouse(dRow["product"].ToString(), dRow["lot_no"].ToString(), dRow["expiry"].ToString(), Convert.ToInt32(dRow["max_qty"]) - Convert.ToInt32(dRow["actualqty"])))
            {
                string[] locuom = kvp.Key.ToString().Split(new String[] { "<limit>" }, StringSplitOptions.RemoveEmptyEntries);                
                result.Rows.Add(dRow["location"],locuom[0], dRow["product"], locuom[1],dRow["lot_no"],Convert.ToDateTime(dRow["expiry"]).ToShortDateString(), kvp.Value,dRow["uom"], locuom[2],dRow["uomconv"]);
            }
        }
        return result;
    }
    public static Dictionary<String,int> stocksinwarehouse(String product, String lot, String expiry,int qty)
    {
        Dictionary<String,int> result = new Dictionary<string, int>();
        int totalqty = qty;
        foreach (DataRow dRow in DataSupport.RunDataSet(String.Format("SELECT pl.*, (available_qty * u.qty)[qty1],u.qty[uom_qty] FROM LocationProductsLedger pl join ProductUOMs u ON pl.product = u.product AND  pl.uom = u.uom WHERE pl.product = '{0}' and pl.lot_no = '{1}' and pl.expiry = '{2}' and available_qty >= 1 order by expiry asc,uom_qty asc", product, lot, expiry)).Tables[0].Rows)
        {
            if (Convert.ToInt32(dRow["uom_qty"]) == 1)
            {
                if (totalqty > Convert.ToInt32(dRow["qty1"]))
                {
                    totalqty -= Convert.ToInt32(dRow["qty1"]);
                    //System.Windows.Forms.MessageBox.Show(dRow["qty1"].ToString());
                    result.Add(String.Format("{0}<limit>{1}<limit>{2}", dRow["location"], dRow["uom"], dRow["uom_qty"]), Convert.ToInt32(dRow["qty1"]));
                }
                else
                {
                    result.Add(String.Format("{0}<limit>{1}<limit>{2}", dRow["location"], dRow["uom"], dRow["uom_qty"]), totalqty);
                    totalqty = 0;
                    break;
                }
            }
            else
            {
                if (totalqty > Convert.ToInt32(dRow["qty1"]))
                {
                    totalqty -= Convert.ToInt32(dRow["qty1"]);
                    //System.Windows.Forms.MessageBox.Show(dRow["qty1"].ToString());
                    result.Add(String.Format("{0}<limit>{1}<limit>{2}", dRow["location"], dRow["uom"], dRow["uom_qty"]), Convert.ToInt32(dRow["available_qty"]));
                }
                else
                {
                    decimal conv = Convert.ToDecimal(dRow["uom_qty"]);
                    decimal s = Convert.ToDecimal((decimal)totalqty / conv); 
                     result.Add(String.Format("{0}<limit>{1}<limit>{2}", dRow["location"], dRow["uom"], dRow["uom_qty"]), (int)Math.Ceiling(s));
                    totalqty = 0;
                    break;
                }
            }
        }


        return result;
    }
}
