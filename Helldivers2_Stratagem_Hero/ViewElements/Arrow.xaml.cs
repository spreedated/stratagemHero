using CommunityToolkit.Mvvm.ComponentModel;
using Helldivers2_Stratagem_Hero.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Helldivers2_Stratagem_Hero.ViewElements
{
    [ObservableObject]
    public partial class Arrow : UserControl
    {
        public static readonly DependencyProperty DirectionProperty = DependencyProperty.Register("Direction", typeof(Stratagem.StratagemKey.Directions), typeof(Arrow));

        public Stratagem.StratagemKey.Directions Direction
        {
            get => (Stratagem.StratagemKey.Directions)this.GetValue(DirectionProperty);
            set
            {
                this.SetValue(DirectionProperty, value);
                switch (this.Direction)
                {
                    case Stratagem.StratagemKey.Directions.Up:
                        this.RotateAngle = 0d;
                        break;
                    case Stratagem.StratagemKey.Directions.Down:
                        this.RotateAngle = 180d;
                        break;
                    case Stratagem.StratagemKey.Directions.Left:
                        this.RotateAngle = 270d;
                        break;
                    case Stratagem.StratagemKey.Directions.Right:
                        this.RotateAngle = 90d;
                        break;
                    default:
                        break;
                }
            }
        }

        public static readonly DependencyProperty IsPressedProperty = DependencyProperty.Register("IsPressed", typeof(bool), typeof(Arrow));

        public bool IsPressed
        {
            get => (bool)this.GetValue(IsPressedProperty);
            set
            {
                this.SetValue(IsPressedProperty, value);
                this.SetArrowUri();
            }
        }

        [ObservableProperty]
        private Uri arrowUri = new("pack://application:,,,/resources/images/arrows/arrow.png");
        [ObservableProperty]
        private double rotateAngle = 0d;

        public Arrow()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        private void SetArrowUri()
        {
            this.ArrowUri = new($"pack://application:,,,/resources/images/arrows/arrow{(this.IsPressed ? "_pressed" : "")}.png");
        }
    }
}
