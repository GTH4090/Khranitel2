using Avalonia.Controls;
using MessageBox.Avalonia;
using MessageBox.Avalonia.Enums;

namespace KhranitelProDesktop.Classes;
using KhranitelProDesktop.Models;

public class Helper
{
    public static KeeperDbContext Db = new KeeperDbContext();

    public static ContentControl Navigationn = null;

    public static Window Win = null;

    public static void Error(string err = "Ошибка подключения к БД")
    {
        MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", err, ButtonEnum.Ok, Icon.Error).ShowDialog(Win);
    }
}