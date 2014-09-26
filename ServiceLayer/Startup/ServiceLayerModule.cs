﻿#region licence
// The MIT License (MIT)
// 
// Filename: ServiceLayerModule.cs
// Date Created: 2014/05/20
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
using System;
using Autofac;
using BizLayer.Startup;
using DataLayer.Startup;
using GenericServices;
using GenericServices.Services;
using GenericServices.ServicesAsync;

namespace ServiceLayer.Startup
{
    public class ServiceLayerModule : Module
    {

        /// <summary>
        /// This registers all items in service layer and below
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {

            //Now register the DataLayer
            builder.RegisterModule(new DataLayerModule());

            //Reigister the BizLayer
            builder.RegisterModule(new BizLayerModule());

            //---------------------------
            //Register service layer: autowire all 
            builder.RegisterAssemblyTypes(GetType().Assembly).AsImplementedInterfaces();

            //and register the GenericServices assembly
            builder.RegisterAssemblyTypes(typeof(IListService).Assembly).AsImplementedInterfaces();
            
            //builder.RegisterGeneric(typeof(CreateService<>)).As(typeof(ICreateService<>));
            //builder.RegisterGeneric(typeof(DeleteService<>)).As(typeof(IDeleteService<>));
            //builder.RegisterGeneric(typeof(DetailService<>)).As(typeof(IDetailService<>));
            //builder.RegisterGeneric(typeof(ListService<>)).As(typeof(IListService<>));
            //builder.RegisterGeneric(typeof(UpdateService<>)).As(typeof(IUpdateService<>));

            //builder.RegisterGeneric(typeof(CreateServiceAsync<>)).As(typeof(ICreateServiceAsync<>));
            //builder.RegisterGeneric(typeof(DeleteServiceAsync<>)).As(typeof(IDeleteServiceAsync<>));
            //builder.RegisterGeneric(typeof(DetailServiceAsync<>)).As(typeof(IDetailServiceAsync<>));
            //builder.RegisterGeneric(typeof(UpdateServiceAsync<>)).As(typeof(IUpdateServiceAsync<>));

            //builder.RegisterGeneric(typeof(CreateService<,>)).As(typeof(ICreateService<,>));
            //builder.RegisterGeneric(typeof(CreateSetupService<,>)).As(typeof(ICreateSetupService<,>));
            //builder.RegisterGeneric(typeof(DetailService<,>)).As(typeof(IDetailService<,>));
            //builder.RegisterGeneric(typeof(ListService<,>)).As(typeof(IListService<,>));
            //builder.RegisterGeneric(typeof(UpdateService<,>)).As(typeof(IUpdateService<,>));
            //builder.RegisterGeneric(typeof(UpdateSetupService<,>)).As(typeof(IUpdateSetupService<,>));

            //builder.RegisterGeneric(typeof(CreateServiceAsync<,>)).As(typeof(ICreateServiceAsync<,>));
            //builder.RegisterGeneric(typeof(CreateSetupServiceAsync<,>)).As(typeof(ICreateSetupServiceAsync<,>));
            //builder.RegisterGeneric(typeof(DetailServiceAsync<,>)).As(typeof(IDetailServiceAsync<,>));
            //builder.RegisterGeneric(typeof(UpdateServiceAsync<,>)).As(typeof(IUpdateServiceAsync<,>));
            //builder.RegisterGeneric(typeof(UpdateSetupServiceAsync<,>)).As(typeof(IUpdateSetupServiceAsync<,>));

        }

    }
}
