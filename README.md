# Xamarin.Forms.AnimationLeak
Project reproducing a memory leak with animations

The issue here is doing:
```csharp
this.Animation(repeat: () => true);
```
This would be for an idle animation you want to repeat forever.

Run this sample and click the button to add an animation. It will log `WeakReference` objects to Debug output so you can see what is leaking. (NOTE: there are comments showing a case that works as well)

So the question is:
- Is this a bug in forms, the fact that this causes a leak?
- Is `repeat: () => true` a terrible idea? Is there a better way to make it quit? Many times this would be inside a `View` so `Page` events aren't an option.
- Is `OnParentSet` a reasonable event to start/stop the animation? The big issue is if your parent is what gets removed `OnParentSet` does not get called.

# Possible Fix

[Here](https://github.com/Hitcents/Xamarin.Forms.AnimationLeak/pull/1/files) is a possible fix. But it is gross, so I'm not a big fan of using this throughout our app.
