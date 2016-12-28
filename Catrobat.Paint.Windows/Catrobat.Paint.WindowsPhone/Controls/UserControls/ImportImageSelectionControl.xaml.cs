using System;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

// Die Elementvorlage "Benutzersteuerelement" ist unter http://go.microsoft.com/fwlink/?LinkId=234236 dokumentiert.

namespace Catrobat.Paint.WindowsPhone.Controls.UserControls
{
    public sealed partial class ImportImageSelectionControl : UserControl
    {
        const double MIN_RECTANGLE_MOVE_HEIGHT = 50.0;
        const double MIN_RECTANGLE_MOVE_WIDTH = 50.0;
        bool _isModifiedRectangleMovement;

        public Rectangle ImportPictureRectangle { get; private set; }
        public Grid GridMain { get; private set; }
        public ImageBrush ImportImgBrush { get; private set; }

        public ImportImageSelectionControl()
        {
            this.InitializeComponent();

            ImportPictureRectangle = (Rectangle)RectangleShapeBaseControl.FindName("ImportPictureArea");
            GridMain = (Grid)RectangleShapeBaseControl.FindName("AreaToDrawGrid");

            ImportImgBrush = (ImageBrush)RectangleShapeBaseControl.FindName("importImgBrush");

            //GridMain.RenderTransform = _transformGridMain = new TransformGroup();
            PocketPaintApplication.GetInstance().ImportImageSelectionControl = this;
            setIsModifiedRectangleMovement = false;
        }

        public ImageBrush imageSourceOfRectangleToDraw
        {
            set
            {
                ImportPictureRectangle.Fill = value;
            }
            get
            {
                return ImportPictureRectangle.Fill as ImageBrush;
            }
        }      

        public void changeStrokeOfDrawingShape(Color color)
        {
            ImportPictureRectangle.Stroke = new SolidColorBrush(color);
        }

        public double setStrokeThicknessOfDrawingShape
        {
            get
            {
                return ImportPictureRectangle.StrokeThickness;
            }
            set
            {
                ImportPictureRectangle.StrokeThickness = value;
            }
        }

        public PenLineJoin strokeLineJoinOfRectangleToDraw
        {
            get
            {
                return ImportPictureRectangle.StrokeLineJoin;
            }
            set
            {
                ImportPictureRectangle.StrokeLineJoin = value;
            }
        }

        public void resetAppBarButtonRectangleSelectionControl(bool activated)
        {
            AppBarButton appBarButtonReset = PocketPaintApplication.GetInstance().PaintingAreaView.GetAppBarResetButton();
            if (appBarButtonReset != null)
            {
                appBarButtonReset.IsEnabled = activated;
            }
        }

        public bool setIsModifiedRectangleMovement
        {
            get
            {
                return _isModifiedRectangleMovement;
            }
            set
            {
                _isModifiedRectangleMovement = value;
            }
        }

        public Point getCenterPointOfSelectionControl()
        {
            return new Point(0, 0);
        }

        public ImageSource getImageSource()
        {
            return ((ImageBrush)ImportPictureRectangle.Fill).ImageSource;
        }
    }
}
