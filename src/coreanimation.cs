//
// coreanimation.cs: API definition for CoreAnimation binding
//
// Authors:
//   Geoff Norton
//   Miguel de Icaza
//
// Copyright 2009, Novell, Inc.
// Copyright 2010, Novell, Inc.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Drawing;
#if MONOMAC
using MonoMac.AppKit;
#else
using MonoMac.UIKit;
#endif
using MonoMac.Foundation;
using MonoMac.CoreGraphics;
using MonoMac.ObjCRuntime;

namespace MonoMac.CoreAnimation {

#if false
	interface CAMediaTiming {
		[Export ("beginTime")]
		double CFTimeInterval { get; set; }
	
		[Export ("duration")]
		double Duration { get; set; }
	
		[Export ("speed")]
		float Speed { get; set; }
	
		[Export ("timeOffset")]
		double TimeOffset { get; set; }
	
		[Export ("repeatCount")]
		float RepeatCount { get; set; }
	
		[Export ("repeatDuration")]
		double RepeatDuration { get; set; }
	
		[Export ("autoreverses")]
		bool AutoReverses { get;set; }
	
		[Export ("fillMode")]
		string FillMode { get; set; }
	}		
#endif

	[BaseType (typeof (NSObject))]
	interface CADisplayLink {
		[Export ("displayLinkWithTarget:selector:")][Static]
		CADisplayLink Create (NSObject target, Selector sel);
	
		[Export ("addToRunLoop:forMode:")]
		void AddToRunLoop (NSRunLoop runloop, string mode);
	
		[Export ("removeFromRunLoop:forMode:")]
		void RemoveFromRunLoop (NSRunLoop runloop, string  mode);
	
		[Export ("invalidate")]
		void Invalidate ();
	
		[Export ("timestamp")]
		double Timestamp { get; }
	
		[Export ("paused")]
		bool Paused { [Bind ("isPaused")] get; set; }
	
		[Export ("frameInterval")]
		int FrameInterval { get; set;  }
	}

	[BaseType (typeof (NSObject))]
	interface CALayer {
		[Export ("layer")][Static]
		CALayer Create ();

		[Export ("presentationLayer")]
		CALayer PresentationLayer { get; }

		[Export ("modelLayer")]
		CALayer ModelLayer { get; }

		[Static]
		[Export ("defaultValueForKey:")]
		NSObject DefaultValue (string key);

		[Static]
		[Export ("needsDisplayForKey:")]
		bool NeedsDisplayForKey (string key);

		[Export ("bounds")]
		RectangleF Bounds  { get; set; }

		[Export ("zPosition")]
		float ZPosition { get; set; }
		
		[Export ("anchorPoint")]
		PointF AnchorPoint { get; set; }

		[Export ("anchorPointZ")]
		float AnchorPointZ { get; set; }
		
		[Export ("position")]
		PointF Position { get; set; }

		[Export ("transform")]
		CATransform3D Transform { get; set; }

		[Export ("affineTransform")]
		CGAffineTransform AffineTransform { get; set; }

		[Export ("frame")]
		RectangleF Frame { get; set; }

		[Export ("hidden")] // Setter needs setHidden instead
		bool Hidden { [Bind ("isHidden")] get; set; }  

		[Export ("doubleSided")]  // Setter needs setDoubleSided
		bool DoubleSided { [Bind ("isDoubleSided")] get; set; }

		[Export ("geometryFlipped")]
		bool GeometryFlipped { [Bind ("isGeometryFlipped")] get; set; }

		[Export ("contentsAreFlipped")]
		bool ContentsAreFlipped { get; }

		[Export ("superlayer")]
		CALayer SuperLayer { get; }

		[Export ("removeFromSuperlayer")]
		void RemoveFromSuperLayer ();

		[Export ("sublayers", ArgumentSemantic.Copy)]
		CALayer [] Sublayers { get; set; }
		
		[Export ("addSublayer:")][PostGet ("Sublayers")]
		void AddSublayer (CALayer layer);

		[Export ("insertSublayer:atIndex:")][PostGet ("Sublayers")]
		void InsertSublayer (CALayer layer, int index);

