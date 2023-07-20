using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reactive;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoV2.Messengers;
using TodoV2.Models;
using TodoV2.Services;

namespace TodoV2.ViewModels
{
    public partial class AddItemViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string description = "";

        [ObservableProperty]
        private bool okEnabled = false;

        private TodoItemContext _todoItemContext;

        public AddItemViewModel()
        {


            _todoItemContext = App.Current.Services.GetService<TodoItemContext>();

        }

        partial void OnDescriptionChanging(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                OkEnabled = true;
            }
        }

        partial void OnDescriptionChanged(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                OkEnabled = false;
            }
        }

        public void OnOkClicked()
        {
            TodoItem todoItem = new TodoItem();
            todoItem.Description = Description;
            todoItem.IsChecked = false;

            _todoItemContext.Add(todoItem);
            _todoItemContext.SaveChanges();

            WeakReferenceMessenger.Default.Send(new ChangeViewMessage("list"));

        }

        public void OnCancelClicked()
        {

            WeakReferenceMessenger.Default.Send(new ChangeViewMessage("list"));

        }

    }
}
