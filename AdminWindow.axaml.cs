using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using StolyarovaDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace StolyarovaDemo;

public partial class AdminWindow : Window
{
    public List<User> users = DBHelper.context.Users.ToList();
    public AdminWindow()
    {
        InitializeComponent();

    }
}