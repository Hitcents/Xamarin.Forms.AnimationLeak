using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Xamarin.Forms.AnimationLeak
{
    public partial class MainPage : ContentPage
    {
        private List<WeakReference> _references = new List<WeakReference>();

        public MainPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, EventArgs e)
        {
            LogWeakReferences();

            //NOTE: if we just do this, there is no memory leak because of SpinnerView.OnParentSet()
            //var view = new SpinningView();

            //NOTE: unfortunately if you have a deep hierarchy in your app, more likely this would happen (the parent gets unparented instead of the child)
            var view = new ContentView { Content = new SpinningView() };

            _references.Add(new WeakReference(view));
            _content.Content = view;
        }

        async void LogWeakReferences()
        {
            //Forces GC before we log the references
            GC.Collect();
            await Task.Delay(100);
            GC.Collect();

            Debug.WriteLine("Weak References: " + _references.Count);
            for (int i = 0; i < _references.Count; i++)
            {
                Debug.WriteLine("IsAlive: " + _references[i].IsAlive);
            }
            Debug.WriteLine("---------------------------------------");
        }
    }
}