		[Export ("insertSublayer:below:")][PostGet ("Sublayers")]
		void InsertSublayerBelow (CALayer layer, CALayer sibling);
		
		[Export ("insertSublayer:above:")][PostGet ("Sublayers")]
		void InsertSublayerAbove (CALayer layer, CALayer sibling);

		[Export ("replaceSublayer:with:")][PostGet ("Sublayers")]
		void ReplaceSublayer (CALayer layer, CALayer with);

		[Export ("sublayerTransform")]
		CATransform3D SublayerTransform { get; set; }

		[Export ("mask", ArgumentSemantic.Retain)]
		CALayer Mask { get; set; }

		[Export ("masksToBounds")]
		bool MasksToBounds { get; set; }

		[Export ("convertPoint:fromLayer:")]
		PointF ConvertPointFromLayer (PointF point, CALayer layer);
		
		[Export ("convertPoint:toLayer:")]
		PointF ConvertPointToLayer (PointF point, CALayer layer);
		
		[Export ("convertRect:fromLayer:")]
		RectangleF ConvertRectfromLayer (RectangleF rect, CALayer layer);
		
		[Export ("convertRect:toLayer:")]
		RectangleF ConvertRectToLayer (RectangleF rect, CALayer layer);

		[Export ("convertTime:fromLayer:")]
		double ConvertTimeFromLayer (double rect, [NullAllowed] CALayer layer);
		
		[Export ("convertTime:toLayer:")]
		double ConvertTimeToLayer (double t, CALayer layer);

		[Export ("hitTest:")]
		CALayer HitTest (PointF p);

		[Export ("containsPoint:")]
		bool Contains (PointF p);

		[Export ("contents", ArgumentSemantic.Retain)]
		CGImage Contents { get; set; }

#if !MONOMAC
		[Export ("contentsScale")]
		float ContentsScale { get; set; }
#endif

		[Export ("contentsRect")]
		RectangleF ContentsRect { get; set; }

		[Export ("contentsGravity", ArgumentSemantic.Copy)]
		string ContentsGravity { get; set; }

		[Export ("contentsCenter")]
		RectangleF ContentsCenter { get; set; }

		[Export ("minificationFilter", ArgumentSemantic.Copy)]
		string MinificationFilter { get; set; }
		
		[Export ("magnificationFilter", ArgumentSemantic.Copy)]
		string MagnificationFilter { get; set; }

		[Export ("opaque")]
		bool Opaque { [Bind ("isOpaque")] get; set; }

		[Export ("display")]
		void Display ();

		[Export ("needsDisplay")]
		bool NeedsDisplay { get; }

		[Export ("setNeedsDisplay")]
		void SetNeedsDisplay ();

		[Export ("setNeedsDisplayInRect:")]
		void SetNeedsDisplayInRect (RectangleF r);

		[Export ("displayIfNeeded")]
		void DisplayIfNeeded ();

		[Export ("needsDisplayOnBoundsChange")]
		bool NeedsDisplayOnBoundsChange { get; set; }

		[Export ("drawInContext:")]
		void DrawInContext (CGContext ctx);

		[Export ("renderInContext:")]
		void RenderInContext (CGContext ctx);

		[Export ("backgroundColor")]
		CGColor BackgroundColor { get; set; }

		[Export ("cornerRadius")]
		float CornerRadius { get; set; }

		[Export ("borderWidth")]
		float BorderWidth { get; set; }

		[Export ("borderColor")]
		CGColor BorderColor { get; set; }

		[Export ("opacity")]
		float Opacity { get; set; }

		[Export ("edgeAntialiasingMask")]
		CAEdgeAntialiasingMask EdgeAntialiasingMask { get; set; }

		// Layout methods

		[Export ("preferredFrameSize")]
		SizeF PreferredFrameSize ();

		[Export ("setNeedsLayout")]
		void SetNeedsLayout ();

		[Export ("needsLayout")]
		bool NeedsLayout ();

		[Export ("layoutIfNeeded")]
		void LayoutIfNeeded ();

		[Export ("layoutSublayers")]
		void LayoutSublayers ();

