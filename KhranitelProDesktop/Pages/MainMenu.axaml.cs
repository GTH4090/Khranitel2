using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using static KhranitelProDesktop.Classes.Helper;

namespace KhranitelProDesktop.Pages;

public partial class MainMenu : UserControl
{
    private int _id;
    public MainMenu(int id)
    {
        _id = id;
        InitializeComponent();
        MainDg.Items = Db.Visits.Where(el => el.Userid == _id).Include(el => el.Employee)
            .ThenInclude(el => el.Division).
            Include(el => el.Status).Include(el => el.Type).ToList();
    }

    public MainMenu()
    {
        
    }


    private void OrderBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Navigationn.Content = new RequestPage(_id);
    }

    private void GroupOrdBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Navigationn.Content = new GroupRequestPage(_id);
    }
}