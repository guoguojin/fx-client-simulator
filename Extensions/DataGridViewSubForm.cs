using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Extensions
{
    public class DataGridViewSubForm : UserControl
    {
        #region Constructor
        public DataGridViewSubForm(object DataBoundItem, DataGridViewSubformCell Cell)
        {
            _databounditem = DataBoundItem;            
            _cell = Cell;
        }

        public DataGridViewSubForm()
            : this(null, null)
        {
        }
        #endregion

        #region Private members
        private object _databounditem = null;        
        private DataGridViewSubformCell _cell = null;
        private int _horizontalOffset = 0;
        #endregion

        #region Properties
        public bool IsShowing
        {
            get
            {
                return _cell.SubformShowing;
            }
        }

        public object DataBoundItem
        {
            get
            {
                return _databounditem;
            }
            set
            {
                _databounditem = value;
            }
        }

        public DataGridViewRow ParentRow
        {
            get
            {
                return _cell.OwningRow;
            }
        }

        public int HorizontalOffset
        {
            get
            {
                return _horizontalOffset;
            }
            set
            {
                if (value < 0 && _horizontalOffset != 0)
                {
                    OffsetControls(0 - _horizontalOffset);
                    _horizontalOffset = 0;
                }
                else if (value != _horizontalOffset)
                {
                    OffsetControls(value - _horizontalOffset);
                    _horizontalOffset = value;
                }
            }
        }
        #endregion

        #region Static Functions
        public static bool IsDataGridViewSubForm(Type t)
        {
            if (t == null)
                return false;
            while (t != typeof(UserControl))
            {
                if (t == typeof(DataGridViewSubForm))
                    return true;
                t = t.BaseType;
                if (t == null)
                    return false;
            }
            return false;
        }
        #endregion

        #region Overrides

        #endregion

        #region Methods
        private void OffsetControls(int Offset)
        {
            foreach (Control c in Controls)
            {
                c.Left -= Offset;
            }
        }
        #endregion
    }
}
