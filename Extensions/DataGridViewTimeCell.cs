using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Extensions
{
    public class DataGridViewTimeCell : DataGridViewTextBoxCell
    {
        #region Constructor
        public DataGridViewTimeCell()
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
                return typeof(TimeEditingControl);
            }
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            initialFormattedValue = (DateTime)this.Value;
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
        }

        public override Type ValueType
        {
            get
            {
                return typeof(DateTime);
            }
        }

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, System.ComponentModel.TypeConverter valueTypeConverter, System.ComponentModel.TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            if (value == null)
            {
                value = string.Empty;
                return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
            }
            string format = ((DataGridViewTimeColumn)OwningColumn).Format;
            value = ((DateTime)value).ToString(format);
            return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
        }
        #endregion
    }
}
