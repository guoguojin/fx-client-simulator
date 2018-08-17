using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Extensions
{
    public class DataGridViewAutoCompleteTextboxColumn : DataGridViewTextBoxColumn
    {
        #region Private Members
        private AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
        private AutoCompleteMode mode = AutoCompleteMode.SuggestAppend;
        private AutoCompleteSource source = AutoCompleteSource.CustomSource;
        #endregion

        #region Constructor
        public DataGridViewAutoCompleteTextboxColumn()
        {

        }
        #endregion

        #region Properties
        public AutoCompleteStringCollection AutoCompleteCollection
        {
            get { return collection; }
        }

        [DefaultValue(typeof(AutoCompleteMode), "3")]
        public AutoCompleteMode AutoCompleteMode
        {
            get { return mode; }
            set { mode = value; }
        }

        [DefaultValue(typeof(AutoCompleteSource), "64")]
        public AutoCompleteSource AutoCompleteSource
        {
            get { return source; }
            set { source = value; }
        }
        #endregion
    }
}