		[Export ("defaultActionForKey:")]
		CAAction DefaultActionForKey (string eventKey);

		[Export ("actionForKey:")]
		CAAction ActionForKey (string eventKey);

		[Export ("actions", ArgumentSemantic.Copy)]
		CAAction [] Actions { get; set; }

		[Export ("addAnimation:forKey:")]
		void AddAnimation (CAAnimation animation, [NullAllowed] string key);
		
		[Export ("removeAllAnimations")]
		void RemoveAllAnimations ();

		[Export ("removeAnimationForKey:")]
		void RemoveAnimation (string key);

		[Export ("animationKeys")]
		string [] AnimationKeys { get; }

		[Export ("animationForKey:")]
		CAAnimation AnimationForKey (string key);

		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		CALayerDelegate Delegate { get; set; }
		
		//
		// From CAMediaTiming
		//
		[Export ("beginTime")]
		double BeginTime { get; set; }
	
		[Export ("duration")]
		double Duration { get; set; }
	
		[Export ("speed")]
		float Speed { get; set; }
	
		[Export ("timeOffset")]
		double TimeOffset { get; set; }
	
		[Export ("repeatCount")]
		float RepeatCount { get; set; }
	
		[Export ("repeatDuration")]
		double RepeatDuration { get; set; }
	
		[Export ("autoreverses")]
		bool AutoReverses { get;set; }
	
		[Export ("fillMode")]
		string FillMode { get; set; }

		[Since (3,2)]
		[Export ("shadowColor")]
		CGColor ShadowColor { get; set; }

		[Since (3,2)]
		[Export ("shadowOffset")]
		SizeF ShadowOffset { get; set; }

		[Since (3,2)]
		[Export ("shadowOpacity")]
		float ShadowOpacity { get; set; }

		[Since (3,2)]
		[Export ("shadowRadius")]
		float ShadowRadius { get; set; }

		[Field ("kCATransition")]
		NSString Transition { get; } 

		[Field ("kCAGravityCenter")]
		NSString GravityCenter { get; }

		[Field ("kCAGravityTop")]
		NSString GravityTop { get; }

		[Field ("kCAGravityBottom")]
		NSString GravityBottom { get; }

		[Field ("kCAGravityLeft")]
		NSString GravityLeft { get; }

		[Field ("kCAGravityRight")]
		NSString GravityRight { get; }

		[Field ("kCAGravityTopLeft")]
		NSString GravityTopLeft { get; }

		[Field ("kCAGravityTopRight")]
		NSString GravityTopRight { get; }

		[Field ("kCAGravityBottomLeft")]
		NSString GravityBottomLeft { get; }

		[Field ("kCAGravityBottomRight")]
		NSString GravityBottomRight { get; }

		[Field ("kCAGravityResize")]
		NSString GravityResize { get; }

		[Field ("kCAGravityResizeAspect")]
		NSString GravityResizeAspect { get; }

		[Field ("kCAGravityResizeAspectFill")]
		NSString GravityResizeAspectFill { get; }

		[Field ("kCAFilterNearest")]
		NSString FilterNearest { get; }

		[Field ("kCAFilterLinear")]
		NSString FilterLinear { get; }

		[Field ("kCAFilterTrilinear")]
		NSString FilterTrilinear { get; }

		[Field ("kCAOnOrderIn")]
		NSString OnOrderIn { get; }

		[Field ("kCAOnOrderOut")]
		NSString OnOrderOut { get; }

		[Export ("visibleRect")]
		RectangleF VisibleRect { get;  }

		[Export ("scrollPoint:")]
		void ScrollPoint (PointF p);

		[Export ("scrollRectToVisible:")]
		void ScrollRectToVisible (RectangleF r);

#if MONOMAC
		[Export ("autoresizingMask")]
		CAAutoresizingMask AutoresizinMask { get; set; }

		[Export ("resizeSublayersWithOldSize")]
		void ResizeSublayers (SizeF oldSize);

		[Export ("resizeWithOldSuperlayerSize:")]
		void Resize (SizeF oldSuperlayerSize);
#else
		[Since (3,2)]
		[Export ("shouldRasterize")]
		bool ShouldRasterize { get; set; }

