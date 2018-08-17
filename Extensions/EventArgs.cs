using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Extensions
{
    public class SubformShowingEventArgs : CancelEventArgs
    {
        #region Constructor
        public SubformShowingEventArgs()
        {
            Cancel = false;
            AlternateForm = null;
            DataBoundItem = null;
        }
        #endregion

        #region Private Members
        private Type _alternateForm = null;
        #endregion

        #region Properties
        /// <summary>
        /// Set this to a DataGridViewSubform inherited control if you don't want to use the default form already supplied.
        /// </summary>
        public Type AlternateForm
        {
            get { return _alternateForm; }
            set
            {
                if (DataGridViewSubForm.IsDataGridViewSubForm(value))
                    _alternateForm = value;
            }
        }

        /// <summary>
        /// Set this to a customer data set if you don't want to use the DataMember already supplied
        /// </summary>
        public object DataBoundItem
        { get; set; }
        #endregion
    }

    public class SubformClosingEventArgs : CancelEventArgs
    {
        #region Constructor
        public SubformClosingEventArgs(DataGridViewSubForm Form)
        {
            Cancel = false;
            _form = Form;
        }
        #endregion

        #region Private members
        private DataGridViewSubForm _form = null;
        #endregion

        #region Properties
        /// <summary>
        /// The form that is about to close
        /// </summary>
        public DataGridViewSubForm Form
        {
            get { return _form; }
        }
        #endregion
    }
}
