using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Extensions
{
    public class DataGridViewExtension : DataGridView
    {
        #region Private Members
        private bool _subformsscrollhorizontally = false;
        private ExtensionControlCollection _controls;
        #endregion

        #region Constructor
        public DataGridViewExtension()
            : base()
        {                  
            EnterMovesRight = true;
            AlternateRowColor = Color.LightGray;
            ShowAlternateRowColor = true;
            SubformsScrollHorizontally = false;
            _controls = new ExtensionControlCollection(this);
        }
        #endregion

        #region Overrides
        ExtensionControlCollection Controls
        {
            get
            {
                return _controls;
            }
        }

        protected override void OnCellFormatting(DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewExtension_CellFormatting(e);
            base.OnCellFormatting(e);
        }

        protected override void OnCellEndEdit(DataGridViewCellEventArgs e)
        {
            DataGridViewExtension_CellEndEdit(e);
            base.OnCellEndEdit(e);
        }

        protected override void OnSelectionChanged(EventArgs e)
        {
            DataGridViewExtension_SelectionChanged(e);
            base.OnSelectionChanged(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            DataGridViewExtension_KeyDown(e);
            base.OnKeyDown(e);
        }

        protected override void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewExtension_EditingControlShowing(e);
            base.OnEditingControlShowing(e);
        }

        protected override void OnScroll(ScrollEventArgs e)
        {
            if (Columns.Cast<DataGridViewColumn>().Where(r => r.GetType() == typeof(DataGridViewSubformColumn)).Count() > 0)
            {
                IEnumerable<DataGridViewSubformColumn> cols = Columns.Cast<DataGridViewColumn>().
                    Where(r => r.GetType() == typeof(DataGridViewSubformColumn)).Cast<DataGridViewSubformColumn>();
                foreach (DataGridViewRow row in Rows)
                {
                    foreach (DataGridViewSubformColumn col in cols)
                    {
                        if (((DataGridViewSubformCell)row.Cells[col.Index]).SubformShowing)
                            ((DataGridViewSubformCell)row.Cells[col.Index]).PositionSubform();
                    }
                }
            }
            base.OnScroll(e);
        }

        protected override void OnResize(EventArgs e)
        {
            if (Columns.Cast<DataGridViewColumn>().Where(r => r.GetType() == typeof(DataGridViewSubformColumn)).Count() > 0)
            {
                DataGridViewSubformColumn[] cols = Columns.Cast<DataGridViewColumn>().
                    Where(r => r.GetType() == typeof(DataGridViewSubformColumn)).Cast<DataGridViewSubformColumn>().ToArray();
                foreach (DataGridViewRow row in Rows)
                {
                    foreach (DataGridViewSubformColumn col in cols)
                    {
                        if (((DataGridViewSubformCell)row.Cells[col.Index]).SubformShowing)
                            ((DataGridViewSubformCell)row.Cells[col.Index]).PositionSubform();
                    }
                }
            }
            base.OnResize(e);
        }        
        
        protected override void OnDataSourceChanged(EventArgs e)
        {
            Controls.Clear();
            base.OnDataSourceChanged(e);
        }

        protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        {
            Controls.Clear();
            base.OnDataBindingComplete(e);
        }

        protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
        {
            _subformcolumns = null;
            base.OnColumnAdded(e);
        }

        protected override void OnColumnRemoved(DataGridViewColumnEventArgs e)
        {
            _subformcolumns = null;
            base.OnColumnRemoved(e);
        }

        protected override void OnUserDeletingRow(DataGridViewRowCancelEventArgs e)
        {
            foreach (DataGridViewSubformColumn col in SubFormColumns)
            {
                if (((DataGridViewSubformCell)e.Row.Cells[col.Index]).SubformShowing)
                {
                    ((DataGridViewSubformCell)e.Row.Cells[col.Index]).CloseForm();
                }
            }
            base.OnUserDeletingRow(e);
        }
        #endregion

        #region Properties
        private IEnumerable<DataGridViewSubformColumn> _subformcolumns = null;
        public IEnumerable<DataGridViewSubformColumn> SubFormColumns
        {
            get
            {
                if (_subformcolumns == null)
                    _subformcolumns = Columns.Cast<DataGridViewColumn>().Where(r => r.GetType() == typeof(DataGridViewSubformColumn)).Cast<DataGridViewSubformColumn>();
                return _subformcolumns;
            }
        }

        private int FirstVisibleColumn
        {
            get
            {
                for (int i = 0; i < Columns.Count; i++)
                {
                    if (Columns[i].Visible)
                        return i;
                }
                return 0;
            }
        }

        [Category("Appearance")]
        [Description("Sets the color for alternate rows in the data grid view")]
        [DefaultValue(typeof(Color), "0xC0C0C0")]
        public Color AlternateRowColor
        {
            get;
            set;
        }

        [Category("Appearance")]
        [Description("True to show AlternateRowColor on alternate rows")]
        [DefaultValue(true)]
        public bool ShowAlternateRowColor
        {
            get;
            set;
        }

        [Category("Behavior")]
        [Description("If true then when the enter key is pressed the next cell will be selected")]
        [DefaultValue(true)]
        public bool EnterMovesRight
        {
            get;
            set;
        }

        [Category("Behavior")]
        [Description("If false then sub forms stay stationary as you scroll horizontally. If true then the subform scrolls with the horizontal scroll")]
        [DefaultValue(false)]
        public bool SubformsScrollHorizontally
        {
            get { return _subformsscrollhorizontally; }
            set
            {
                _subformsscrollhorizontally = value;
                if (!DesignMode)
                {
                    for (int i = 0; i < Rows.Count; i++)
                    {
                        foreach (DataGridViewSubformColumn col in SubFormColumns)
                        {
                            DataGridViewSubformCell cell = ((DataGridViewSubformCell)Rows[i].Cells[col.Index]);
                            if (cell.SubformShowing)
                                cell.PositionSubform();
                        }
                    }
                }
            }
        }
        #endregion

        #region Added Functionality
        
        /// <summary>
        /// Adds the functionality of enter to move to next cell
        /// Adds pressing control and " to copy the cell above
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DataGridViewExtension_KeyDown(KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.OemQuotes)
                {
                    if (CurrentRow.Index > 0)
                    {
                        CurrentCell.Value =
                            Rows[CurrentRow.Index - 1].Cells[
                            CurrentCell.ColumnIndex].Value;
                    }
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (EnterMovesRight)
                {
                    if (CurrentCell.ColumnIndex == Columns.Count - 1)
                    {
                        if (CurrentCell.RowIndex < Rows.Count)
                            CurrentCell = Rows[CurrentRow.Index + 1].Cells[FirstVisibleColumn];
                    }
                    else
                        CurrentCell = CurrentRow.Cells[CurrentCell.ColumnIndex + 1];
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// Used to move cell right if last cell was edited and the selection changed
        /// </summary>
        /// <param name="e"></param>
        void DataGridViewExtension_SelectionChanged(EventArgs e)
        {
            if (lastCellEdit != null)
            {
                if (EnterMovesRight)
                {
                    int row = lastCellEdit.RowIndex;
                    int col = lastCellEdit.ColumnIndex;
                    lastCellEdit = null;
                    if (col == Columns.Count - 1)
                    {
                        if (row < Rows.Count)
                            CurrentCell = Rows[row + 1].Cells[FirstVisibleColumn];
                    }
                    else
                        CurrentCell = Rows[row].Cells[col + 1];
                }
            }
        }        

        DataGridViewCell lastCellEdit = null;
        /// <summary>
        /// Save the last cell that was edited
        /// </summary>
        /// <param name="e"></param>
        void DataGridViewExtension_CellEndEdit(DataGridViewCellEventArgs e)
        {
            lastCellEdit = CurrentCell;
        }        

        /// <summary>
        /// Implements the alternate row color
        /// </summary>
        /// <param name="e"></param>
        void DataGridViewExtension_CellFormatting(DataGridViewCellFormattingEventArgs e)
        {
            if (ShowAlternateRowColor)
            {
                if (e.RowIndex % 2 == 1)
                    e.CellStyle.BackColor = AlternateRowColor;
            }
        }

        /// <summary>
        /// Implements the auto complete mode
        /// </summary>
        /// <param name="e"></param>
        private void DataGridViewExtension_EditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
        {
            if (Columns[CurrentCell.ColumnIndex].GetType() == typeof(DataGridViewAutoCompleteTextboxColumn))
            {
                DataGridViewAutoCompleteTextboxColumn col = (DataGridViewAutoCompleteTextboxColumn)Columns[CurrentCell.ColumnIndex];
                TextBox t = e.Control as TextBox;
                t.AutoCompleteCustomSource = col.AutoCompleteCollection;
                t.AutoCompleteMode = col.AutoCompleteMode;
                t.AutoCompleteSource = col.AutoCompleteSource;
            }
            else if (Columns[CurrentCell.ColumnIndex].GetType() == typeof(DataGridViewDateTimeColumn))
            {
                DataGridViewDateTimeColumn col = (DataGridViewDateTimeColumn)Columns[CurrentCell.ColumnIndex];
                DateTimePicker t = e.Control as DateTimePicker;
                t.Format = col.Format;
                if (col.Format == DateTimePickerFormat.Custom)
                    t.CustomFormat = col.CustomFormat;
                t.ShowUpDown = col.ShowUpDown;
            }
        }
        #endregion
    }       
}
