using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Extensions
{
    class ExtensionControlCollection : Control.ControlCollection
    {
        public ExtensionControlCollection(Control Owner)
            : base(Owner)
        { }

        public override void  Remove(Control value)
        {
            if(DataGridViewSubForm.IsDataGridViewSubForm(value.GetType()))
                if(((DataGridViewSubForm)value).IsShowing)
                    return;
 	        base.Remove(value);
        }
    }
}
