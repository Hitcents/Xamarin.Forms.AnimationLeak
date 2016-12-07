using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Xamarin.Forms.AnimationLeak
{
    public partial class SpinningView : ContentView
    {
        private string AnimationKey = "Spinning";

        public SpinningView()
        {
            InitializeComponent();
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();

            if (Parent != null)
            {
                _box.AnimateSafely(AnimationKey, (b, v) => b.Rotation = v, 0d, 360d, repeat: _ => true);
            }
            else
            {
                _box.AbortAnimation(AnimationKey);
            }
        }
    }
}
