# Xamarin.Forms.AnimationLeak
Project reproducing a memory leak with animations

The issue here is doing:
```csharp
this.Animation(repeat: () => true);
```
This would be for an idle animation you want to repeat forever.

So the question is:
- Is this a bug in forms, the fact that this causes a leak?
- Is `repeat: () => true` a terrible idea? Is there a better way to make it quit? Many times this would be inside a `View` so `Page` events aren't an option.
