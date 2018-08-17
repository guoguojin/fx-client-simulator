using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Extensions
{
    public class DataGridViewTimeColumn : DataGridViewTextBoxColumn
    {
        #region Constructor
        public DataGridViewTimeColumn()
        {
            Format = "hh:mm tt";
            CellTemplate = new DataGridViewTimeCell();
        }
        #endregion

        #region Private members
        private string _format;
        #endregion

        #region Properties
        [Category("Behavior")]
        [Description("Sets the format for the time displayed")]
        [DefaultValue("hh:mm tt")]
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
        #endregion

        #region Overrides

        #endregion
    }
}
