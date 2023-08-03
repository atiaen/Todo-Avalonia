using Avalonia.Interactivity;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using TodoV2.Models;

namespace TodoV2.ViewModels
{
    public partial class TodoListViewModel : ViewModelBase
    {

        public TodoListViewModel(IEnumerable<TodoItem> items)
        {
            Items = new ObservableCollection<TodoItem>(items);


        }

        private ObservableCollection<TodoItem> Items { get; }


        private void OnClickCommand()
        {
            Debug.WriteLine("Hello! {value}");
        }


    }
}