using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Extensions
{
    public class DataGridViewDateTimeColumn : DataGridViewTextBoxColumn
    {
        #region Constructor
        public DataGridViewDateTimeColumn()
        {
            Format = DateTimePickerFormat.Long;
            ShowUpDown = false;
            CellTemplate = new DataGridViewDateTimeCell();
        }
        #endregion

        #region Properties
        [Category("Behaviour")]
        [Description("Sets the custom format string for the DateTimePicker")]
        [DefaultValue("")]
        public string CustomFormat
        {
            get;
            set;
        }

        [Category("Appearance")]
        [Description("Sets the format for the DateTimePicker")]
        [DefaultValue(typeof(DateTimePickerFormat), "1")]
        public DateTimePickerFormat Format
        {
            get;
            set;
        }

        [Category("Appearance")]
        [Description("If true the DateTimePicker shows the up/down button and not the calander")]
        [DefaultValue(false)]
        public bool ShowUpDown
        {
            get;
            set;
        }
        #endregion
    }
}
