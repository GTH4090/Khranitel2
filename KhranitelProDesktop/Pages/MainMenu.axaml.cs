using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using KhranitelProDesktop.Models;
using Microsoft.EntityFrameworkCore;
using static KhranitelProDesktop.Classes.Helper;

namespace KhranitelProDesktop.Pages;

public partial class MainMenu : UserControl
{
    private void LoadData()
    {
        List<Visit> visits = Db.Visits.Include(el => el.Employee)
            .ThenInclude(el => el.Division).
            Include(el => el.Status).Include(el => el.Type).ToList();
        if (TypeCbx.SelectedIndex != 0 && TypeCbx.SelectedIndex != -1)
        {
            var item = TypeCbx.SelectedItem as Visittype;
            visits = visits.Where(el => el.Typeid == item.Id).ToList();
        }
        if (StatusCbx.SelectedIndex != 0 && StatusCbx.SelectedIndex != -1)
        {
            var item = StatusCbx.SelectedItem as Visitstatus;
            visits = visits.Where(el => el.Statusid == item.Id).ToList();
        }

        if (DevisionCbx.SelectedIndex != 0 && DevisionCbx.SelectedIndex != -1)
        {
            var item = DevisionCbx.SelectedItem as Division;
            visits = visits.Where(el => el.Employee.Divisionid == item.Id).ToList();
        }
        
        
        MainDg.Items = visits;
        UserCbx.Items = Db.Users.ToList();
    }
    
    public MainMenu()
    {
        
        InitializeComponent();
        
        UserCbx.SelectedIndex = 0;
        var items = Db.Visittypes.ToList();
        items.Insert(0, new Visittype() { Name = "Все" });
        TypeCbx.Items = items;
        TypeCbx.SelectedIndex = 0;
        
        var items2 = Db.Visitstatuses.ToList();
        items2.Insert(0, new Visitstatus(){Name = "Все"});
        
        StatusCbx.Items = items2;
        StatusCbx.SelectedIndex = 0;
        var items3 = Db.Divisions.ToList();
        items3.Insert(0, new Division(){Name = "Все"});
        DevisionCbx.Items = items3;
        DevisionCbx.SelectedIndex = 0;
    }

    


    private void OrderBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var item = UserCbx.SelectedItem as User;
        Navigationn.Content = new RequestPage(item.Id);
    }

    private void GroupOrdBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var item = UserCbx.SelectedItem as User;
        Navigationn.Content = new GroupRequestPage(item.Id);
    }

    private void TypeCbx_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        LoadData();
    }

    private void StatusCbx_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        LoadData();
    }

    private async void EditBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        if (MainDg.SelectedItem != null)
        {
            var item = MainDg.SelectedItem as Visit;
            OrderEdit orderEdit = new OrderEdit(item.Id);
            await orderEdit.ShowDialog(Win);
        }

        else
        {
            Error("Не выбрана заявка");
        }
    }
}