using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Extensions
{
    public class DataGridViewDateTimeCell : DataGridViewTextBoxCell
    {
        #region Constructor
        public DataGridViewDateTimeCell()
        {
            ValueType = typeof(DateTime);
            Value = DateTime.Now;
        }
        #endregion

        #region Overrides
        public override Type EditType
        {
            get
            {
                return typeof(DateTimePickerEditingControl);
            }
        }

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, System.ComponentModel.TypeConverter valueTypeConverter, System.ComponentModel.TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            if (value == null)
            {
                value = String.Empty;
                return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
            }
            DataGridViewDateTimeColumn col = (DataGridViewDateTimeColumn)OwningColumn;
            if (col.Format == DateTimePickerFormat.Custom)
            {
                value = ((DateTime)value).ToString(col.CustomFormat);
            }
            else if (col.Format == DateTimePickerFormat.Long)
                value = ((DateTime)value).ToLongDateString();
            else if (col.Format == DateTimePickerFormat.Short)
                value = ((DateTime)value).ToShortDateString();
            else
                value = ((DateTime)value).ToLongTimeString();
            return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
        }
        #endregion
    }
}