		[Since (3,2)]
		[Export ("shadowPath")]
		CGPath ShadowPath { get; set; }

		[Since (3,2)]
		[Export ("rasterizationScale")]
		float RasterizationScale { get; set; }
#endif
	}

	[BaseType (typeof (CALayer))]
	interface CATiledLayer {
		[Static][Export ("fadeDuration")]
		double FadeDuration { get; set; }

		[Export ("levelsOfDetail")]
		int LevelsOfDetail { get; set; }

		[Export ("levelsOfDetailBias")]
		int LevelsOfDetailBias { get; set; }

		[Export ("tileSize")]
		SizeF TileSize { get; set; }
	}

	[BaseType (typeof (CALayer))]
	interface CAReplicatorLayer {
		[Export ("instanceCount")]
		int InstanceCount { get; set; }

		[Export ("instanceDelay")]
		double InstanceDelay { get; set; }

		[Export ("instanceTransform")]
		CATransform3D InstanceTransform { get; set; }

		[Export ("preservesDepth")]
		bool PreservesDepth { get; set; }

		[Export ("instanceColor")]
		CGColor InstanceColor { get; set; }

		[Export ("instanceRedOffset")]
		float InstanceRedOffset { get; set; }

		[Export ("instanceGreenOffset")]
		float InstanceGreenOffset { get; set; }

		[Export ("instanceBlueOffset")]
		float InstanceBlueOffset { get; set; }

		[Export ("instanceAlphaOffset")]
		float InstanceAlphaOffset { get; set; }
	}


	[BaseType (typeof (CALayer))]
	interface CAScrollLayer {
		[Export ("scrollMode")]
		string scrollMode { get; set;  }

		[Export ("scrollToPoint:")]
		void ScrollToPoint (PointF p);

		[Export ("scrollToRect:")]
		void ScrollToRect (RectangleF r);
	}
	
	[BaseType (typeof (CALayer))]
	interface CAShapeLayer {
		[Export ("path")]
		CGPath Path { get; set; }

		[Export ("fillColor")]
		CGColor FillColor { get; set; }

		[Export ("fillRule", ArgumentSemantic.Copy)]
		string FillRule { get; set; }

		[Export ("lineCap", ArgumentSemantic.Copy)]
		string LineCap { get; set; }

		[Export ("lineDashPattern", ArgumentSemantic.Copy)]
		NSNumber [] LineDashPattern { get; set; }

		[Export ("lineDashPhase")]
		float LineDashPhase { get; set; }

		[Export ("lineJoin", ArgumentSemantic.Copy)]
		string LineJoin { get; set; }

		[Export ("lineWidth")]
		float LineWidth { get; set; }

		[Export ("miterLimit")]
		float MiterLimit { get; set; }

		[Export ("strokeColor")]
		CGColor StrokeColor { get; set; }
	}

	[BaseType (typeof (CALayer))]
	interface CATransformLayer {
		[Export ("hitTest:")]
		CALayer HitTest (PointF thePoint);
	}

	[Since (3,2)]
	[BaseType (typeof (CALayer))]
	interface CATextLayer {
		[Export ("string", ArgumentSemantic.Copy)]
		string String { get; set; }

		[Export ("fontSize")]
		float FontSize { get; set; }
		
		[Export ("foregroundColor")]
		CGColor ForegroundColor { get; set; }

                [Export ("wrapped")]
                bool Wrapped { [Bind ("isWrapped")] get; set; }

		[Export ("truncationMode", ArgumentSemantic.Copy)]
		string TruncationMode { get; set; }

		[Export ("alignmentMode", ArgumentSemantic.Copy)]
		string AlignmentMode { get; set; }

		[Field ("kCATruncationNone")]
		NSString TruncationNone { get; }
		
		[Field ("kCATruncationStart")]
		NSString TruncantionStart { get; }
		
		[Field ("kCATruncationEnd")]
		NSString TruncantionEnd { get; }
		
		[Field ("kCATruncationMiddle")]
		NSString TruncantionMiddle { get; }
		
		[Field ("kCAAlignmentNatural")]
		NSString AlignmentNatural { get; }
		
