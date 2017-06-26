
namespace MapLifter.Ui {
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Core;
    
    public partial class MainWindow: Form {
        private void SetMinimumSize()
        {
            var dimensions = new Size( 640, 480 );
            var minDimensions = new Size( 320, 240 );
            var desktop = SystemInformation.VirtualScreen;
            
            if ( desktop.Width >= 1024   
              && desktop.Height >= 768 )
            {
                minDimensions = new Size( 640, 480 );
                dimensions = new Size( 1024, 768 );                    
            }
            else
            if ( desktop.Width >= 800
              && desktop.Height >= 600 )
            {    
                 dimensions = new Size( 800, 600 );   
            }

            this.MinimumSize = minDimensions;
            this.Size = dimensions;
        }

        private void BuildCanvas()
        {
            
        }
        
        private void BuildAboutPanel()
        {
            // Panel for about info
            this.pnlAbout = new Panel();
            this.pnlAbout.SuspendLayout();
            this.pnlAbout.Dock = DockStyle.Bottom;
            this.pnlAbout.BackColor = Color.LightYellow;
            var lblAbout = new Label
            {
                Text = AppInfo.Name + " v" + AppInfo.Version + ", " + AppInfo.Author,
                Dock = DockStyle.Left,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true
            };
            var font = new Font( lblAbout.Font, FontStyle.Bold );
            font = new Font( font.FontFamily, 14 );
            lblAbout.Font = font;
            var btCloseAboutPanel = new Button { Text = "X" };
            btCloseAboutPanel.Font = new Font( btCloseAboutPanel.Font, FontStyle.Bold );
            btCloseAboutPanel.Dock = DockStyle.Right;
            btCloseAboutPanel.Width = this.CharWidth * 5;
            btCloseAboutPanel.FlatStyle = FlatStyle.Flat;
            btCloseAboutPanel.FlatAppearance.BorderSize = 0;
            btCloseAboutPanel.Click += (obj, args) => this.pnlAbout.Hide();
            this.pnlAbout.Controls.Add( lblAbout );
            this.pnlAbout.Controls.Add( btCloseAboutPanel );
            this.pnlAbout.Hide();
            this.pnlAbout.MinimumSize = new Size( this.Width, lblAbout.Height +5 );
            this.pnlAbout.MaximumSize = new Size( int.MaxValue, lblAbout.Height +5 );
            this.pnlAbout.ResumeLayout();
            this.Controls.Add( this.pnlAbout );
        }
        
        private void BuildIcons()
        {
            var resourceMapIcon = System.Reflection.Assembly.
                GetEntryAssembly().
                GetManifestResourceStream( "MapLifter.Res.map.png" );

            // Prepare icons
            if ( resourceMapIcon != null ) {
                this.mapIconBmp = new Bitmap( resourceMapIcon );
                this.Icon = Icon.FromHandle( this.mapIconBmp.GetHicon() );

                this.newIconBmp = new Bitmap( System.Reflection.Assembly.
                    GetEntryAssembly().
                    GetManifestResourceStream( "MapLifter.Res.new.png" ) );
                
                this.openIconBmp = new Bitmap( System.Reflection.Assembly.
                    GetEntryAssembly().
                    GetManifestResourceStream( "MapLifter.Res.open.png" ) );
                
                this.saveIconBmp = new Bitmap( System.Reflection.Assembly.
                    GetEntryAssembly().
                    GetManifestResourceStream( "MapLifter.Res.save.png" ) );
                
                this.importIconBmp = new Bitmap( System.Reflection.Assembly.
                    GetEntryAssembly().
                    GetManifestResourceStream( "MapLifter.Res.import.png" ) );
                
                this.exportIconBmp = new Bitmap( System.Reflection.Assembly.
                    GetEntryAssembly().
                    GetManifestResourceStream( "MapLifter.Res.export.png" ) );
                
                this.settingsIconBmp = new Bitmap( System.Reflection.Assembly.
                    GetEntryAssembly().
                    GetManifestResourceStream( "MapLifter.Res.settings.png" ) );
                
                this.helpIconBmp = new Bitmap( System.Reflection.Assembly.
                    GetEntryAssembly().
                    GetManifestResourceStream( "MapLifter.Res.help.png" ) );
                
                this.aboutIconBmp = new Bitmap( System.Reflection.Assembly.
                    GetEntryAssembly().
                    GetManifestResourceStream( "MapLifter.Res.about.png" ) );
            }

            return;
        }
        
        

