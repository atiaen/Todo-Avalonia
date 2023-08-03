using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Linq;
using TodoV2.Messengers;
using TodoV2.Services;

namespace TodoV2.Views;

public partial class TodoListView : UserControl
{
    private TodoItemContext _todoItemContext;

    public TodoListView()
    {
        InitializeComponent();
        _todoItemContext = App.Current.Services.GetService<TodoItemContext>();

    }

    private void OnButtonClick(object sender, RoutedEventArgs e)
    {
        CheckBox box = (CheckBox) sender;
        int id = (int) box.CommandParameter;
        _todoItemContext.items.Single(t => t.Id == id).IsChecked = (bool) box.IsChecked;
        _todoItemContext.SaveChanges();
    }

    private void OnDeleteClick(object sender, RoutedEventArgs e)
    {
        Button box = (Button)sender;
        int id = (int)box.CommandParameter;
        var it = _todoItemContext.items.Single(t => t.Id == id);
        _todoItemContext.Remove(it);
        _todoItemContext.SaveChanges();
        WeakReferenceMessenger.Default.Send(new ChangeViewMessage("list"));

    }

}