		[Field ("kCAAlignmentLeft")]
		NSString AlignmentLeft { get; }
		
		[Field ("kCAAlignmentRight")]
		NSString AlignmentRight { get; }
		
		[Field ("kCAAlignmentCenter")]
		NSString AlignmentCenter { get; }
		
		[Field ("kCAAlignmentJustified")]
		NSString AlignmentJustified { get; }
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface CALayerDelegate {
		[Export ("displayLayer:")]
		void DisplayLayer (CALayer layer);

		[Export ("drawLayer:inContext:"), EventArgs ("CALayerDrawEventArgs")]
		void DrawLayer (CALayer layer, CGContext context);

		[Export ("layoutSublayersOfLayer:")]
		void LayoutSublayersOfLayer (CALayer layer);

		[Export ("actionForLayer:forKey:"), EventArgs ("CALayerDelegateAction"), DefaultValue (null)]
		CAAction ActionForLAyer (CALayer layer, string eventKey);
	}
	
	[BaseType (typeof (CALayer))]
	interface CAEAGLLayer {
		// From the interface  IEAGLDrawable
		[Export ("drawableProperties", ArgumentSemantic.Copy)]
		NSDictionary DrawableProperties { get; set; }
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface CAAction {
		[Export ("runActionForKey:object:arguments:")]
		void RunAction (string eventKey, NSObject obj, NSDictionary arguments);
	}
	
	[BaseType (typeof (NSObject), Delegates=new string [] {"WeakDelegate"}, Events=new Type [] { typeof (CAAnimationDelegate)})]
	interface CAAnimation {
		[Export ("animation"), Static]
		CAAnimation CreateAnimation ();
	
		[Static]
		[Export ("defaultValueForKey:")]
		NSObject DefaultValue (string key);
	
		[Export ("timingFunction", ArgumentSemantic.Retain)]
		CAMediaTimingFunction TimingFunction { get; set; }
	
		[Wrap ("WeakDelegate")]
		CAAnimationDelegate Delegate { get; set; }
	
		[Export ("delegate", ArgumentSemantic.Retain)][NullAllowed]
		NSObject WeakDelegate { get; set; }
	
		[Export ("removedOnCompletion")]
		bool RemovedOnCompletion { [Bind ("isRemovedOnCompletion")] get; set; }

		[Export ("willChangeValueForKey:")]
		void WillChangeValueForKey (string key);
	
		[Export ("didChangeValueForKey:")]
		void DidChangeValueForKey (string key);

		[Export ("shouldArchiveValueForKey:")]
		[Since (4,0)]
		bool ShouldArchiveValueForKey (string key);

		//
		// From CAMediaTiming
		//
		[Export ("beginTime")]
		double BeginTime { get; set; }
	
		[Export ("duration")]
		double Duration { get; set; }
	
		[Export ("speed")]
		float Speed { get; set; }
	
		[Export ("timeOffset")]
		double TimeOffset { get; set; }
	
		[Export ("repeatCount")]
		float RepeatCount { get; set; }
	
		[Export ("repeatDuration")]
		double RepeatDuration { get; set; }
	
		[Export ("autoreverses")]
		bool AutoReverses { get;set; }
	
		[Export ("fillMode")]
		string FillMode { get; set; }

		[Field ("kCATransitionFade")]
		NSString TransitionFade { get; }
		
		[Field ("kCATransitionMoveIn")]
		NSString TransitionMoveIn { get; }

		[Field ("kCATransitionPush")]
		NSString TransitionPush { get; }
		
		[Field ("kCATransitionReveal")]
		NSString TransitionReveal { get; }
		
		[Field ("kCATransitionFromRight")]
		NSString TransitionFromRight { get; }
		
		[Field ("kCATransitionFromLeft")]
		NSString TransitionFromLeft { get; }

		[Field ("kCATransitionFromTop")]
		NSString TransitionFromTop { get; }

		[Field ("kCATransitionFromBottom")]
		NSString TransitionFromBottom { get; }
	}
	
