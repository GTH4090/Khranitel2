using Avalonia.Controls;
using Avalonia.Interactivity;
using KhranitelProDesktop.Pages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static KhranitelProDesktop.Classes.Helper;

namespace KhranitelProDesktop;

public partial class KeeperWindow : Window
{
    public KeeperWindow()
    {
        InitializeComponent();

        Navigationn = MainFrame;
        Win = this;
        Navigationn.Content = new Auth();
    }

    private void ExitBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Navigationn.Content = new Auth();
    }
}