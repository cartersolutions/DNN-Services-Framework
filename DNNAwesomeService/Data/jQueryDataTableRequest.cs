using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DNNAwesomeService.Data
{
    public class jQueryDataTableRequest
    {
        /// <summary>
        /// Request sequence number sent by DataTable,
        /// same value must be returned in response
        /// </summary>       
        public string sEcho { get; set; }

        /// <summary>
        /// Text used for filtering
        /// </summary>
        public string sSearch { get; set; }

        /// <summary>
        /// Number of records that should be shown in table
        /// </summary>
        public int iDisplayLength { get; set; }

        /// <summary>
        /// First record that should be shown(used for paging)
        /// </summary>
        public int iDisplayStart { get; set; }

        /// <summary>
        /// Number of columns in table
        /// </summary>
        public int iColumns { get; set; }

        /// <summary>
        /// Number of columns that are used in sorting
        /// </summary>
        public int iSortingCols { get; set; }

        /// <summary>
        /// Comma separated list of column names
        /// </summary>
        public string sColumns { get; set; }

        #region iSortCol

        /// <summary>
        /// The first sorted column index.This is used in single column sorting scenarios
        /// </summary>
        public int iSortCol_0 { get; set; }

        /// <summary>
        /// The sorted column index
        /// </summary>
        public int iSortCol_1 { get; set; }

        /// <summary>
        /// The sorted column index
        /// </summary>
        public int iSortCol_2 { get; set; }

        /// <summary>
        /// The sorted column index
        /// </summary>
        public int iSortCol_3 { get; set; }

        /// <summary>
        /// The sorted column index
        /// </summary>
        public int iSortCol_4 { get; set; }

        /// <summary>
        /// The sorted column index
        /// </summary>
        public int iSortCol_5 { get; set; }

        /// <summary>
        /// The sorted column index
        /// </summary>
        public int iSortCol_6 { get; set; }

        /// <summary>
        /// The sorted column index
        /// </summary>
        public int iSortCol_7 { get; set; }

        /// <summary>
        /// The sorted column index
        /// </summary>
        public int iSortCol_8 { get; set; }

        /// <summary>
        /// The sorted column index
        /// </summary>
        public int iSortCol_9 { get; set; }

        #endregion

        #region sSortDir

        /// <summary>
        /// The first sorted columnd direction {asc|desc}. This is used in single column sorting scenarios
        /// </summary>
        public string sSortDir_0 { get; set; }

        /// <summary>
        /// The sorted columnd direction {asc|desc}
        /// </summary>
        public string sSortDir_1 { get; set; }

        /// <summary>
        /// The sorted columnd direction {asc|desc}
        /// </summary>
        public string sSortDir_2 { get; set; }

        /// <summary>
        /// The sorted columnd direction {asc|desc}
        /// </summary>
        public string sSortDir_3 { get; set; }

        /// <summary>
        /// The sorted columnd direction {asc|desc}
        /// </summary>
        public string sSortDir_4 { get; set; }

        /// <summary>
        /// The sorted columnd direction {asc|desc}
        /// </summary>
        public string sSortDir_5 { get; set; }

        /// <summary>
        /// The sorted columnd direction {asc|desc}
        /// </summary>
        public string sSortDir_6 { get; set; }

        /// <summary>
        /// The sorted columnd direction {asc|desc}
        /// </summary>
        public string sSortDir_7 { get; set; }

        /// <summary>
        /// The sorted columnd direction {asc|desc}
        /// </summary>
        public string sSortDir_8 { get; set; }

        /// <summary>
        /// The sorted columnd direction {asc|desc}
        /// </summary>
        public string sSortDir_9 { get; set; }

        #endregion

        #region sSearch (10)

        /// <summary>
        /// sSearch defined column
        /// </summary>
        public string sSearch_0 { get; set; }

        /// <summary>
        /// sSearch defined column
        /// </summary>
        public string sSearch_1 { get; set; }

        /// <summary>
        /// sSearch defined column
        /// </summary>
        public string sSearch_2 { get; set; }

        /// <summary>
        /// sSearch defined column
        /// </summary>
        public string sSearch_3 { get; set; }

        /// <summary>
        /// sSearch defined column
        /// </summary>
        public string sSearch_4 { get; set; }

        /// <summary>
        /// sSearch defined column
        /// </summary>
        public string sSearch_5 { get; set; }

        /// <summary>
        /// sSearch defined column
        /// </summary>
        public string sSearch_6 { get; set; }

        /// <summary>
        /// sSearch defined column
        /// </summary>
        public string sSearch_7 { get; set; }

        /// <summary>
        /// sSearch defined column
        /// </summary>
        public string sSearch_8 { get; set; }

        /// <summary>
        /// sSearch defined column
        /// </summary>
        public string sSearch_9 { get; set; }

        #endregion

        #region bSearchable (10)

        /// <summary>
        /// bSearchable defined column
        /// </summary>
        public string bSearchable_0 { get; set; }

        /// <summary>
        /// bSearchable defined column
        /// </summary>
        public string bSearchable_1 { get; set; }

        /// <summary>
        /// bSearchable defined column
        /// </summary>
        public string bSearchable_2 { get; set; }

        /// <summary>
        /// bSearchable defined column
        /// </summary>
        public string bSearchable_3 { get; set; }

        /// <summary>
        /// bSearchable defined column
        /// </summary>
        public string bSearchable_4 { get; set; }

        /// <summary>
        /// bSearchable defined column
        /// </summary>
        public string bSearchable_5 { get; set; }

        /// <summary>
        /// bSearchable defined column
        /// </summary>
        public string bSearchable_6 { get; set; }

        /// <summary>
        /// bSearchable defined column
        /// </summary>
        public string bSearchable_7 { get; set; }

        /// <summary>
        /// bSearchable defined column
        /// </summary>
        public string bSearchable_8 { get; set; }

        /// <summary>
        /// bSearchable defined column
        /// </summary>
        public string bSearchable_9 { get; set; }

        #endregion

        #region mDataProp (10)

        /// <summary>
        /// mDataProp defined column
        /// </summary>
        public string mDataProp_0 { get; set; }

        /// <summary>
        /// mDataProp defined column
        /// </summary>
        public string mDataProp_1 { get; set; }

        /// <summary>
        /// mDataProp defined column
        /// </summary>
        public string mDataProp_2 { get; set; }

        /// <summary>
        /// mDataProp defined column
        /// </summary>
        public string mDataProp_3 { get; set; }

        /// <summary>
        /// mDataProp defined column
        /// </summary>
        public string mDataProp_4 { get; set; }

        /// <summary>
        /// mDataProp defined column
        /// </summary>
        public string mDataProp_5 { get; set; }

        /// <summary>
        /// mDataProp defined column
        /// </summary>
        public string mDataProp_6 { get; set; }

        /// <summary>
        /// mDataProp defined column
        /// </summary>
        public string mDataProp_7 { get; set; }

        /// <summary>
        /// mDataProp defined column
        /// </summary>
        public string mDataProp_8 { get; set; }

        /// <summary>
        /// mDataProp defined column
        /// </summary>
        public string mDataProp_9 { get; set; }

        #endregion
    }
}