	[BaseType (typeof (NSObject))]
	[Model]
	interface CAAnimationDelegate {
		[Export ("animationDidStart:")]
		void AnimationStarted (CAAnimation anim);
	
		[Export ("animationDidStop:finished:"), EventArgs ("CAAnimationState")]
		void AnimationStopped (CAAnimation anim, bool finished);
	
	}
	
	[BaseType (typeof (CAAnimation))]
	interface CAPropertyAnimation {
		[Static]
		[Export ("animationWithKeyPath:")]
		CAPropertyAnimation FromKeyPath (string path);
	
		[Export ("keyPath", ArgumentSemantic.Copy)]
		string KeyPath { get; set; }
	
		[Export ("additive")]
		bool Additive { [Bind ("isAdditive")] get; set; }
	
		[Export ("cumulative")]
		bool Cumulative { [Bind ("isCumulative")] get; set; }
	
		[Export ("valueFunction", ArgumentSemantic.Retain)]
		CAValueFunction ValueFunction { get; set; }
	
	}
	
	[BaseType (typeof (CAPropertyAnimation))]
	interface CABasicAnimation {
		[Static, New, Export ("animationWithKeyPath:")]
		CABasicAnimation FromKeyPath (string path);

		[Export ("fromValue", ArgumentSemantic.Retain)][NullAllowed]
		NSObject From { get; set; }
	
		[Export ("toValue", ArgumentSemantic.Retain)][NullAllowed]
		NSObject To { get; set; }
	
		[Export ("byValue", ArgumentSemantic.Retain)][NullAllowed]
		NSObject By { get; set; }
	}
	
	[BaseType (typeof (CAPropertyAnimation), Name="CAKeyframeAnimation")]
	interface CAKeyFrameAnimation {
		[Static, New, Export ("animationWithKeyPath:")]
		CAPropertyAnimation FromKeyPath (string path);

		[Export ("values", ArgumentSemantic.Copy)]
		NSObject [] Values { get; set; }
	
		[Export ("path")][Internal]
		IntPtr _Path { get; set; }
	
		[Export ("keyTimes", ArgumentSemantic.Copy)][NullAllowed]
		NSNumber [] KeyTimes { get; set; }
	
		[Export ("timingFunctions", ArgumentSemantic.Copy)]
		CAMediaTimingFunction [] TimingFunctions { get; set; }
	
		[Export ("calculationMode", ArgumentSemantic.Copy)]
		string CalculationMode { get; set; }
	
		[Export ("rotationMode", ArgumentSemantic.Copy)][NullAllowed]
		string RotationMode { get; set; }

		[Field ("kCAAnimationLinear")]
		NSString CalculationLinear { get; }

		[Field ("kCAAnimationDiscrete")]
		NSString CalculationDiscrete { get; }
		
		[Field ("kCAAnimationDiscrete")]
		NSString CalculationPaced { get; }
	}
	
	[BaseType (typeof (CAAnimation))]
	interface CATransition {
		[Export ("animation"), Static, New]
		CATransition CreateAnimation ();

		[Export ("type", ArgumentSemantic.Copy)]
		string Type { get; set; }
	
		[Export ("subtype", ArgumentSemantic.Copy)]
		string Subtype { get; set; }
	
		[Export ("startProgress")]
		float StartProgress { get; set; }
	
		[Export ("endProgress")]
		float EndProgress { get; set; }
	
		[Export ("filter", ArgumentSemantic.Retain)][NullAllowed]
		NSObject filter { get; set; }
	}
	
	[BaseType (typeof (NSObject))]
	interface CATransaction {
		[Static]
		[Export ("begin")]
		void Begin ();
	
		[Static]
		[Export ("commit")]
		void Commit ();
	
		[Static]
		[Export ("flush")]
		void Flush ();
	
		[Static]
		[Export ("lock")]
		void Lock ();
	
		[Static]
		[Export ("unlock")]
		void Unlock ();
	
		[Static]
		[Export ("animationDuration")]
		double AnimationDuration { get; set; }
	
		[Static]
		[Export ("animationTimingFunction")]
		CAMediaTimingFunction AnimationTimingFunction { get; set; }
	
		[Static]
		[Export ("disableActions")]
		bool DisableActions { get; set; }
	
