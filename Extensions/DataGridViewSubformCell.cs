using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Extensions
{
    public class DataGridViewSubformCell : DataGridViewCell
    {
        #region Constructor
        public DataGridViewSubformCell()
        {
            SubformShowing = false;
            ValueType = typeof(String);
            Value = string.Empty;
        }
        #endregion

        #region Private Members
        private DataGridViewSubForm form = null;
        private bool _subformshowing = false;
        private int heightBeforeShowSubForm = 0;
        private Cursor cursorBeforeMouseEnter = null;
        private object[,] alignmentBeforeShow;
        #endregion

        #region Methods
        /// <summary>
        /// Sets the correct position and width for the subform relating to this cell
        /// </summary>
        public void PositionSubform()
        {
            int Top = DataGridView.Rows.Cast<DataGridViewRow>().Where(r => r.Index < this.RowIndex)
                .Sum(r => r.Height) + heightBeforeShowSubForm +
                (DataGridView.ColumnHeadersVisible ? DataGridView.ColumnHeadersHeight : 0);

            int Left = 1 + this.OwningColumn.Width + (DataGridView.RowHeadersVisible ? DataGridView.RowHeadersWidth : 0) +
                DataGridView.Columns.Cast<DataGridViewColumn>().Where(r => r.Index < this.ColumnIndex && r.Visible).Sum(r => r.Width);

            if (((DataGridViewExtension)DataGridView).SubformsScrollHorizontally)
            {
                Left = Left - DataGridView.HorizontalScrollingOffset;
            }
            if (Left <= (DataGridView.RowHeadersVisible ? DataGridView.RowHeadersWidth : 0))
            {
                form.HorizontalOffset = (DataGridView.RowHeadersVisible ? DataGridView.RowHeadersWidth : 0) - Left;
                Left = (DataGridView.RowHeadersVisible ? DataGridView.RowHeadersWidth : 0);
            }
            else
                form.HorizontalOffset = 0;
            form.Left = Left;
            //form.Width = DataGridView.Width - form.Left - 1;
            form.Width = DataGridView.Columns.Cast<DataGridViewColumn>().Where(r => r.Visible).Sum(r => r.Width) +
                (DataGridView.RowHeadersVisible ? DataGridView.RowHeadersWidth : 0) - 1;

            if (form.Right > DataGridView.Width - 1)
            {
                form.Width = DataGridView.Width - 1 - form.Left;
            }

            Top = Top - DataGridView.VerticalScrollingOffset;
            form.Top = Top;
            if (form.Bottom <= DataGridView.ColumnHeadersHeight)
                form.Visible = false;
            else
                form.Visible = true;
        }

        /// <summary>
        /// Shows the from with correct alignment
        /// </summary>
        public void ShowForm()
        {
            if (this.OwningColumn == null)
                return;
            if (((DataGridViewSubformColumn)this.OwningColumn).Subform == null)
                return;
            //save the previous alignment of cells for when the subform is closed and set new alignments to be the top
            alignmentBeforeShow = new object[OwningRow.Cells.Count, 2];
            for (int i = 0; i < OwningRow.Cells.Count; i++)
            {
                alignmentBeforeShow[i, 0] = OwningRow.Cells[i].Style.Alignment;
                alignmentBeforeShow[i, 1] = OwningRow.Cells[i].OwningColumn;
                if (OwningRow.Cells[i].Style.Alignment == DataGridViewContentAlignment.BottomCenter ||
                    OwningRow.Cells[i].Style.Alignment == DataGridViewContentAlignment.MiddleCenter)
                    OwningRow.Cells[i].Style.Alignment = DataGridViewContentAlignment.TopCenter;
                else if (OwningRow.Cells[i].Style.Alignment == DataGridViewContentAlignment.BottomLeft ||
                    OwningRow.Cells[i].Style.Alignment == DataGridViewContentAlignment.MiddleLeft)
                    OwningRow.Cells[i].Style.Alignment = DataGridViewContentAlignment.TopLeft;
                else if (OwningRow.Cells[i].Style.Alignment == DataGridViewContentAlignment.BottomRight ||
                    OwningRow.Cells[i].Style.Alignment == DataGridViewContentAlignment.MiddleRight)
                    OwningRow.Cells[i].Style.Alignment = DataGridViewContentAlignment.TopRight;
                else if (OwningRow.Cells[i].Style.Alignment == DataGridViewContentAlignment.NotSet)
                {
                    if (OwningRow.Cells[i].GetType() == typeof(DataGridViewCheckBoxCell))
                        OwningRow.Cells[i].Style.Alignment = DataGridViewContentAlignment.TopCenter;
                    else
                        OwningRow.Cells[i].Style.Alignment = DataGridViewContentAlignment.TopLeft;
                }
            }
            heightBeforeShowSubForm = RowSubformCells.Max(r => r.heightBeforeShowSubForm);
            if (heightBeforeShowSubForm == 0)
                heightBeforeShowSubForm = OwningRow.Height; //save the original heigh of the row
            //Fire the subformshowing event to get a possible alternate subform or cancel the showing
            SubformShowingEventArgs ea = new SubformShowingEventArgs();
            ((DataGridViewSubformColumn)this.OwningColumn).RequestSubformShowing(this, ea);
            Type t = null;
            if (ea.Cancel)
            {
                _subformshowing = false;
                return;
            }
            if (ea.AlternateForm != null)
                t = ea.AlternateForm;
            else
                t = ((DataGridViewSubformColumn)this.OwningColumn).Subform;

            //set the data for the subform
            object data = null;
            if (ea.DataBoundItem != null)
                data = ea.DataBoundItem;
            else
            {
                if (((DataGridViewSubformColumn)this.OwningColumn).SubformDataMember == "this")
                {
                    data = OwningRow.DataBoundItem;
                }
                else
                {
                    try
                    {
                        //follow members of member e.g. Shift.Employee.DateOfBirth 
                        string[] parts = ((DataGridViewSubformColumn)this.OwningColumn).SubformDataMember.Split('.');
                        data = OwningRow.DataBoundItem;
                        foreach (string member in parts)
                        {
                            System.Reflection.PropertyInfo pi = data.GetType().GetProperty(member);
                            data = pi.GetValue(OwningRow.DataBoundItem, null);
                        }
                    }
                    catch (Exception e)
                    {
                        if (!((DataGridViewSubformColumn)this.OwningColumn).IgnoreSubformDataBindingError)
                            throw (e);
                    }
                }
            }

            //create the subform
            form = (DataGridViewSubForm)Activator.CreateInstance(t, data, this);
            PositionSubform();
            //set the new row height to be the same as the subform plus the original height
            if (((DataGridViewExtension)DataGridView).SubFormColumns.Count() > 1)
            {
                this.OwningRow.Height = heightBeforeShowSubForm +
                    RowSubformCells.Max(r => r.SubformHeight);
            }
            else
                this.OwningRow.Height = this.OwningRow.Height + form.Height;
            //add the subform to the Data grid view
            DataGridView.Controls.Add(form);
            //reposition all open subforms
            for (int i = OwningRow.Index + 1; i < DataGridView.Rows.Count; i++)
            {
                foreach (DataGridViewSubformColumn col in ((DataGridViewExtension)DataGridView).SubFormColumns)
                {
                    DataGridViewSubformCell cell = (DataGridViewSubformCell)DataGridView.Rows[i].Cells[col.Index];
                    if (cell.SubformShowing)
                        cell.PositionSubform();
                }
            }

            //set the z index for the new subform to be top most
            int childIndex = Int32.MaxValue;
            foreach (DataGridViewSubformColumn col in ((DataGridViewExtension)DataGridView).SubFormColumns)
            {
                int index = DataGridView.Controls.IndexOf(((DataGridViewSubformCell)OwningRow.Cells[col.Index]).form);
                if (index < childIndex)
                    childIndex = index;
            }
            if (childIndex < DataGridView.Controls.IndexOf(form))
                DataGridView.Controls.SetChildIndex(form, childIndex);
        }

        public void CloseForm()
        {
            if (this.OwningColumn == null)
                return;
            if (form != null)
            {
                //Fire the subformclosing event and check for cancels
                SubformClosingEventArgs ea = new SubformClosingEventArgs(form);
                ((DataGridViewSubformColumn)this.OwningColumn).RequestSubformClosing(this, ea);
                if (ea.Cancel)
                {
                    _subformshowing = true;
                    return;
                }
                //remove the subform from the data gridview
                DataGridView.Controls.Remove(form);
                //dispose of the subform
                form.Dispose();
                form = null;
                //set the height of the row to the correct value
                if (((DataGridViewExtension)DataGridView).SubFormColumns.Count() > 1)
                {
                    if (RowSubformCells.Max(r => r.SubformHeight) > 0)
                        OwningRow.Height = RowSubformCells.Max(r => r.SubformHeight) + heightBeforeShowSubForm;
                    else
                    {
                        OwningRow.Height = heightBeforeShowSubForm;
                        heightBeforeShowSubForm = 0;
                    }
                }
                else
                {
                    OwningRow.Height = heightBeforeShowSubForm;
                    heightBeforeShowSubForm = 0;
                }
                //reset alignment for each cell
                if (OwningRow.Cells.Cast<DataGridViewCell>().Where(r => r.GetType() == typeof(DataGridViewSubformCell)).Cast<DataGridViewSubformCell>().Where(r => r.SubformShowing).Count() == 0)
                {
                    for (int i = 0; i < alignmentBeforeShow.Length / 2; i++)
                    {
                        if (OwningRow.Cells.Cast<DataGridViewCell>().Where(r => r.OwningColumn ==
                            (DataGridViewColumn)alignmentBeforeShow[i, 1]).Count() > 0)
                        {
                            OwningRow.Cells.Cast<DataGridViewCell>().Where(r => r.OwningColumn ==
                                (DataGridViewColumn)alignmentBeforeShow[i, 1]).First().Style.Alignment
                                = (DataGridViewContentAlignment)alignmentBeforeShow[i, 0];
                        }
                    }
                }
                //reposition all subforms below this one
                for (int i = DataGridView.CurrentCell.RowIndex + 1; i < DataGridView.Rows.Count; i++)
                {
                    foreach (DataGridViewSubformColumn col in ((DataGridViewExtension)DataGridView).SubFormColumns)
                    {
                        DataGridViewSubformCell cell = ((DataGridViewSubformCell)DataGridView.Rows[i].Cells[col.Index]);
                        if (cell.SubformShowing)
                            cell.PositionSubform();
                    }
                }
            }
        }
        #endregion

        #region Properties
        public bool SubformShowing
        {
            get
            {
                return _subformshowing;
            }
            set
            {
                _subformshowing = value;
                if (!_subformshowing)
                    CloseForm();
                else
                    ShowForm();
                if (DataGridView != null)
                    DataGridView.Refresh();
            }
        }

        public int SubformHeight
        {
            get
            {
                if (SubformShowing)
                    return form.Height;
                return 0;
            }
        }

        private IEnumerable<DataGridViewSubformCell> _rowSubformCells = null;
        private IEnumerable<DataGridViewSubformCell> RowSubformCells
        {
            get
            {
                if (_rowSubformCells == null)
                    _rowSubformCells = OwningRow.Cells.Cast<DataGridViewCell>()
                        .Where(r => r.GetType() == typeof(DataGridViewSubformCell))
                        .Cast<DataGridViewSubformCell>();
                return _rowSubformCells;
            }
        }

        #endregion

        #region Overrides
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            graphics.FillRectangle(new SolidBrush(this.Selected ? cellStyle.SelectionBackColor : cellStyle.BackColor), cellBounds);
            //graphics.DrawRectangle(new Pen(DataGridView.GridColor), new Rectangle(cellBound            
            PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
            int centre = cellBounds.Width / 2 + cellBounds.X;
            Color c = cellStyle.ForeColor;
            if (this.Selected)
                c = cellStyle.SelectionForeColor;
            graphics.DrawRectangle(new Pen(c), new Rectangle(centre - 4, 3 + cellBounds.Top, 10, 10));
            graphics.DrawLine(new Pen(c), centre - 2, 8 + cellBounds.Top, centre + 4, 8 + cellBounds.Top);
            if (!SubformShowing)
                graphics.DrawLine(new Pen(c), centre + 1, 5 + cellBounds.Top, centre + 1, 11 + cellBounds.Top);
            else
            {
                graphics.DrawLine(new Pen(c), centre + 1, 14 + cellBounds.Top, centre + 1, cellBounds.Bottom - 8);
                graphics.DrawLine(new Pen(c), centre + 1, cellBounds.Bottom - 8, centre + 5, cellBounds.Bottom - 8);
            }
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
        }

        public override bool ReadOnly
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        protected override void OnClick(DataGridViewCellEventArgs e)
        {
            SubformShowing = !SubformShowing;
            base.OnClick(e);
        }

        protected override void OnMouseEnter(int rowIndex)
        {
            cursorBeforeMouseEnter = DataGridView.Cursor;
            DataGridView.Cursor = Cursors.Hand;
            base.OnMouseEnter(rowIndex);
        }

        protected override void OnMouseLeave(int rowIndex)
        {
            DataGridView.Cursor = Cursors.Default;
            base.OnMouseLeave(rowIndex);
        }
        #endregion
    }
}
