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
    using System.Drawing;

    /// <summary>
    /// Provides a smart tag panel for the <see cref="System.Windows.Forms.CollapsibleGroupBox"/> control.
    /// </summary>
    public class CollapsibleGroupBoxActionList : DesignerActionList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="System.Windows.Forms.Design.CollapsibleGroupBoxActionList"/>
        /// </summary>
        /// <param name="component"></param>
        public CollapsibleGroupBoxActionList(IComponent component)
            : base(component)
        {

        }

        #region Control Properties
        /// <summary>
        /// Casts the underlying <see cref="System.ComponentModel.IComponent"/> 
        /// to a <see cref="System.Windows.Forms.CollapsibleGroupBox"/> instance.
        /// </summary>
        private CollapsibleGroupBox Control
        {
            get
            {
                return Component as CollapsibleGroupBox;
            }
        }

        /// <summary>
        /// Gets or sets the percent size change while animating.
        /// </summary>
        public float AnimationStepPercent
        {
            get
            {
                return Control.AnimationStepPercent;
            }
            set
            {
                SetValue("AnimationStepPercent", value);
            }
        }

        /// <summary>
        /// Gets or sets the number of milliseconds between animated frames.
        /// </summary>
        public int AnimationInterval
        {
            get
            {
                return Control.AnimationInterval;
            }
            set
            {
                SetValue("AnimationInterval", value);
            }
        }

        /// <summary>
        /// Gets or sets the title bar text color.
        /// </summary>
        public Color TitleBarTextColor
        {
            get
            {
                return Control.TitleBarTextColor;
            }
            set
            {
                SetValue("TitleBarTextColor", value);
            }
        }

        /// <summary>
        /// Gets or sets the title bar text color while hovering.
        /// </summary>
        public Color TitleBarHoverTextColor
        {
            get
            {
                return Control.TitleBarHoverTextColor;
            }
            set
            {
                SetValue("TitleBarHoverTextColor", value);
            }
        }

        /// <summary>
        /// Gets or sets the title bar text font.
        /// </summary>
        public Font TitleFont
        {
            get
            {
                return Control.TitleFont;
            }
            set
            {
                SetValue("TitleFont", value);
            }
        }

        /// <summary>
        /// Gets or sets the top of the title bar rounded edge radius.
        /// </summary>
        public int TitleBarTopBorderRadius
        {
            get
            {
                return Control.TitleBarTopBorderRadius;
            }
            set
            {
                SetValue("TitleBarTopBorderRadius", value);
            }
        }

        /// <summary>
        /// Gets or sets the control margin.
        /// </summary>
        public Padding ControlMargin
        {
            get
            {
                return Control.ControlMargin;
            }
            set
            {
                SetValue("ControlMargin", value);
            }
        }

        /// <summary>
        /// Gets or sets the title bar icon.
        /// </summary>
        public Image Icon
        {
            get
            {
                return Control.Icon;
            }
            set
            {
                SetValue("Icon", value);
            }
        }

        /// <summary>
        /// Get or set the header height.
        /// </summary>
        public int TitleBarHeight
        {
            get
            {
                return Control.TitleBarSize;
            }
            set
            {
                SetValue("TitleBarHeight", value);
            }
        }

        /// <summary>
        /// Gets or sets the title bar text.
        /// </summary>
        public string Text
        {
            get
            {
                return Control.Text;
            }
            set
            {
                SetValue("Text", value);
            }
        }

        /// <summary>
        /// Gets or sets the child control display area background color.
        /// </summary>
        public Color DisplayAreaBackgroundColor
        {
            get
            {
                return Control.DisplayAreaBackgroundColor;
            }
            set
            {
                SetValue("DisplayAreaBackgroundColor", value);
            }
        }

        /// <summary>
        /// Gets or sets the title bar background linear gradient start color while hovering.
        /// </summary>
        public Color TitleBarHoverStartColor
        {
            get
            {
                return Control.TitleBarHoverStartColor;
            }
            set
            {
                SetValue("TitleBarHoverStartColor", value);
            }
        }

        /// <summary>
        /// Gets or sets the title bar background linear gradient end color while hovering.
        /// </summary>
        public Color TitleBarHoverEndColor
        {
            get
            {
                return Control.TitleBarHoverEndColor;
            }
            set
            {
                SetValue("TitleBarHoverEndColor", value);
            }
        }

        /// <summary>
        /// Gets or sets the title bar background linear gradient start color.
        /// </summary>
        public Color TitleBarStartColor
        {
            get
            {
                return Control.TitleBarStartColor;
            }
            set
            {
                SetValue("TitleBarStartColor", value);
            }
        }

        /// <summary>
        /// Gets or sets the title bar background linear gradient end color.
        /// </summary>
        public Color TitleBarEndColor
        {
            get
            {
                return Control.TitleBarEndColor;
            }
            set
            {
                SetValue("TitleBarEndColor", value);
            }
        }

        /// <summary>
        /// Gets or sets the border color drawn around the control display area.
        /// </summary>
        public Color BorderColor
        {
            get
            {
                return Control.BorderColor;
            }
            set
            {
                SetValue("BorderColor", value);
            }
        }

        /// <summary>
        /// Gets or sets the title bar border linear gradient start color.
        /// </summary>
        public Color TitleBarBorderStartColor
        {
            get
            {
                return Control.TitleBarBorderStartColor;
            }
            set
            {
                SetValue("TitleBarBorderStartColor", value);
            }
        }

        /// <summary>
        /// Gets or sets the title bar border linear gradient end color.
        /// </summary>
        public Color TitleBarBorderEndColor
        {
            get
            {
                return Control.TitleBarBorderEndColor;
            }
            set
            {
                SetValue("TitleBarBorderEndColor", value);
            }
        }

        /// <summary>
        /// Gets or sets the title bar border linear gradient start color when hovering.
        /// </summary>
        public Color TitleBarHoverBorderStartColor
        {
            get
            {
                return Control.TitleBarHoverBorderStartColor;
            }
            set
            {
                SetValue("TitleBarHoverBorderStartColor", value);
            }
        }

        /// <summary>
        /// Gets or sets the title bar border linear gradient end color when hovering.
        /// </summary>
        public Color TitleBarHoverBorderEndColor
        {
            get
            {
                return Control.TitleBarHoverBorderEndColor;
            }
            set
            {
                SetValue("TitleBarHoverBorderEndColor", value);
            }
        }

        /// <summary>
        /// Gets or sets if the control is collapsible.
        /// </summary>
        public bool Collapsible
        {
            get
            {
                return Control.Collapsible;
            }
            set
            {
                SetValue("Collapsible", value);
            }
        }

        /// <summary>
        /// Gets or sets if the control is collapsed.
        /// </summary>
        /// <exception cref="ArgumentException">Dock style prohibits collapsed state.</exception>
        public bool Collapsed
        {
            get
            {
                return Control.Collapsed;
            }
            set
            {
                SetValue("Collapsed", value);
            }
        }

        /// <summary>
        /// Gets or sets the size to expand to.
        /// </summary>
        public int ExpandedSize
        {
            get
            {
                return Control.ExpandedSize;
            }
            set
            {
                SetValue("ExpandedSize", value);
            }
        }

        /// <summary>
        /// Gets or sets if the control can receive focus.
        /// </summary>
        public bool Selectable
        {
            get
            {
                return Control.Selectable;
            }
            set
            {
                SetValue("Selectable", value);
            }
        }

        /// <summary>
        /// Gets or sets which control borders are docked to its parent 
        /// control and determines how a control is resized with its parent.
        /// </summary>
        public DockStyle Dock
        {
            get
            {
                return Control.Dock;
            }
            set
            {
                SetValue("Dock", value);
            }
        }
        #endregion

        /// <summary>
        /// Sets the value of the component to a different value.
        /// </summary>
        /// <param name="property">The name of the <see cref="System.ComponentModel.PropertyDescriptor"/> to set.</param>
        /// <param name="value">The new value.</param>
        private void SetValue(string property, object value)
        {
            TypeDescriptor.GetProperties(Component)[property].SetValue(Component, value);
        }

        /// <summary>
        /// Returns the collection of <see cref="System.ComponentModel.Design.DesignerActionItem"/> objects contained in the list.
        /// </summary>
        /// <returns>A <see cref="System.ComponentModel.Design.DesignerActionItem"/> array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();

            items.Add(new DesignerActionHeaderItem("Title Bar Normal State", "Normal"));
            items.Add(new DesignerActionHeaderItem("Title Bar Hovering State", "Hovering"));
            items.Add(new DesignerActionHeaderItem("Title Bar Layout", "TitleBar"));
            items.Add(new DesignerActionHeaderItem("Client Area", "ClientArea"));
            items.Add(new DesignerActionHeaderItem("Collapsible Settings", "Settings"));

            items.Add(new DesignerActionPropertyItem("TitleBarBorderStartColor", "Title Bar Border Start Color", "Normal"));
            items.Add(new DesignerActionPropertyItem("TitleBarBorderEndColor", "Title Bar Border End Color", "Normal"));
            items.Add(new DesignerActionPropertyItem("TitleBarStartColor", "Title Bar Background Start Color", "Normal"));
            items.Add(new DesignerActionPropertyItem("TitleBarEndColor", "Title Bar Background End Color", "Normal"));
            items.Add(new DesignerActionPropertyItem("TitleBarTextColor", "Title Bar Text Color", "Normal"));

            items.Add(new DesignerActionPropertyItem("TitleBarHoverBorderStartColor", "Title Bar Border Start Color", "Hovering"));
            items.Add(new DesignerActionPropertyItem("TitleBarHoverBorderEndColor", "Title Bar Border End Color", "Hovering"));
            items.Add(new DesignerActionPropertyItem("TitleBarHoverStartColor", "Title Bar Background Start Color", "Hovering"));
            items.Add(new DesignerActionPropertyItem("TitleBarHoverEndColor", "Title Bar Background End Color", "Hovering"));
            items.Add(new DesignerActionPropertyItem("TitleBarHoverTextColor", "Title Bar Text Color", "Hovering"));

            items.Add(new DesignerActionPropertyItem("Icon", "Title Bar Icon", "TitleBar"));
            items.Add(new DesignerActionPropertyItem("Text", "Title", "TitleBar"));
            items.Add(new DesignerActionPropertyItem("TitleBarHeight", "Title Bar Height", "TitleBar"));
            items.Add(new DesignerActionPropertyItem("TitleBarTopBorderRadius", "Title Bar Top Border Radius", "TitleBar"));
            items.Add(new DesignerActionPropertyItem("TitleFont", "Title Bar Text Font", "TitleBar"));

            items.Add(new DesignerActionPropertyItem("BorderColor", "Border Color", "ClientArea"));
            items.Add(new DesignerActionPropertyItem("DisplayAreaBackgroundColor", "Background Color", "ClientArea"));

            items.Add(new DesignerActionPropertyItem("AnimationInterval", "Animation Size Change Interval", "Settings"));
            items.Add(new DesignerActionPropertyItem("AnimationStepPercent", "Animation Size Change Percent", "Settings"));
            items.Add(new DesignerActionPropertyItem("Collapsed", "Collapsed", "Settings"));
            items.Add(new DesignerActionPropertyItem("Collapsible", "Collapsible", "Settings"));
            items.Add(new DesignerActionPropertyItem("Dock", "Dock", "Settings"));
            items.Add(new DesignerActionPropertyItem("ExpandedSize", "Expanded Size", "Settings"));
            items.Add(new DesignerActionPropertyItem("Selectable", "Selectable", "Settings"));

            return items;
        }
    }
}
