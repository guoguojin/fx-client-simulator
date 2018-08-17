using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Extensions
{
    public class DataGridViewSubformColumn : DataGridViewColumn
    {
        #region Events
        public delegate void SubformShowingHandler(DataGridViewSubformCell sender, SubformShowingEventArgs e);
        public delegate void SubformClosingHandler(DataGridViewSubformCell sender, SubformClosingEventArgs e);
        [Category("Behavior")]
        [Description("Occurs just before a sub form is about to be shown. You can then specify the type of subform you want shown or a different dataset or both.")]
        public event SubformShowingHandler SubformShowing;
        [Category("Behavior")]
        [Description("Occurs just before a sub form is about to be closed. You can choose to cancel the close if you wish")]
        public event SubformClosingHandler SubformClosing;
        #endregion

        #region Constructor
        public DataGridViewSubformColumn()
        {
            SubformDataMember = "this";
            this.CellTemplate = new DataGridViewSubformCell();
            IgnoreSubformDataBindingError = false;
        }
        #endregion

        #region Properties
        [Category("Sub Form")]
        [Description("This is the object that will be passed from the bound object of the row to the bound object of the subform. use 'this' (default value) to pass the row data.")]
        [DefaultValue("this")]
        public string SubformDataMember
        {
            get;
            set;
        }

        private Type _subform = null;
        [Category("Sub Form")]
        [Description("This is the form that you want to use as the subform for each row")]
        public Type Subform
        {
            get
            {
                return _subform;
            }
            set
            {
                if (DataGridViewSubForm.IsDataGridViewSubForm(value))
                    _subform = value;
            }
        }

        [Category("Sub Form")]
        [Description("Set true to ignore subform data errors")]
        [DefaultValue(false)]
        public bool IgnoreSubformDataBindingError
        {
            get;
            set;
        }
        #endregion

        #region Methods
        internal void RequestSubformShowing(DataGridViewSubformCell sender, SubformShowingEventArgs e)
        {
            if (SubformShowing != null)
                SubformShowing(sender, e);
        }

        internal void RequestSubformClosing(DataGridViewSubformCell sender, SubformClosingEventArgs e)
        {
            if (SubformClosing != null)
                SubformClosing(sender, e);
        }
        #endregion
    }
}
