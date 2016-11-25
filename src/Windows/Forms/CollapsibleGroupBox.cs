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
//  12/29/13    Created 
//
//---------------------------------------------------------------------------

namespace System.Windows.Forms
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms.Design;

    /// <summary>
    /// The <see cref="System.Windows.Forms.CollapsibleGroupBox"/> control displays a
    /// group box which can be collapsed or expanded to hide or display child controls.
    /// </summary>
    [Designer(typeof(CollapsibleGroupBoxDesigner))]
    public partial class CollapsibleGroupBox : Control
    {
        #region CollapsibleStates Enumeration
        /// <summary>
        /// Defines the state of the <see cref="System.Windows.Forms.CollapsibleGroupBox"/>.
        /// </summary>
        private enum CollapsibleStates
        {
            /// <summary>
            /// The control is fully restored.
            /// </summary>
            Expanded,
            /// <summary>
            /// The control is being restored.
            /// </summary>
            Expanding,
            /// <summary>
            /// The control is collapsing.
            /// </summary>
            Collapsing,
            /// <summary>
            /// The control is collapsed.
            /// </summary>
            Collapsed
        }
        #endregion

        #region Fields
        /// <summary>
        /// Defines the height of the title bar.
        /// </summary>
        private int titleBarSize;
        /// <summary>
        /// Defines the display area background color.
        /// </summary>
        private Color displayAreaBackgroundColor;
        /// <summary>
        /// Defines the title bar text color.
        /// </summary>
        private Color titleBarTextColor;
        /// <summary>
        /// Defines the title bar text color while hovering.
        /// </summary>
        private Color titleBarHoverTextColor;
        /// <summary>
        /// Defines the title bar text font.
        /// </summary>
        private Font titleFont;
        /// <summary>
        /// Defines the title bar background gradient start color.
        /// </summary>
        private Color titleBarStartColor;
        /// <summary>
        /// Defines the title bar background gradient end color.
        /// </summary>
        private Color titleBarEndColor;
        /// <summary>
        /// Defines the display area border color.
        /// </summary>
        private Color borderColor;
        /// <summary>
        /// Defines the title bar border gradient start color.
        /// </summary>
        private Color titleBarBorderStartColor;
        /// <summary>
        /// Defines the title bar border gradient end color.
        /// </summary>
        private Color titleBarBorderEndColor;
        /// <summary>
        /// Defines the control margin.
        /// </summary>
        private Padding controlMargin;
        /// <summary>
        /// Defines the title bar top border radius.
        /// </summary>
        private int titleBarTopBorderRadius;
        /// <summary>
        /// Defines the title bar layout rectangle.
        /// </summary>
        private Rectangle titleBarLayout;
        /// <summary>
        /// Defines the title bar background gradient start color while hovering.
        /// </summary>
        private Color titleBarHoverStartColor;
        /// <summary>
        /// Defines the title bar background gradient end color while hovering.
        /// </summary>
        private Color titleBarHoverEndColor;
        /// <summary>
        /// Defines the icon to render in the title bar.
        /// </summary>
        private Image icon;
        /// <summary>
        /// Defines the title bar border gradient start color while hovering.
        /// </summary>
        private Color titleBarHoverBorderStartColor;
        /// <summary>
        /// Defines the title bar border gradient end color while hovering.
        /// </summary>
        private Color titleBarHoverBorderEndColor;
        /// <summary>
        /// Determines if the control is collapsible.
        /// </summary>
        private bool collapsible;
        /// <summary>
        /// Defines a timer to animate collapsing or restoring.
        /// </summary>
        private Timer frameTimer;
        /// <summary>
        /// Defines the current control collapsed state.
        /// </summary>
        private CollapsibleStates state;
        /// <summary>
        /// Defines the height or width to restore to.
        /// </summary>
        private int size;
        /// <summary>
        /// Defines the percent of height or width change while collapsing or restoring each animation frame.
        /// </summary>
        private float animationStepPercent;
        /// <summary>
        /// Defines the frames per second to render while animating.
        /// </summary>
        private int animationInterval;
        /// <summary>
        /// Determines if the mouse is hovering over the title bar.
        /// </summary>
        private bool hoverTitleBar;
        /// <summary>
        /// Determines if the mouse is pressed on the title bar.
        /// </summary>
        private bool titleBarMouseDown;
        /// <summary>
        /// Defines the pen used to draw a focus path.
        /// </summary>
        private Pen focusPen;
        /// <summary>
        /// Defines the title bar edge.
        /// </summary>
        private CollapsibleGroupBoxTitleEdge edge;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="System.Windows.Forms.CollapsibleGroupBox"/> control.
        /// </summary>
        public CollapsibleGroupBox()
        {
            InitializeComponent();

            #region Field Initialization
            controlMargin = new Padding(3);
            borderColor = Color.LightGray;
            titleBarHoverTextColor = titleBarTextColor = Color.LightCyan;
            titleFont = new Font("Calibri", 12F, System.Drawing.FontStyle.Regular);
            displayAreaBackgroundColor = Color.FromArgb(234, 234, 234);
            titleBarHoverBorderStartColor = Color.FromArgb(80, 200, 100);
            titleBarHoverBorderEndColor = Color.FromArgb(169, 254, 175);
            titleBarHoverStartColor = Color.Chartreuse;
            titleBarHoverEndColor = Color.ForestGreen;
            titleBarStartColor = Color.FromArgb(28, 219, 240);
            titleBarEndColor = Color.DodgerBlue;
            titleBarBorderStartColor = Color.FromArgb(0, 192, 192);
            titleBarBorderEndColor = Color.FromArgb(124, 218, 254);
            size = 200;
            titleBarSize = 23;
            titleBarTopBorderRadius = 3;
            collapsible = true;
            animationStepPercent = 6F;
            animationInterval = 30;
            state = CollapsibleStates.Expanded;
            edge = CollapsibleGroupBoxTitleEdge.Top;

            //creates a focus pen used to draw a focus path
            using (Bitmap bitmap = new Bitmap(2, 2))
            {
                bitmap.SetPixel(1, 0, Color.Transparent);
                bitmap.SetPixel(0, 1, Color.Transparent);
                bitmap.SetPixel(0, 0, Color.Black);
                bitmap.SetPixel(1, 1, Color.Black);

                using (Brush brush = new TextureBrush(bitmap))
                    focusPen = new Pen(brush, 1F);
            }
            #endregion

            SetStyle(
                ControlStyles.ContainerControl |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.SupportsTransparentBackColor |
                ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.Selectable |
                ControlStyles.UserMouse,
                true);

            TabStop = true;
            Size = new Size(400, 200);
        }
        #endregion

        #region Timer Methods
        /// <summary>
        /// Enables the animation resize timer.
        /// </summary>
        private void EnableTimer()
        {
            if (frameTimer == null)
            {
                frameTimer = new Timer(components);
                frameTimer.Interval = animationInterval;
                frameTimer.Tick += _FrameTimer_Tick;
                frameTimer.Start();
            }
        }

        /// <summary>
        /// Disables the animation resize timer.
        /// </summary>
        private void DisableTimer()
        {
            if (frameTimer != null)
            {
                frameTimer.Stop();
                frameTimer.Tick -= _FrameTimer_Tick;
                frameTimer.Dispose();
                frameTimer = null;
            }
        }

        /// <summary>
        /// Handles the animation timer tick event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _FrameTimer_Tick(object sender, EventArgs e)
        {
            //calculate the animation step size
            int step = (int)Math.Ceiling(size * animationStepPercent / 100);

            switch (state)
            {
                case CollapsibleStates.Expanding:
                    {
                        //calculate new height
                        int new_height = Math.Min(GetSize + step, size);

                        //resize control
                        SetSize(new_height);

                        //check if target height reached
                        if (new_height == size)
                            DisableTimer();
                    }
                    break;
                case CollapsibleStates.Collapsing:
                    {
                        //calculate minimum height
                        int min_height = titleBarSize + GetMargin;

                        //calculate new height
                        int new_height = Math.Max(GetSize - step, min_height);

                        //resize control
                        SetSize(new_height);

                        //check if target height reached
                        if (new_height == min_height)
                            DisableTimer();
                    }
                    break;
                case CollapsibleStates.Collapsed:
                case CollapsibleStates.Expanded:
                default:
                    throw new ApplicationException(string.Format("Invalid state defined: {0}.", state));
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets if the control can receive focus.
        /// </summary>
        [Category("Behavior"), Description("Determines if the control can receive focus."), DefaultValue(true)]
        public bool Selectable
        {
            get
            {
                return GetStyle(ControlStyles.Selectable);
            }
            set
            {
                if (value != Selectable)
                    SetStyle(ControlStyles.Selectable, value);
            }
        }

        /// <summary>
        /// Gets or sets the title bar edge.
        /// </summary>
        [Category("Appearance"), Description("The title bar edge."), DefaultValue(typeof(CollapsibleGroupBoxTitleEdge), "Top")]
        public CollapsibleGroupBoxTitleEdge TitleBarEdge
        {
            get
            {
                return edge;
            }
            set
            {
                if (edge != value)
                {
                    if (Dock != DockStyle.None)
                        throw new ArgumentException("Cannot set TitleBarEdge property while control is docked.", "TitleBarEdge");

                    SetTitleBarEdge(value);
                }
            }
        }

        /// <summary>
        /// Sets the title bar edge.
        /// </summary>
        /// <param name="edge">The new title bar edge.</param>
        private void SetTitleBarEdge(CollapsibleGroupBoxTitleEdge edge)
        {
            this.edge = edge;
            UpdateTitleBarLayout();
            UpdateControlsRegions();
            Invalidate();
        }

        /// <summary>
        /// Gets or sets the percent size change while animating.
        /// </summary>
        [Category("Behavior"), Description("Determines the percent size change while animating."), DefaultValue(6F)]
        public float AnimationStepPercent
        {
            get
            {
                return animationStepPercent;
            }
            set
            {
                animationStepPercent = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of milliseconds between animated frames.
        /// </summary>
        [Category("Behavior"), Description("Determines the number of milliseconds between animated frames."), DefaultValue(30)]
        public int AnimationInterval
        {
            get
            {
                return animationInterval;
            }
            set
            {
                if (animationInterval != value)
                {
                    animationInterval = value;

                    if (frameTimer != null)
                        frameTimer.Interval = animationInterval;
                }
            }
        }

        /// <summary>
        /// Gets or sets the title bar text color.
        /// </summary>
        [Category("Appearance"), Description("The title bar text color."), DefaultValue(typeof(Color), "LightCyan")]
        public Color TitleBarTextColor
        {
            get
            {
                return titleBarTextColor;
            }
            set
            {
                if (titleBarTextColor != value)
                {
                    titleBarTextColor = value;

                    if (!hoverTitleBar)
                        InvalidateTitleBar();
                }
            }
        }

        /// <summary>
        /// Gets or sets the title bar text color while hovering.
        /// </summary>
        [Category("Appearance"), Description("The title bar text color while hovering."), DefaultValue(typeof(Color), "LightCyan")]
        public Color TitleBarHoverTextColor
        {
            get
            {
                return titleBarHoverTextColor;
            }
            set
            {
                if (titleBarHoverTextColor != value)
                {
                    titleBarHoverTextColor = value;

                    if (hoverTitleBar)
                        InvalidateTitleBar();
                }
            }
        }

        /// <summary>
        /// Gets or sets the title bar text font.
        /// </summary>
        [Category("Appearance"), Description("The title bar text font."), DefaultValue("Calibri, 12F, style=Regular")]
        public Font TitleFont
        {
            get
            {
                return titleFont;
            }
            set
            {
                if (titleFont != value)
                {
                    titleFont = value;
                    InvalidateTitleBar();
                }
            }
        }

        /// <summary>
        /// Gets or sets the top of the title bar rounded edge radius.
        /// </summary>
        [Category("Appearance"), Description("The top of the title bar rounded edge radius."), DefaultValue(3)]
        public int TitleBarTopBorderRadius
        {
            get
            {
                return titleBarTopBorderRadius;
            }
            set
            {
                if (titleBarTopBorderRadius != value)
                {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException("Value", "Must specify non-negative number.");

                    titleBarTopBorderRadius = value;
                    InvalidateTitleBar();
                }
            }
        }

        /// <summary>
        /// Gets or sets the control margin.
        /// </summary>
        [Category("Layout"), Description("The control margin."), DefaultValue(typeof(Padding), "3, 3, 3, 3")]
        public Padding ControlMargin
        {
            get
            {
                return controlMargin;
            }
            set
            {
                if (controlMargin != value)
                {
                    controlMargin = value;
                    UpdateTitleBarLayout();
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the title bar icon.
        /// </summary>
        [Category("Appearance"), Description("The title bar icon."), DefaultValue(null)]
        public Image Icon
        {
            get
            {
                return icon;
            }
            set
            {
                if (icon != value)
                {
                    icon = value;
                    InvalidateTitleBar();
                }
            }
        }

        /// <summary>
        /// Get or set the header height or width.
        /// </summary>
        [Category("Appearance"), Description("The title bar height or width."), DefaultValue(23)]
        public int TitleBarSize
        {
            get
            {
                return titleBarSize;
            }
            set
            {
                if (titleBarSize != value)
                {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException("TitleBarHeight", "The title bar height cannot be less-than 0.");

                    DisableTimer();

                    titleBarSize = value;
                    size = Math.Max(titleBarSize + GetMargin, size);

                    switch (state)
                    {
                        case CollapsibleStates.Expanded:
                        case CollapsibleStates.Expanding:
                            SetSize(size);
                            state = CollapsibleStates.Expanded;
                            break;
                        case CollapsibleStates.Collapsing:
                        case CollapsibleStates.Collapsed:
                            SetSize(titleBarSize + GetMargin);
                            state = CollapsibleStates.Collapsed;

                            break;
                    }

                    UpdateTitleBarLayout();
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the title bar text.
        /// </summary>
        [Category("Appearance"), Description("Defines the title bar text."), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (base.Text != value)
                {
                    base.Text = value;
                    InvalidateTitleBar();
                }
            }
        }

        /// <summary>
        /// Gets or sets the child control display area background color.
        /// </summary>
        [Category("Appearance"), Description("The child control display area background color."), DefaultValue(typeof(Color), "ffeaeaea")]
        public Color DisplayAreaBackgroundColor
        {
            get
            {
                return displayAreaBackgroundColor;
            }
            set
            {
                if (displayAreaBackgroundColor != value)
                {
                    displayAreaBackgroundColor = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the title bar background linear gradient start color while hovering.
        /// </summary>
        [Category("Appearance"), Description("The title bar background linear gradient start color while hovering."), DefaultValue(typeof(Color), "Chartreuse")]
        public Color TitleBarHoverStartColor
        {
            get
            {
                return titleBarHoverStartColor;
            }
            set
            {
                if (titleBarHoverStartColor != value)
                {
                    titleBarHoverStartColor = value;

                    if (!hoverTitleBar)
                        InvalidateTitleBar();
                }
            }
        }

        /// <summary>
        /// Gets or sets the title bar background linear gradient end color while hovering.
        /// </summary>
        [Category("Appearance"), Description("The title bar background linear gradient end color while hovering."), DefaultValue(typeof(Color), "ForestGreen")]
        public Color TitleBarHoverEndColor
        {
            get
            {
                return titleBarHoverEndColor;
            }
            set
            {
                if (titleBarHoverEndColor != value)
                {
                    titleBarHoverEndColor = value;

                    if (!hoverTitleBar)
                        InvalidateTitleBar();
                }
            }
        }

        /// <summary>
        /// Gets or sets the title bar background linear gradient start color.
        /// </summary>
        [Category("Appearance"), Description("The title bar background linear gradient start color."), DefaultValue(typeof(Color), "ff1cdbf0")]
        public Color TitleBarStartColor
        {
            get
            {
                return titleBarStartColor;
            }
            set
            {
                if (titleBarStartColor != value)
                {
                    titleBarStartColor = value;

                    if (!hoverTitleBar)
                        InvalidateTitleBar();
                }
            }
        }

        /// <summary>
        /// Gets or sets the title bar background linear gradient end color.
        /// </summary>
        [Category("Appearance"), Description("The title bar background linear gradient end color."), DefaultValue(typeof(Color), "DodgerBlue")]
        public Color TitleBarEndColor
        {
            get
            {
                return titleBarEndColor;
            }
            set
            {
                if (titleBarEndColor != value)
                {
                    titleBarEndColor = value;

                    if (!hoverTitleBar)
                        InvalidateTitleBar();
                }
            }
        }

        /// <summary>
        /// Gets or sets the border color drawn around the control display area.
        /// </summary>
        [Category("Appearance"), Description("The border drawn around the control display area."), DefaultValue(typeof(Color), "LightGray")]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                if (borderColor != value)
                {
                    borderColor = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the title bar border linear gradient start color.
        /// </summary>
        [Category("Appearance"), Description("The title bar border linear gradient start color."), DefaultValue(typeof(Color), "ff00c0c0")]
        public Color TitleBarBorderStartColor
        {
            get
            {
                return titleBarBorderStartColor;
            }
            set
            {
                if (titleBarBorderStartColor != value)
                {
                    titleBarBorderStartColor = value;

                    if (!hoverTitleBar)
                        InvalidateTitleBar();
                }
            }
        }

        /// <summary>
        /// Gets or sets the title bar border linear gradient end color.
        /// </summary>
        [Category("Appearance"), Description("The title bar border linear gradient end color."), DefaultValue(typeof(Color), "ff7cdafe")]
        public Color TitleBarBorderEndColor
        {
            get
            {
                return titleBarBorderEndColor;
            }
            set
            {
                if (titleBarBorderEndColor != value)
                {
                    titleBarBorderEndColor = value;

                    if (!hoverTitleBar)
                        InvalidateTitleBar();
                }
            }
        }

        /// <summary>
        /// Gets or sets the title bar border linear gradient start color when hovering.
        /// </summary>
        [Category("Appearance"), Description("The title bar border linear gradient start color when hovering."), DefaultValue(typeof(Color), "ff50c864")]
        public Color TitleBarHoverBorderStartColor
        {
            get
            {
                return titleBarHoverBorderStartColor;
            }
            set
            {
                if (titleBarHoverBorderStartColor != value)
                {
                    titleBarHoverBorderStartColor = value;

                    if (hoverTitleBar)
                        InvalidateTitleBar();
                }
            }
        }

        /// <summary>
        /// Gets or sets the title bar border linear gradient end color when hovering.
        /// </summary>
        [Category("Appearance"), Description("The title bar border linear gradient end color when hovering."), DefaultValue(typeof(Color), "ffa9feaf")]
        public Color TitleBarHoverBorderEndColor
        {
            get
            {
                return titleBarHoverBorderEndColor;
            }
            set
            {
                if (titleBarHoverBorderEndColor != value)
                {
                    titleBarHoverBorderEndColor = value;

                    if (hoverTitleBar)
                        InvalidateTitleBar();
                }
            }
        }

        /// <summary>
        /// Gets or sets if the control is collapsible.
        /// </summary>
        [Category("Behavior"), Description("Indicates whether the control can be collapsed by clicking the title bar."), DefaultValue(true)]
        public bool Collapsible
        {
            get
            {
                return collapsible;
            }
            set
            {
                if (collapsible != value)
                {
                    collapsible = value;

                    if (CanCollapse)
                    {
                        if (titleBarLayout.Contains(PointToClient(MousePosition)))
                            TitleBarEnter();
                    }
                    else
                        TitleBarLeave();
                }
            }
        }

        /// <summary>
        /// Gets or sets if the control is collapsed.
        /// </summary>
        /// <exception cref="ArgumentException">Dock style prohibits collapsed state.</exception>
        [Category("Layout"), Description("Determines whether the control is currently collapsed."), DefaultValue(false)]
        public bool Collapsed
        {
            get
            {
                return state != CollapsibleStates.Expanded;
            }
            set
            {
                if (Collapsed != value)
                {
                    if (value && !CanCollapse)
                        throw new ArgumentException("Cannot collapse control when Collapsed state is unavailable.", "Expanded");

                    //to programmatically change the control state,
                    //disable the timer and manually set state flags
                    DisableTimer();

                    if (value)
                    {
                        SetSize(titleBarSize + controlMargin.Top);
                        state = CollapsibleStates.Collapsed;
                    }
                    else
                    {
                        SetSize(size);
                        state = CollapsibleStates.Expanded;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the height or width to expand to.
        /// </summary>
        [Category("Layout"), Description("The height or width to restore the control to."), DefaultValue(200)]
        public int ExpandedSize
        {
            get
            {
                return size;
            }
            set
            {
                if (size != value)
                {
                    size = Math.Max(titleBarSize + GetMargin, value);

                    if (state == CollapsibleStates.Expanded)
                        SetSize(size);
                }
            }
        }

        /// <summary>
        /// Gets or sets which control borders are docked to its parent 
        /// control and determines how a control is resized with its parent.
        /// </summary>
        public override DockStyle Dock
        {
            get
            {
                return base.Dock;
            }
            set
            {
                if (base.Dock != value)
                {
                    //determine if specified dock style is
                    //incompatible for collapsed state or update title bar edge
                    switch (value)
                    {
                        case DockStyle.Fill:
                            //incompatible dock style, restore and disable
                            //ability to collapse
                            TitleBarLeave();
                            Collapsed = false;
                            break;
                        case DockStyle.Top:
                            SetTitleBarEdge(CollapsibleGroupBoxTitleEdge.Bottom);
                            break;
                        case DockStyle.Bottom:
                            SetTitleBarEdge(CollapsibleGroupBoxTitleEdge.Top);
                            break;
                        case DockStyle.Left:
                            SetTitleBarEdge(CollapsibleGroupBoxTitleEdge.Right);
                            break;
                        case DockStyle.Right:
                            SetTitleBarEdge(CollapsibleGroupBoxTitleEdge.Left);
                            break;
                    }

                    base.Dock = value;
                }
            }
        }

        /// <summary>
        /// Gets if the control can be collapsed. 
        /// </summary>
        private bool CanCollapse
        {
            get
            {
                switch (Dock)
                {
                    case DockStyle.Fill:
                        return false;
                }

                return collapsible;
            }
        }
        #endregion

        #region Control Helper Methods
        /// <summary>
        /// Updates the title bar layout rectangle.
        /// </summary>
        private void UpdateTitleBarLayout()
        {
            switch (edge)
            {
                case CollapsibleGroupBoxTitleEdge.Top:
                    titleBarLayout = new Rectangle(controlMargin.Left, controlMargin.Top, Width - controlMargin.Horizontal, titleBarSize);
                    break;
                case CollapsibleGroupBoxTitleEdge.Bottom:
                    titleBarLayout = new Rectangle(controlMargin.Left, Height - controlMargin.Bottom - titleBarSize, Width - controlMargin.Horizontal, titleBarSize);
                    break;
                case CollapsibleGroupBoxTitleEdge.Left:
                    titleBarLayout = new Rectangle(controlMargin.Left, controlMargin.Top, titleBarSize, Height - controlMargin.Vertical);
                    break;
                case CollapsibleGroupBoxTitleEdge.Right:
                    titleBarLayout = new Rectangle(Width - controlMargin.Right - titleBarSize, controlMargin.Top, titleBarSize, Height - controlMargin.Vertical);
                    break;
                default:
                    throw new ApplicationException(string.Format("The specified CollapsibleGroupBoxTitleEdge: {0} is invalid.", edge));
            }
        }

        /// <summary>
        /// Invalidates the title bar region.
        /// </summary>
        private void InvalidateTitleBar()
        {
            Invalidate(ResizeFromCenter(titleBarLayout, 2, 2));
        }

        /// <summary>
        /// Toggles the collapsed state.
        /// </summary>
        public void ToggleState()
        {
            switch (state)
            {
                case CollapsibleStates.Expanded:
                    state = CollapsibleStates.Collapsing;

                    if (((int)edge | 1) == (int)edge) //top or bottom
                        size = Height;
                    else
                        size = Width;

                    break;
                case CollapsibleStates.Expanding:
                    state = CollapsibleStates.Collapsing;
                    break;
                case CollapsibleStates.Collapsing:
                case CollapsibleStates.Collapsed:
                    state = CollapsibleStates.Expanding;
                    break;
                default:
                    throw new ApplicationException(string.Format("Invalid state defined: {0}.", state));
            }

            EnableTimer();
        }

        /// <summary>
        /// Collapses the control.
        /// </summary>
        public void Collapse()
        {
            if (!CanCollapse)
                throw new ApplicationException("Cannot collapse control when collapsed state is unavailable.");

            switch (state)
            {
                case CollapsibleStates.Expanded:
                case CollapsibleStates.Expanding:
                    ToggleState();
                    break;
            }
        }

        /// <summary>
        /// Expands the control.
        /// </summary>
        public void Expand()
        {
            switch (state)
            {
                case CollapsibleStates.Collapsing:
                case CollapsibleStates.Collapsed:
                    ToggleState();
                    break;
            }
        }

        /// <summary>
        /// Sets the height by calling the <see cref="System.Windows.Forms.Control.SetBoundsCore"/>
        /// to internally change the height or width.
        /// </summary>
        /// <param name="value">The new width or height of the control.</param>
        private void SetSize(int value)
        {
            if (((int)edge | 1) == (int)edge) //top or bottom
                base.SetBoundsCore(Left, Top, Width, value, BoundsSpecified.Height);
            else
                base.SetBoundsCore(Left, Top, value, Height, BoundsSpecified.Width);
        }

        private int GetSize
        {
            get
            {
                if (((int)edge | 1) == (int)edge) //top or bottom
                    return Height;
                else
                    return Width;
            }
        }

        private int GetMargin
        {
            get
            {
                switch (edge)
                {
                    case CollapsibleGroupBoxTitleEdge.Top:
                        return controlMargin.Top;
                    case CollapsibleGroupBoxTitleEdge.Bottom:
                        return controlMargin.Bottom;
                    case CollapsibleGroupBoxTitleEdge.Left:
                        return controlMargin.Left;
                    case CollapsibleGroupBoxTitleEdge.Right:
                        return controlMargin.Right;
                    default:
                        throw new ApplicationException(string.Format("The specified CollapsibleGroupBoxTitleEdge: {0} is invalid.", edge));
                }
            }
        }

        /// <summary>
        /// Updates the cursor and invalidates title bar when the mouse is hovering over the
        /// title bar.
        /// </summary>
        private void TitleBarEnter()
        {
            if (!hoverTitleBar)
            {
                hoverTitleBar = true;
                Cursor = Cursors.Hand;
                InvalidateTitleBar();
            }
        }

        /// <summary>
        /// Updates the cursor and invalidates title bar when the mouse is no longer hovering
        /// over the title bar.
        /// </summary>
        private void TitleBarLeave()
        {
            if (hoverTitleBar)
            {
                hoverTitleBar = false;
                Cursor = Cursors.Default;
                InvalidateTitleBar();
            }

            titleBarMouseDown = false;
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Allows the user to press the spacebar key 
        /// while the control is focused to toggle state.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (CanCollapse && e.KeyCode == Keys.Space)
                ToggleState();

            base.OnKeyUp(e);
        }

        /// <summary>
        /// When the control receives focus, invalidates
        /// the control.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnGotFocus(EventArgs e)
        {
            InvalidateTitleBar();
            base.OnGotFocus(e);
        }

        /// <summary>
        /// When the control loses focus, invalidates the
        /// control.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLostFocus(EventArgs e)
        {
            InvalidateTitleBar();
            base.OnLostFocus(e);
        }

        /// <summary>
        /// Gets the control display rectangle which defines an area for
        /// child controls to be rendered.
        /// </summary>
        public override Rectangle DisplayRectangle
        {
            get
            {
                //HACK: Single value modification to make display area operate properly.
                switch (edge)
                {
                    case CollapsibleGroupBoxTitleEdge.Top:
                        return new Rectangle(Padding.Left + controlMargin.Left + 1, Padding.Top + controlMargin.Top + titleBarSize, Width - Padding.Horizontal - controlMargin.Horizontal - 1, Height - Padding.Vertical - controlMargin.Vertical - titleBarSize - 1);
                    case CollapsibleGroupBoxTitleEdge.Bottom:
                        return new Rectangle(Padding.Left + controlMargin.Left + 1, Padding.Top + controlMargin.Top + 1, Width - Padding.Horizontal - controlMargin.Horizontal - 1, Height - Padding.Vertical - controlMargin.Vertical - titleBarSize - 1);
                    case CollapsibleGroupBoxTitleEdge.Left:
                        return new Rectangle(Padding.Left + controlMargin.Left + titleBarSize + 1, Padding.Top + controlMargin.Top + 1, Width - Padding.Horizontal - controlMargin.Horizontal - titleBarSize - 1, Height - Padding.Vertical - controlMargin.Vertical - 1);
                    case CollapsibleGroupBoxTitleEdge.Right:
                        return new Rectangle(Padding.Left + controlMargin.Left + 1, Padding.Top + controlMargin.Top + 1, Width - Padding.Horizontal - controlMargin.Horizontal - titleBarSize - 1, Height - Padding.Vertical - controlMargin.Vertical - 1);
                    default:
                        throw new ApplicationException(string.Format("The specified CollapsibleGroupBoxTitleEdge: {0} is invalid.", edge));
                }
            }
        }

        /// <summary>
        /// Gets the control default padding.
        /// </summary>
        protected override Padding DefaultPadding
        {
            get
            {
                return new Padding(0, 0, 0, 0);
            }
        }

        /// <summary>
        /// When the control size changes, update the title
        /// bar layout and control regions.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            UpdateTitleBarLayout();
            UpdateControlsRegions();
            base.OnSizeChanged(e);
        }

        /// <summary>
        /// When a new control is added, sets the control region and
        /// subscribes to size, location or dock changing events.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnControlAdded(ControlEventArgs e)
        {
            SetControlRegion(e.Control);

            e.Control.LocationChanged += Control_SizeOrLocationChanged;
            e.Control.SizeChanged += Control_SizeOrLocationChanged;
            e.Control.DockChanged += Control_SizeOrLocationChanged;

            base.OnControlAdded(e);
        }

        /// <summary>
        /// When a control is removed, resets the control region and
        /// unsubscribes from the size, location or dock changing events.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            e.Control.LocationChanged -= Control_SizeOrLocationChanged;
            e.Control.SizeChanged -= Control_SizeOrLocationChanged;
            e.Control.DockChanged -= Control_SizeOrLocationChanged;

            if (e.Control.Region != null)
            {
                e.Control.Region.Dispose();
                e.Control.Region = null;
            }

            base.OnControlRemoved(e);
        }

        /// <summary>
        /// Limits the height to the minimum size of the title bar if restored or restoring;
        /// otherwise, prevents any changes to the height.
        /// </summary>
        /// <param name="x">The new <see cref="System.Windows.Forms.Control.Left"/> property value of the control.</param>
        /// <param name="y">The new <see cref="System.Windows.Forms.Control.Top"/> property value of the control.</param>
        /// <param name="width">The new <see cref="System.Windows.Forms.Control.Width"/> property value of the control.</param>
        /// <param name="height">The new <see cref="System.Windows.Forms.Control.Height"/> property value of the control.</param>
        /// <param name="specified">A bitwise combination of the <see cref="System.Windows.Forms.BoundsSpecified"/> values.</param>
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if ((specified.HasFlag(BoundsSpecified.Height) && (edge == CollapsibleGroupBoxTitleEdge.Top || edge == CollapsibleGroupBoxTitleEdge.Bottom)) ||
                (specified.HasFlag(BoundsSpecified.Width) && (edge == CollapsibleGroupBoxTitleEdge.Left || edge == CollapsibleGroupBoxTitleEdge.Right)))
            {
                switch (state)
                {
                    case CollapsibleStates.Expanded:
                    case CollapsibleStates.Expanding:
                        DisableTimer();

                        size = height = Math.Max(titleBarSize + GetMargin, height);
                        break;
                    case CollapsibleStates.Collapsing:
                    case CollapsibleStates.Collapsed:

                        switch (edge)
                        {
                            case CollapsibleGroupBoxTitleEdge.Top:
                            case CollapsibleGroupBoxTitleEdge.Bottom:
                                height = GetSize;
                                break;
                            case CollapsibleGroupBoxTitleEdge.Left:
                            case CollapsibleGroupBoxTitleEdge.Right:
                                width = GetSize;
                                break;
                        }

                        break;
                    default:
                        break;
                }
            }

            base.SetBoundsCore(x, y, width, height, specified);
        }

        /// <summary>
        /// Begins a title bar click operation.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == Forms.MouseButtons.Left && hoverTitleBar && CanCollapse)
                titleBarMouseDown = true;

            base.OnMouseDown(e);
        }

        /// <summary>
        /// Completes a title bar click operation.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == Forms.MouseButtons.Left && CanCollapse && titleBarMouseDown)
                ToggleState();

            base.OnMouseUp(e);
        }

        /// <summary>
        /// Hit tests the title bar and invalidates title region.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (CanCollapse)
            {
                if (titleBarLayout.Contains(e.Location))
                    TitleBarEnter();
                else
                    TitleBarLeave();
            }

            base.OnMouseMove(e);
        }

        /// <summary>
        /// Resets and invalidates title bar.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {
            TitleBarLeave();
            base.OnMouseLeave(e);
        }

        /// <summary>
        /// Draws the background and header.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // base.OnPaint(e);
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            if (titleBarSize > 0)
            {
                Rectangle body = new Rectangle(controlMargin.Left, controlMargin.Top, Width - controlMargin.Horizontal, Height - controlMargin.Vertical);

                switch (edge)
                {
                    case CollapsibleGroupBoxTitleEdge.Top:
                        body.Height -= titleBarSize - 1;
                        body.Y += titleBarSize - 1;
                        break;
                    case CollapsibleGroupBoxTitleEdge.Bottom:
                        body.Height -= titleBarSize - 1;
                        break;
                    case CollapsibleGroupBoxTitleEdge.Left:
                        body.X += titleBarSize - 1;
                        body.Width -= titleBarSize - 1;
                        break;
                    case CollapsibleGroupBoxTitleEdge.Right:
                        body.Width -= titleBarSize - 1;
                        break;
                    default:
                        throw new ApplicationException(string.Format("The specified CollapsibleGroupBoxTitleEdge: {0} is invalid.", edge));
                }

                using (SolidBrush sb = new SolidBrush(displayAreaBackgroundColor)) //fill the background area
                    g.FillRectangle(sb, body);

                using (Pen border = new Pen(BorderColor))
                {
                    Point first, second, third, fourth;

                    switch (edge)
                    {
                        case CollapsibleGroupBoxTitleEdge.Top:
                            first = new Point(titleBarLayout.Left, titleBarLayout.Bottom);
                            second = new Point(titleBarLayout.Left, Height - controlMargin.Bottom);
                            third = new Point(titleBarLayout.Right, second.Y);
                            fourth = new Point(third.X, first.Y);
                            break;
                        case CollapsibleGroupBoxTitleEdge.Bottom:
                            first = titleBarLayout.Location;
                            second = new Point(controlMargin.Left, controlMargin.Top);
                            third = new Point(titleBarLayout.Right, second.Y);
                            fourth = new Point(third.X, first.Y);
                            break;
                        case CollapsibleGroupBoxTitleEdge.Left:
                            first = new Point(titleBarLayout.Right, titleBarLayout.Top);
                            second = new Point(Width - controlMargin.Right, first.Y);
                            third = new Point(second.X, Height - controlMargin.Bottom);
                            fourth = new Point(first.X, third.Y);
                            break;
                        case CollapsibleGroupBoxTitleEdge.Right:
                            first = titleBarLayout.Location;
                            second = new Point(controlMargin.Left, controlMargin.Top);
                            third = new Point(second.X, titleBarLayout.Bottom);
                            fourth = new Point(first.X, third.Y);
                            break;
                        default:
                            throw new ApplicationException(string.Format("The specified CollapsibleGroupBoxTitleEdge: {0} is invalid.", edge));
                    }

                    g.DrawLine(border, first, second);
                    g.DrawLine(border, second, third);
                    g.DrawLine(border, third, fourth);
                }

                using (GraphicsPath gp = new GraphicsPath())
                {
                    RectangleCorners corners;
                    Point g_start;
                    Point g_end;

                    switch (edge)
                    {
                        case CollapsibleGroupBoxTitleEdge.Top:
                            corners = RectangleCorners.TopLeft | RectangleCorners.TopRight;
                            g_start = titleBarLayout.Location;
                            g_end = new Point(titleBarLayout.Left, titleBarLayout.Bottom);
                            break;
                        case CollapsibleGroupBoxTitleEdge.Bottom:
                            corners = RectangleCorners.BottomLeft | RectangleCorners.BottomRight;
                            g_start = new Point(titleBarLayout.Left, titleBarLayout.Bottom);
                            g_end = titleBarLayout.Location;
                            break;
                        case CollapsibleGroupBoxTitleEdge.Left:
                            corners = RectangleCorners.TopLeft | RectangleCorners.BottomLeft;
                            g_start = titleBarLayout.Location;
                            g_end = new Point(titleBarLayout.Right, titleBarLayout.Top);
                            break;
                        case CollapsibleGroupBoxTitleEdge.Right:
                            corners = RectangleCorners.TopRight | RectangleCorners.BottomRight;
                            g_start = new Point(titleBarLayout.Right, titleBarLayout.Top);
                            g_end = new Point(titleBarLayout.Left, titleBarLayout.Top);
                            break;
                        default:
                            throw new ApplicationException(string.Format("The specified CollapsibleGroupBoxTitleEdge: {0} is invalid.", edge));
                    }

                    Rectangle titleBar = new Rectangle(titleBarLayout.Location, new Size(titleBarLayout.Width, titleBarLayout.Height));

                    switch (edge)
                    {
                        case CollapsibleGroupBoxTitleEdge.Bottom:
                            titleBar.Height--;
                            titleBar.Y++;
                            break;
                        case CollapsibleGroupBoxTitleEdge.Top:
                            titleBar.Height--;
                            break;
                        case CollapsibleGroupBoxTitleEdge.Left:
                            titleBar.Width--;
                            break;
                        case CollapsibleGroupBoxTitleEdge.Right:
                            titleBar.Width--;
                            titleBar.X++;
                            break;
                    }

                    gp.AddRoundedRectangle(titleBar, titleBarTopBorderRadius, corners);

                    using (LinearGradientBrush lgb = new LinearGradientBrush(g_start, g_end, hoverTitleBar ? titleBarHoverStartColor : titleBarStartColor, hoverTitleBar ? titleBarHoverEndColor : titleBarEndColor))
                        g.FillPath(lgb, gp); //fill the header

                    using (LinearGradientBrush sideBorderGradient = new LinearGradientBrush(g_start, g_end, hoverTitleBar ? titleBarHoverBorderStartColor : titleBarBorderStartColor, hoverTitleBar ? titleBarHoverBorderEndColor : titleBarBorderEndColor))
                    using (Pen sideBorderGradientPen = new Pen(sideBorderGradient))
                        g.DrawPath(sideBorderGradientPen, gp);

                    if (Focused)
                        g.DrawPath(focusPen, gp);
                }

                //defines text layout                
                Rectangle textLayout = titleBarLayout;

                if (icon != null)
                {
                    //create maximum icon region
                    Rectangle iconRegion = new Rectangle(controlMargin.Left, controlMargin.Top, 0, 0);

                    if (((int)edge | 1) == (int)edge)
                        iconRegion = new Rectangle(titleBarLayout.Left, titleBarLayout.Top, titleBarLayout.Height, titleBarLayout.Height);
                    else
                        iconRegion = new Rectangle(titleBarLayout.Left, titleBarLayout.Top, titleBarLayout.Width, titleBarLayout.Width);

                    iconRegion.X += 1;
                    iconRegion.Y += 1;
                    iconRegion.Width -= 2;
                    iconRegion.Height -= 2;

                    //scale and center icon layout in region
                    Rectangle iconLayout = ScaleCenter(Icon.Size, iconRegion);

                    //draw image
                    g.DrawImage(Icon, iconLayout);

                    if (((int)edge | 1) == (int)edge) //top or bottom
                    {
                        textLayout.X += iconLayout.Width + 2;
                        textLayout.Width -= iconLayout.Width + 2;
                    }
                    else
                    {
                        textLayout.Y += iconLayout.Height + 2;
                        textLayout.Height -= iconLayout.Height + 2;
                    }
                }

                //draw text
                if (!string.IsNullOrEmpty(Text))
                {
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Near;
                    sf.FormatFlags = StringFormatFlags.NoWrap;
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Trimming = StringTrimming.EllipsisCharacter;

                    if (((int)edge | 4) == (int)edge) //left or right
                        sf.FormatFlags |= StringFormatFlags.DirectionVertical;

                    using (SolidBrush sb = new SolidBrush(hoverTitleBar ? titleBarHoverTextColor : titleBarTextColor))
                        g.DrawString(Text, titleFont, sb, textLayout, sf);
                }
            }
        }
        #endregion

        #region Rectangle Helper Methods
        /// <summary>
        /// Scales the specified size to fit inside the specified bounds.
        /// </summary>
        /// <param name="sz">A <see cref="System.Drawing.Size"/> to fit inside the bounds.</param>
        /// <param name="bounds">The maximum <see cref="System.Drawing.Rectangle"/> bounds for the size to fit in.</param>
        /// <returns>The scaled <see cref="System.Drawing.Size"/> in the specified <see cref="System.Drawing.Rectangle"/>.</returns>
        private static Rectangle ScaleCenter(Size sz, Rectangle bounds)
        {
            if (sz.Width > bounds.Width)
            {
                float scale = (float)bounds.Width / (float)sz.Width;
                sz = new Size(bounds.Width, (int)(sz.Height * scale));
            }

            if (sz.Height > bounds.Height)
            {
                float scale = (float)bounds.Height / (float)sz.Height;
                sz = new Size((int)(sz.Width * scale), bounds.Height);
            }

            Rectangle rec = new Rectangle(Point.Empty, sz);

            rec.X = bounds.X + (bounds.Width - sz.Width) / 2;
            rec.Y = bounds.Y + (bounds.Height - sz.Height) / 2;

            return rec;
        }

        /// <summary>
        /// Resizes a <see cref="System.Drawing.Rectangle"/> from the center by moving in each direction.
        /// </summary>
        /// <param name="rec">The <see cref="System.Drawing.Rectangle"/> to resize.</param>
        /// <param name="width_offset">A value to offset the width by.</param>
        /// <param name="height_offset">A value to offset the height by.</param>
        /// <returns>A new <see cref="System.Drawing.Rectangle"/> structure with it's width and height changed by the 
        /// specified values and centered relative to the original position.</returns>
        private static Rectangle ResizeFromCenter(Rectangle rec, int width_offset, int height_offset)
        {
            return new Rectangle(rec.X - (width_offset / 2), rec.Y - (height_offset / 2), rec.Width + width_offset, rec.Height + height_offset);
        }
        #endregion

        #region Control Region Methods
        /// <summary>
        /// Target method for control size or location changes to update
        /// the control region.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_SizeOrLocationChanged(object sender, EventArgs e)
        {
            SetControlRegion((Control)sender);
        }

        /// <summary>
        /// Updates all the child control regions.
        /// </summary>
        private void UpdateControlsRegions()
        {
            foreach (Control ctrl in Controls)
                SetControlRegion(ctrl);
        }

        /// <summary>
        /// Sets a <see cref="System.Windows.Forms.Control"/> region to
        /// prevent the control extending pass the display area.
        /// </summary>
        /// <param name="ctrl">The control to clip.</param>
        private void SetControlRegion(Control ctrl)
        {
            if (ctrl == null)
                throw new ArgumentNullException("ctrl");

            //get the current display area
            Rectangle displayRectangle = DisplayRectangle;

            //dispose any existing region (we cannot reuse because
            //the control does not realize the region has changed)
            if (ctrl.Region != null)
                ctrl.Region.Dispose();

            if (displayRectangle.Contains(ctrl.Bounds))
                //no need to set region
                ctrl.Region = null;
            else
            {
                //create region rectangle constrained to display rectangle
                Rectangle region = ctrl.Bounds.Constrain(displayRectangle);

                //set region to client rectangle position used for regions
                if (ctrl.Location.X < displayRectangle.X)
                    region.X = displayRectangle.X - ctrl.Location.X;
                else
                    region.X = 0;

                if (ctrl.Location.Y < displayRectangle.Y)
                    region.Y = displayRectangle.Y - ctrl.Location.Y;
                else
                    region.Y = 0;

                //set new region
                ctrl.Region = new Region(region);
            }
        }
        #endregion
    }
}