		[Static]
		[Export ("valueForKey:")]
		NSObject ValueForKey (NSString key);
	
		[Static]
		[Export ("setValue:forKey:")]
		void SetValueForKey (NSObject anObject, NSString key);

		[Since (4,0)]
		[Static, Export ("setCompletionBlock:")]
		NSAction CompletionBlock { set; }

		[Field ("kCATransactionAnimationDuration")]
		NSString AnimationDurationKey { get; }
		
		[Field ("kCATransactionDisableActions")]
		NSString DisableActionsKey { get; }
		
		[Field ("kCATransactionAnimationTimingFunction")]
		NSString TimingFunctionKey { get; }
		
		[Field ("kCATransactionCompletionBlock")]
		NSString CompletionBlockKey { get; }
	}

	[BaseType (typeof (CAAnimation))]
	interface CAAnimationGroup {
		[Export ("animations", ArgumentSemantic.Copy)]
		CAAnimation [] Animations { get; set; }

		[Export ("animation"), Static, New]
		CAAnimationGroup CreateAnimation ();
	}

	[BaseType (typeof (CALayer))]
	interface CAGradientLayer {
		[Export ("colors", ArgumentSemantic.Copy)][Internal]
		IntPtr _Colors { get; set;  }
	
		[Export ("locations", ArgumentSemantic.Copy)]
		NSNumber [] Locations { get; set;  }
	
		[Export ("startPoint")]
		PointF StartPoint { get; set;  }

		[Export ("endPoint")]
		PointF EndPoint { get; set;  }
	
		[Export ("type", ArgumentSemantic.Copy)]
		string Type { get; set;  }

		[Field ("kCAGradientLayerAxial")]
		NSString GradientLayerAxial { get; }
	}

	[BaseType (typeof (NSObject))]
	interface CAMediaTimingFunction {
		[Export ("functionWithName:")][Static]
		CAMediaTimingFunction FromName (string  name);
	
		[Static]
		[Export ("functionWithControlPoints::::")]
		CAMediaTimingFunction FromControlPoints (float c1x, float c1y, float c2x, float c2y);
	
		[Export ("initWithControlPoints::::")]
		IntPtr Constructor (float c1x, float c1y, float c2x, float c2y);
	
		//[Export ("getControlPointAtIndex:values:")]
		//void getControlPointAtIndex:values: (size_t idx, float[2] ptr);
	
		[Field("kCAMediaTimingFunctionLinear")]
		NSString Linear { get; }
		
		[Field("kCAMediaTimingFunctionEaseIn")]
		NSString EaseIn { get; }
		
		[Field("kCAMediaTimingFunctionEaseOut")]
		NSString EaseOut { get; }
		
		[Field("kCAMediaTimingFunctionEaseInEaseOut")]
		NSString EaseInEaseOut { get; }
	}

	[BaseType (typeof (NSObject))]
	interface CAValueFunction {
		[Export ("functionWithName:")]
		CAValueFunction FromName (string name);

		[Export ("name")]
		string Name { get; }

		[Field ("kCAValueFunctionRotateX")]
		NSString RotateX { get; }
		
		[Field ("kCAValueFunctionRotateY")]
		NSString RotateY { get; }
		
		[Field ("kCAValueFunctionRotateZ")]
		NSString RotateZ { get; }
		
		[Field ("kCAValueFunctionScale")]
		NSString Scale { get; }
		
		[Field ("kCAValueFunctionScaleX")]
		NSString ScaleX { get; }
		
		[Field ("kCAValueFunctionScaleY")]
		NSString ScaleY { get; }
		
		[Field ("kCAValueFunctionScaleZ")]
		NSString ScaleZ { get; }
		
		[Field ("kCAValueFunctionTranslate")]
		NSString Translate { get; }
		
		[Field ("kCAValueFunctionTranslateX")]
		NSString TranslateX { get; }
		
		[Field ("kCAValueFunctionTranslateY")]
		NSString TranslateY { get; }
		
		[Field ("kCAValueFunctionTranslateZ")]
		NSString TranslateZ { get; }
		
	}
}

