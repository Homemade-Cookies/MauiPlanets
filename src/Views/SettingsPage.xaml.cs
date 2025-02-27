using Microsoft.Maui.Controls;

namespace MauiPlanets.Views;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
        LoadSettings();
    }

    private void LoadSettings()
    {
        // Load settings from storage and set the UI elements
        PieceColorsPicker.SelectedIndex = Preferences.Get("PieceColor", 0);
        BoardThemesPicker.SelectedIndex = Preferences.Get("BoardTheme", 0);
        DifficultySlider.Value = Preferences.Get("DifficultyLevel", 5);
    }

    private void SaveSettings()
    {
        // Save settings to storage
        Preferences.Set("PieceColor", PieceColorsPicker.SelectedIndex);
        Preferences.Set("BoardTheme", BoardThemesPicker.SelectedIndex);
        Preferences.Set("DifficultyLevel", (int)DifficultySlider.Value);
    }

    private void OnPieceColorChanged(object sender, EventArgs e)
    {
        SaveSettings();
    }

    private void OnBoardThemeChanged(object sender, EventArgs e)
    {
        SaveSettings();
    }

    private void OnDifficultyLevelChanged(object sender, EventArgs e)
    {
        SaveSettings();
    }
}
