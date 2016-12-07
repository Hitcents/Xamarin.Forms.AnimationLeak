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
                this.Animate(AnimationKey, v => _box.Rotation = v, 0d, 360d, repeat: () => true);
            }
            else
            {
                this.AbortAnimation(AnimationKey);
            }
        }
    }
}
