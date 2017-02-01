﻿//----------------------------------------------------------------------------
//  Copyright (C) 2004-2017 by EMGU Corporation. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using Emgu.Util;
using Emgu.CV.Structure;
using System.Runtime.InteropServices;

namespace Emgu.CV
{
    /// <summary>
    /// PCAFlow algorithm.
    /// </summary>
    public class OpticalFlowPCAFlow : UnmanagedObject, IDenseOpticalFlow
    {
        private IntPtr _algorithmPtr;

        /// <summary>
        /// Creates an instance of PCAFlow
        /// </summary>
        public OpticalFlowPCAFlow()
        {
            _ptr = CvInvoke.cveOptFlowPCAFlowCreate(ref _algorithmPtr);
        }

        /// <summary>
        /// Release the memory associated with this PCA Flow algorithm
        /// </summary>
        protected override void DisposeObject()
        {
            if (IntPtr.Zero != _ptr)
            {
                CvInvoke.cveDenseOpticalFlowRelease(ref _ptr);
            }
            _algorithmPtr = IntPtr.Zero;
        }

        /// <summary>
        /// Pointer to cv::Algorithm
        /// </summary>
        public IntPtr AlgorithmPtr { get { return _algorithmPtr; } }
        /// <summary>
        /// Pointer to native cv::DenseOpticalFlow
        /// </summary>
        public IntPtr DenseOpticalFlowPtr { get { return _ptr; } }
    }


    public static partial class CvInvoke
    {
        [DllImport(ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
        internal static extern IntPtr cveOptFlowPCAFlowCreate(ref IntPtr algorithm);
    }
}
