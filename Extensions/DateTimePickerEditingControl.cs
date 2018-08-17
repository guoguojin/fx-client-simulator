using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Extensions
{
    public class DateTimePickerEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        #region Private members
        private int rowIndex = -1;
        private DataGridView dataGridView;
        private bool valueChanged = false;

        #endregion

        #region Constructor
        public DateTimePickerEditingControl()
        {
            Format = DateTimePickerFormat.Long;
        }
        #endregion

        #region Interface Implementation
        public object EditingControlFormattedValue
        {
            get
            {
                if (Format == DateTimePickerFormat.Long)
                    return Value.ToLongDateString();
                else if (Format == DateTimePickerFormat.Short)
                    return Value.ToShortDateString();
                else if (Format == DateTimePickerFormat.Time)
                    return Value.ToLongTimeString();
                else
                    return Value.ToString(CustomFormat);
            }
            set
            {
                if (value is string)
                {
                    try
                    {
                        Value = DateTime.Parse((string)value);
                    }
                    catch { }
                }
            }
        }

        public object GetEditingControlFormattedValue(
        DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        public void ApplyCellStyleToEditingControl(
            DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
            this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
        }

        public int EditingControlRowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }

        public bool EditingControlWantsInputKey(
            Keys key, bool dataGridViewWantsInputKey)
        {
            // Let the DateTimePicker handle the keys listed.
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // No preparation needs to be done.
        }

        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }

        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }

        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

        protected override void OnValueChanged(EventArgs eventargs)
        {
            // Notify the DataGridView that the contents of the cell
            // have changed.
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }
        #endregion
    }
}
