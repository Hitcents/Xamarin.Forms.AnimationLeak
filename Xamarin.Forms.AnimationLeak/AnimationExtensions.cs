using System;
using Xamarin.Forms;

namespace Xamarin.Forms.AnimationLeak
{
    public static class AnimationExtensions
    {
        /// <summary>
        /// This is so nasty, I feel gross.
        /// </summary>
        public static void AnimateSafely<T>(this T self, string name, Action<T, double> callback, double start, double end, uint rate = 16u, uint length = 250u, Easing easing = null, Action<T, double, bool> finished = null, Func<T, bool> repeat = null)
            where T : class, IAnimatable
        {
            var reference = new WeakReference(self);

            self.Animate(name,
                v =>
                {
                    var target = reference.Target as T;
                    if (target != null)
                        callback(target, v);
                },
            start, end, rate, length, easing, 
                finished == null ? 
                    default(Action<double, bool>) :
                    (a, b) =>
                    {
                        var target = reference.Target as T;
                        if (target != null)
                            finished(target, a, b);
                    },
                repeat == null ? 
                    default(Func<bool>) : 
                    () =>
                    {
                        var target = reference.Target as T;
                        if (target != null)
                            return repeat(target);
                        return false;
                    });
        }
    }
}