        private void BuildToolbar()
        {
            // Image list
            var imgList = new ImageList();
            imgList.ImageSize = new System.Drawing.Size( 24, 24 );
            imgList.Images.AddRange( new Bitmap[] {
                this.newIconBmp, this.openIconBmp,
                this.saveIconBmp, this.importIconBmp,
                this.exportIconBmp, this.settingsIconBmp,
                this.tbbHelp, this.aboutIconBmp
            } );

            // Toolbar
            this.tbToolbar = new ToolBar();
            this.tbToolbar.AutoSize = true;
            this.tbToolbar.Dock = DockStyle.Top;
            this.tbToolbar.Appearance = ToolBarAppearance.Flat;
            this.tbToolbar.BorderStyle = BorderStyle.None;
            this.tbToolbar.ImageList = imgList;
            this.tbToolbar.ShowToolTips = true;

            // Toolbar buttons
            var tbbOpen = new ToolBarButton();
            tbbOpen.ImageIndex = 1;
            var tbbSave = new ToolBarButton();
            tbbSave.ImageIndex = 2;
            var tbbImport = new ToolBarButton();
            tbbImport.ImageIndex = 3;
            var tbbExport = new ToolBarButton();
            tbbExport.ImageIndex = 4;
            var tbbSettings = new ToolBarButton();
            tbbSettings.ImageIndex = 11;
            var tbbHelp = new ToolBarButton();
            tbbHelp.ImageIndex = 9;
            var tbbAbout = new ToolBarButton();
            tbbAbout.ImageIndex = 10;

            this.tbToolbar.ButtonClick += (object o, ToolBarButtonClickEventArgs e) => {
                switch( this.tbToolbar.Buttons.IndexOf( e.Button ) ) {
                    case 0: this.DoNew(); break;
                    case 1: this.DoOpen(); break;
                    case 2: this.DoSave(); break;
                    case 3: this.DoImport(); break;
                    case 4: this.DoExport(); break;
                    case 5: this.DoSettings(); break;
                    case 6: this.DoHelp(); break;
                    case 7: this.DoAbout(); break;
                    default: throw new ArgumentException( "unexpected toolbar button: unhandled" );
                }
            }; 

            this.tbToolbar.Buttons.AddRange( new[]{
                tbbNew, tbbOpen, tbbSave,
                tbbImport, tbbExport,
                tbbSettings, tbbHelp, tbbAbout
            });

            this.Controls.Add( this.tbToolbar );
        }
        
        private void Build()
        {
            this.BuildIcons();
            this.BuildCanvas();
            this.BuildToolbar();
            this.BuildCanvas();
            this.BuildAboutPanel();
            
            this.SetMinimumSize();
            this.Text = AppInfo.Name;
            this.Closed += (o, evt) => this.DoQuit();
        }
        
        private void DoDrawing()
        {
            // Estimate sizes
            this.bmDrawArea = new Bitmap( DefaultDrawingAreaSize.Width, DefaultDrawingAreaSize.Height );
            this.pbCanvas.Image = bmDrawArea;
            this.sdDrawingBoard.InitGraphics( this.bmDrawArea );
            this.sdDrawingBoard.CalculateSizes();

            // Adjust
            Size drawingSize = this.sdDrawingBoard.Size;
            int width = Math.Max( DefaultDrawingAreaSize.Width, drawingSize.Width );
            int height = Math.Max( DefaultDrawingAreaSize.Height, drawingSize.Height );

            if ( width != 1024
                 || height != 1024 )
            {
                this.bmDrawArea = new Bitmap( width, height );
                this.pbCanvas.Image = bmDrawArea;
            }

            // Draw
            this.sdDrawingBoard.Draw( this.bmDrawArea );
            this.FocusOnInput();
        }

        private Panel pnlAbout;

        private ToolBar tbToolbar;
        private ToolBarButton tbbNew;
        private ToolBarButton tbbOpen;
        private ToolBarButton tbbSave;
        private ToolBarButton tbbImport;
        private ToolBarButton tbbExport;
        private ToolBarButton tbbSettings;
        private ToolBarButton tbbHelp;
        private ToolBarButton tbbAbout;
        
        private Bitmap mapIconBmp;
        private Bitmap newIconBmp;
        private Bitmap openIconBmp;
        private Bitmap saveIconBmp;
        private Bitmap importIconBmp;
        private Bitmap exportIconBmp;
        private Bitmap settingsIconBmp;
        private Bitmap helpIconBmp;
        private Bitmap aboutIconBmp;

        private Bitmap bmDrawArea;
        
        private Label lblStatus;
    }
}
