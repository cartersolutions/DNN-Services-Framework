using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DNNAwesomeService.Data
{
    public class jQueryDataTableResponse
    {
        /// <summary>
        /// Request sequence number sent by DataTable,
        /// same value must be returned in response
        /// </summary>       
        public string sEcho { get; set; }

        /// <summary>
        /// Total number of records in non paged dataset
        /// </summary>
        public int iTotalRecords { get; set; }

        /// <summary>
        /// Total number of records to display
        /// </summary>
        public int iTotalDisplayRecords { get; set; }

        /// <summary>
        /// Response data
        /// </summary>
        public IEnumerable<object> aaData { get; set; }
    }
}
