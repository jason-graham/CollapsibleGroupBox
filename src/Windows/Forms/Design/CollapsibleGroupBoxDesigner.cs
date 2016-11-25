//---------------------------------------------------------------------------- 
//
//  Copyright (C) Jason Graham.  All rights reserved.
// 
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
// 
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
// 
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
// 
// History
//  09/05/13    Created 
//
//---------------------------------------------------------------------------

namespace System.Windows.Forms.Design
{
    using System.ComponentModel;
    using System.ComponentModel.Design;

    /// <summary>
    /// Extends the design mode behavior enabling child controls,
    /// control specific selection rules and a smart tag panel.
    /// </summary>
    public class CollapsibleGroupBoxDesigner : ParentControlDesigner
    {
        /// <summary>
        /// Gets the control selection rules.
        /// </summary>
        public override SelectionRules SelectionRules
        {
            get
            {
                //this allows all sizing unless the control is collapsed

                SelectionRules selectionRules = base.SelectionRules;
                object component = base.Component;
                PropertyDescriptor descriptor = TypeDescriptor.GetProperties(component)["Collapsed"];

                if ((descriptor != null) && ((bool)descriptor.GetValue(component)))
                {
                    selectionRules &= ~SelectionRules.AllSizeable;
                    selectionRules |= Design.SelectionRules.LeftSizeable | Design.SelectionRules.RightSizeable;
                }

                return selectionRules;
            }
        }

        /// <summary>
        /// Gets the control action list.
        /// </summary>
        public override System.ComponentModel.Design.DesignerActionListCollection ActionLists
        {
            get
            {
                DesignerActionListCollection actions = new DesignerActionListCollection();
                actions.Add(new CollapsibleGroupBoxActionList(Component));
                return actions;
            }
        }
    }
}
