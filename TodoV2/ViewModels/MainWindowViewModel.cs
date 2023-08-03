using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using TodoV2.Messengers;
using TodoV2.Models;
using TodoV2.Services;

namespace TodoV2.ViewModels
{
    public class MainWindowViewModel : ViewModelBase,IRecipient<ChangeViewMessage>
    {
        public TodoListViewModel List { get; }

        private string Test = "test text";


        ViewModelBase content;
        TodoItemContext context = App.Current.Services.GetService<TodoItemContext>();


        public MainWindowViewModel()
        {

            WeakReferenceMessenger.Default.Register<ChangeViewMessage>(this);

            Content = List = new TodoListViewModel(context.items.ToList());
        }


        public ViewModelBase Content
        {
            get => content;
            private set => SetProperty(ref content, value);
        }


        public void AddItem()
        {
            Content = new AddItemViewModel();
        }

        public void Receive(ChangeViewMessage message)
        {
            if(message.Value == "list")
            {
                List<TodoItem> items = context.items.ToList();
                Content = new TodoListViewModel(items);

            }
        }
    }
}