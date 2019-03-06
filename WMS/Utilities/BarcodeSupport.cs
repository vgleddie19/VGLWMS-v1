using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Framework;

public class BarcodeSupport
{
    public static DataRow GetProductFromBarcode(String barcode)
    {

        // Search Default UOMs
        //{
        //    DataTable productsDT = DataSupport.RunDataSet("SELECT product_id[PRODUCT], ''[MATCHED_UOM], * FROM Products WHERE pc_barcode = '" + barcode + "' OR case_barcode = '" + barcode + "'").Tables[0];
        //    if (productsDT.Rows.Count > 0)
        //    {
        //        var row = productsDT.Rows[0];
        //        if (row["pc_barcode"].ToString() == barcode)
        //            row["MATCHED_UOM"] = "PCS";
        //        if (row["case_barcode"].ToString() == barcode)
        //            row["MATCHED_UOM"] = "CASES";
        //        return row;
        //    }
        //}

        // Search Other UOMs
        {
            DataTable productsDT = DataSupport.RunDataSet("SELECT product[PRODUCT], uom[MATCHED_UOM], * FROM ProductUOMs WHERE barcode = '" + barcode + "' ").Tables[0];
            if (productsDT.Rows.Count > 0)
            {
                var row = productsDT.Rows[0];
                return row;
            }
        }

        return null;
    }

}

