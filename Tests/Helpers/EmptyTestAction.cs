﻿#region licence
// The MIT License (MIT)
// 
// Filename: EmptyTestAction.cs
// Date Created: 2014/06/26
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
using DataLayer.DataClasses.Concrete;
using GenericServices;
using GenericServices.ActionComms;
using GenericServices.Core;

namespace Tests.Helpers
{
    public interface IEmptyTestAction : IActionCommsSync<int, Tag>
    {
    }

    public class EmptyTestAction : ActionCommsBase, IEmptyTestAction
    {

        /// <summary>
        /// If true then the caller should call EF SubmitChanges if the method exited with status IsValid and
        /// it looks to see if the data part has a ICheckIfWarnings and if the WriteEvenIfWarning is false
        /// and there are warnings then it does not call SubmitChanges
        /// </summary>
        public override bool SubmitChangesOnSuccess { get { return false; } }

        /// <summary>
        /// This allows the action to configure what it supports, which then affects what the user sees
        /// Note: it must be a constant as it is read just after the action is created
        /// </summary>
        public override ActionFlags ActionConfig
        {
            get { return ActionFlags.NoProgressSent | ActionFlags.NoMessagesSent | ActionFlags.CancelNotSupported; }
        }

        //-------------------------------------------

        public ISuccessOrErrors<int> DoAction(IActionComms actionComms, Tag actionData)
        {
            ISuccessOrErrors<int> status = new SuccessOrErrors<int>();

            //we use the TagId for testing
            //0 means success
            //1 means success, but with warning
            //2 and above mean fail

            if (actionData.TagId == 1)
                status.AddWarning("This is a warning message");

            return actionData.TagId <= 1
                ? status.SetSuccessWithResult(actionData.TagId, "Successful")
                : status.AddSingleError("forced fail");
        }
    }
}