﻿using GalaSoft.MvvmLight.Command;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WorkFlow.Enums;
using WorkFlow.Interface;
using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WorkFlow.Impl;
using System.Diagnostics;
using WorkFlow.ViewModels;
using Windows.UI.Popups;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace WorkFlow.Controls.Workflow
{
    public sealed partial class ResultWorkflowItem : ExecutableNodeBase, IWorkFlowItem, INotifyPropertyChanged, IExecutableNode
    {
        public ResultWorkflowItem(FrameworkElement parent):base(parent)
        {
            this.InitializeComponent();
          
            base.Element = this;
            this.DataContext = this;
            this.RightTapped += WorkFlowItem_RightTapped;
            AddConnector(new ConnectorControl { Type = ConnectorType.In, Label = "Input", Height = 25, Width = 25, WorkFlowItem = this });
            OnExecuteAction = async input => {
                var dialog = new MessageDialog(input.ToString());
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal,async () => await dialog.ShowAsync() ); 
                return null;
            };
        }

      
        private void WorkFlowItem_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            e.Handled = true;
            
            //this.magic += Window.Current.CoreWindow.GetKeyState(VirtualKey.Control).HasFlag(CoreVirtualKeyStates.Down)?  -1:1;
            //Move(GetPosition());
        }


        
      


       

     
    }
}
