using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Extensions
{
    public class TimeEditingControl : DataGridViewTextBoxEditingControl
    {
        #region Private members
        private DataGridView dataGridView;
        private bool valueChanged = false;
        private string _format;
        private DateTime _value = new DateTime();
        #endregion

        #region Constructor
        public TimeEditingControl()
        {
            Format = "hh:mm tt";
            _value = DateTime.Now;
        }
        #endregion

        #region Methods
        private bool TimeIsValid()
        {
            string t = Text;
            bool pm = false;
            t = t.Replace(":", "").Replace(" ", "").ToUpper();
            if (t.EndsWith("PM") || t.EndsWith("P"))
                pm = true;
            if (t.EndsWith("PM") || t.EndsWith("AM"))
                t = t.Substring(0, t.Length - 2);
            else if (t.EndsWith("P") || t.EndsWith("A"))
                t = t.Substring(0, t.Length - 1);
            int temp = 0;
            if (Int32.TryParse(t, out temp))
            {
                if (t.Length < 3 || t.Length > 6)
                    return false;
                else
                {
                    if (t.Length < 5)
                    {
                        string minutes = t.Substring(t.Length == 3 ? 1 : 2, 2);
                        string hours = t.Substring(0, t.Length == 3 ? 1 : 2);
                        int min = Int32.Parse(minutes);
                        int h = Int32.Parse(hours);
                        if (min >= 60)
                            return false;
                        if (h >= 24)
                            return false;
                    }
                    else
                    {
                        string seconds = t.Substring(t.Length == 5 ? 3 : 4, 2);
                        string minutes = t.Substring(t.Length == 5 ? 1 : 2, 2);
                        string hours = t.Substring(0, t.Length == 5 ? 1 : 2);
                        int min = Int32.Parse(minutes);
                        int h = Int32.Parse(hours);
                        int secs = Int32.Parse(seconds);
                        if (min >= 60)
                            return false;
                        if (h >= 24)
                            return false;
                        if (secs >= 60)
                            return false;
                    }
                }
            }
            else
                return false;
            return true;
        }

        protected void OnValueChanged()
        {
            // Notify the DataGridView that the contents of the cell
            // have changed.
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
        }

        protected void ValueUnchanged()
        {
            // Notify the DataGridView that the contents of the cell
            // have changed.
            valueChanged = false;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(false);
        }
        #endregion

        #region Properties
        public string Format
        {
            get { return _format; }
            set
            {
                if (new List<string>(new string[] {
                    "h",
                    "hh",
                    "m",
                    "mm",
                    "s",
                    "ss",
                    "t",
                    "tt",
                    "H",
                    "HH",
                    "h:m t",
                    "h:m tt",
                    "h:mm t",
                    "h:mm tt",
                    "hh:m t",
                    "hh:m tt",
                    "hh:mm t",
                    "hh:mm tt",
                    "H:m t",
                    "H:m tt",
                    "H:mm t",
                    "H:mm tt",
                    "HH:m t",
                    "HH:m tt",
                    "HH:mm t",
                    "HH:mm tt",
                    "h:m:s t",
                    "h:m:s tt",
                    "h:m:ss t",
                    "h:m:ss tt",
                    "h:mm:s t",
                    "h:mm:s tt",
                    "h:mm:ss t",
                    "h:mm:ss tt",
                    "hh:m:s t",
                    "hh:m:s tt",
                    "hh:m:ss t",
                    "hh:m:ss tt",
                    "hh:mm:s t",
                    "hh:mm:s tt",
                    "hh:mm:ss t",
                    "hh:mm:ss tt",
                    "H:m:s t",
                    "H:m:s tt",
                    "H:m:ss t",
                    "H:m:ss tt",
                    "H:mm:s t",
                    "H:mm:s tt",
                    "H:mm:ss t",
                    "H:mm:ss tt",
                    "HH:m:s t",
                    "HH:m:s tt",
                    "HH:m:ss t",
                    "HH:m:ss tt",
                    "HH:mm:s t",
                    "HH:mm:s tt",
                    "HH:mm:ss t",
                    "HH:mm:ss tt"                    
                }).Contains(value))
                    _format = value;
                else
                    throw (new FormatException("Incorrect time format. This format can only have time components"));
            }
        }

        public DateTime Value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    if (_value != (DateTime)this.dataGridView.CurrentCell.Value)
                        OnValueChanged();
                    else
                        ValueUnchanged();
                }
            }
        }
        #endregion

        #region Overrides
        public override DataGridView EditingControlDataGridView
        {
            get
            {
                return this.dataGridView;
            }
            set
            {
                this.dataGridView = value;
            }
        }

        public override object EditingControlFormattedValue
        {
            get
            {
                return Value.ToString(Format);
            }
            set
            {
                if (value is string)
                {
                    String parseString = (string)value;
                    bool pm = false;
                    if (!parseString.Contains(':'))
                    {
                        if (parseString.ToUpper().EndsWith(" AM"))
                            parseString = parseString.Substring(0, parseString.Length - 3);
                        if (parseString.ToUpper().EndsWith("AM") || parseString.ToUpper().EndsWith(" A"))
                            parseString = parseString.Substring(0, parseString.Length - 2);
                        if (parseString.ToUpper().EndsWith("A"))
                            parseString = parseString.Substring(0, parseString.Length - 1);
                        if (parseString.ToUpper().EndsWith(" PM"))
                        {
                            parseString = parseString.Substring(0, parseString.Length - 3);
                            pm = true;
                        }
                        if (parseString.ToUpper().EndsWith("PM") || parseString.ToUpper().EndsWith(" P"))
                        {
                            parseString = parseString.Substring(0, parseString.Length - 2);
                            pm = true;
                        }
                        if (parseString.ToUpper().EndsWith("P"))
                        {
                            parseString = parseString.Substring(0, parseString.Length - 1);
                            pm = true;
                        }

                        int temp = 0;
                        if (Int32.TryParse(parseString, out temp))
                        {
                            if (parseString.Length == 3 || parseString.Length == 4)
                            {
                                DateTime val = Value.Date;
                                string minutes = parseString.Substring(parseString.Length - 2, 2);
                                string hours = parseString.Substring(0, parseString.Length == 3 ? 1 : 2);
                                val = val.AddHours(Int32.Parse(hours));
                                val = val.AddMinutes(Int32.Parse(minutes));
                                if (pm && hours != "12") val = val.AddHours(12);
                                Value = val;
                            }
                            else if (parseString.Length == 5 || parseString.Length == 6)
                            {
                                DateTime val = Value.Date;
                                string minutes = parseString.Substring(parseString.Length - 4, 2);
                                string hours = parseString.Substring(0, parseString.Length == 5 ? 1 : 2);
                                string seconds = parseString.Substring(parseString.Length - 2, 2);
                                val = val.AddHours(Int32.Parse(hours));
                                val = val.AddMinutes(Int32.Parse(minutes));
                                val = val.AddSeconds(Int32.Parse(seconds));
                                if (pm && hours != "12") val = val.AddHours(12);
                                Value = val;
                            }
                        }
                    }
                    else
                    {
                        DateTime t = new DateTime();
                        if (DateTime.TryParse(parseString, out t))
                        {
                            Value = Value.Date.AddTicks(t.Ticks);
                        }
                        Text = Value.ToString(Format);
                    }
                }
                else if (value is DateTime)
                {
                    Value = (DateTime)value;
                    Text = Value.ToString(Format);
                }
            }
        }

        public override bool EditingControlWantsInputKey(
            Keys key, bool dataGridViewWantsInputKey)
        {
            // Let the DateTimePicker handle the keys listed.
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Right:
                case Keys.Delete:
                case Keys.Back:
                    return true;
                case Keys.Enter:
                case Keys.Tab:
                    return false;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        public override bool EditingControlValueChanged
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

        public override object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == '1' || e.KeyChar == '2' || e.KeyChar == '3' ||
                e.KeyChar == '5' || e.KeyChar == '6' || e.KeyChar == '7' ||
                e.KeyChar == '8' || e.KeyChar == '9' || e.KeyChar == ' ' || e.KeyChar == '4' ||
                e.KeyChar == 'a' || e.KeyChar == 'A' || e.KeyChar == 'p' || e.KeyChar == '0' ||
                e.KeyChar == 'P' || e.KeyChar == 'm' || e.KeyChar == 'M' || e.KeyChar == ':' || e.KeyChar == '\n')
                base.OnKeyPress(e);
            else
                e.Handled = true;
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            e.Cancel = !TimeIsValid();
            base.OnValidating(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (TimeIsValid())
                EditingControlFormattedValue = Text;
            //base.OnTextChanged(e);
        }
        #endregion
    }
}
