﻿using Microsoft.Kinect;
using System;
using System.Windows.Forms;

namespace Fizbin.Kinect.Gestures.Segments
{
    /// <summary>
    /// The first part of the lean left gesture
    /// </summary>
    public class LeanForwardSegment1 : IRelativeGestureSegment
    {
        /// <summary>
        /// Checks the gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
        public GesturePartResult CheckGesture(Skeleton skeleton)
        {
            // hands are below hips
            if (skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.HipCenter].Position.Y && skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.HipCenter].Position.Y)
            {
                // shoulders are outside of hips
                if (skeleton.Joints[JointType.ShoulderRight].Position.X > skeleton.Joints[JointType.HipRight].Position.X && skeleton.Joints[JointType.ShoulderLeft].Position.X < skeleton.Joints[JointType.HipLeft].Position.X)
                {
                    // shoulder center must be forward of hip center
                    if (skeleton.Joints[JointType.ShoulderCenter].Position.Z < skeleton.Joints[JointType.HipCenter].Position.Z)
                    {
                        return GesturePartResult.Succeed;
                    }
                    return GesturePartResult.Pausing;
                }
                return GesturePartResult.Fail;
            }
            return GesturePartResult.Fail;
        }
    }

    /// <summary>
    /// The second part of the lean left gesture
    /// </summary>
    public class LeanForwardSegment2 : IRelativeGestureSegment
    {
        /// <summary>
        /// Checks the gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
        public GesturePartResult CheckGesture(Skeleton skeleton)
        {
            // hands are below hips
            if (skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.HipCenter].Position.Y && skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.HipCenter].Position.Y)
            {
                // left shoulder must be right of left hip

                // FINISH THIS GESTURE SEGMENT: (FOR Z AXIS)

                if (skeleton.Joints[JointType.ShoulderLeft].Position.X > skeleton.Joints[JointType.HipLeft].Position.X)
                {
                    return GesturePartResult.Succeed;
                }
                return GesturePartResult.Fail;
            }
            return GesturePartResult.Fail;
        }
    }
}