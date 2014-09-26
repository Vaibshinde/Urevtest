﻿#region licence
// The MIT License (MIT)
// 
// Filename: CommsTestActionDto.cs
// Date Created: 2014/06/01
// 
// Copyright (c) 2014 Jon Smith (www.selectiveanalytics.com & www.thereformedprogrammer.net)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion
using System.ComponentModel.DataAnnotations;
using GenericServices.Core;

namespace ServiceLayer.TestActionService.Concrete
{

    /// <summary>
    /// This is a copy of CommsTestActionDto just so we can try the TActionData to TDto versions
    /// </summary>
    public class CommsTestActionDto : InstrumentedEfGenericDto<CommsTestActionData, CommsTestActionDto>
    {
        private double _secondsBetweenIterations = 1;
        private int _numIterations = 5;

        [UIHint("Enum")]
        public TestServiceModes Mode { get; set; }

        public bool FailToRespondToCancel { get; set; }

        public int NumErrorsToExitWith { get; set; }

        [Range(0, 100)]
        public double SecondsBetweenIterations
        {
            get { return _secondsBetweenIterations; }
            set { _secondsBetweenIterations = value; }
        }

        public int NumIterations
        {
            get { return _numIterations; }
            set { _numIterations = value; }
        }

        public double SecondsDelayToRespondingToCancel { get; set; }

        protected override ServiceFunctions SupportedFunctions
        {
            get { return ServiceFunctions.DoAction; }
        }
    }
}