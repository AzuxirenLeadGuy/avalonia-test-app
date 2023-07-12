using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Themes.Fluent;
using Avalonia.Styling;
using Avalonia.Media;
using ava_prac.Views;

namespace ava_prac;

public class App : Application
{
    private FluentTheme _currentTheme = new();
    public override void Initialize()
    {
        var theme = new FluentTheme() { DensityStyle = DensityStyle.Compact };
        Styles.Add(theme);
        RequestedThemeVariant = ThemeVariant.Dark;
        _currentTheme = theme;
    }
    public void ApplyTheme(ThemeKey key)
    {
        var (theme, variant) = GetSelectedTheme(key);
        theme.DensityStyle = DensityStyle.Compact;
        _currentTheme.Palettes.Clear();
        foreach (var item in theme.Palettes)
        {
            _currentTheme.Palettes.Add(item.Key, item.Value);
        }
        _currentTheme.Resources.Clear();
        foreach (var item in theme.Resources)
        {
            _currentTheme.Resources.Add(item.Key, item.Value);
        }
        RequestedThemeVariantProperty.CoerceValue(this, variant);
        Styles.Remove(_currentTheme);
        Styles.Add(_currentTheme);
        OnPropertyChanged(Ava)
        RequestedThemeVariant = variant;
    }
    private static (FluentTheme, ThemeVariant) GetSelectedTheme(ThemeKey sel) => sel switch
    {
        ThemeKey.DefaultLight =>
        (
            new()
            {
                Palettes =
                {
                    [ThemeVariant.Light] = new ColorPaletteResources()
                    {
                        Accent=Color.FromRgb( 0x00, 0x73, 0xcf),
                        AltHigh=Color.FromRgb(0xff, 0xff, 0xff),
                        AltLow=Color.FromRgb(0xff, 0xff, 0xff),
                        AltMedium=Color.FromRgb(0xff, 0xff, 0xff),
                        AltMediumHigh=Color.FromRgb(0xff, 0xff, 0xff),
                        AltMediumLow=Color.FromRgb(0xff, 0xff, 0xff),
                        BaseHigh=Color.FromRgb(0,0,0),
                        BaseLow=Color.FromRgb( 0xcc,0xcc,0xcc),
                        BaseMedium=Color.FromRgb( 0x89,0x89,0x89),
                        BaseMediumHigh=Color.FromRgb( 0x5d,0x5d,0x5d),
                        BaseMediumLow=Color.FromRgb( 0x73,0x73,0x73),
                        ChromeAltLow=Color.FromRgb( 0x5d,0x5d,0x5d),
                        ChromeBlackHigh=Color.FromRgb(0,0,0),
                        ChromeBlackLow=Color.FromRgb( 0xcc,0xcc,0xcc),
                        ChromeBlackMedium=Color.FromRgb( 0x5d,0x5d,0x5d),
                        ChromeBlackMediumLow=Color.FromRgb( 0x89,0x89,0x89),
                        ChromeDisabledHigh=Color.FromRgb( 0xcc,0xcc,0xcc),
                        ChromeDisabledLow=Color.FromRgb( 0x89,0x89,0x89),
                        ChromeGray=Color.FromRgb( 0x73,0x73,0x73),
                        ChromeHigh=Color.FromRgb( 0xcc,0xcc,0xcc),
                        ChromeLow=Color.FromRgb( 0xec,0xec,0xec),
                        ChromeMedium=Color.FromRgb( 0xe6,0xe6,0xe6),
                        ChromeMediumLow=Color.FromRgb( 0xec,0xec,0xec),
                        ChromeWhite=Color.FromRgb(0xff, 0xff, 0xff),
                        ListLow=Color.FromRgb( 0xe6,0xe6,0xe6),
                        ListMedium=Color.FromRgb( 0xcc,0xcc,0xcc),
                        RegionColor=Color.FromRgb(0xff, 0xff, 0xff),
                    }
                }
            },
            ThemeVariant.Light
        ),
        ThemeKey.DefaultDark =>
        (
            new()
            {
                Palettes =
                {
                    [ThemeVariant.Dark] = new ColorPaletteResources()
                    {
                        Accent =Color.FromRgb(0x00, 0x73, 0xcf ),
                        AltHigh =Color.FromRgb( 0,0,0),
                        AltLow =Color.FromRgb( 0,0,0),
                        AltMedium =Color.FromRgb( 0,0,0),
                        AltMediumHigh =Color.FromRgb( 0,0,0),
                        AltMediumLow =Color.FromRgb( 0,0,0),
                        BaseHigh =Color.FromRgb( 0xff,0xff,0xff),
                        BaseLow =Color.FromRgb(0x33, 0x33, 0x33 ),
                        BaseMedium =Color.FromRgb(0x9a, 0x9a, 0x9a ),
                        BaseMediumHigh =Color.FromRgb(0xb4, 0xb4, 0xb4 ),
                        BaseMediumLow =Color.FromRgb(0x67, 0x67, 0x67 ),
                        ChromeAltLow =Color.FromRgb(0xb4, 0xb4, 0xb4 ),
                        ChromeBlackHigh =Color.FromRgb( 0,0,0),
                        ChromeBlackLow =Color.FromRgb(0xb4, 0xb4, 0xb4 ),
                        ChromeBlackMedium =Color.FromRgb( 0,0,0),
                        ChromeBlackMediumLow =Color.FromRgb( 0,0,0),
                        ChromeDisabledHigh =Color.FromRgb(0x33, 0x33, 0x33 ),
                        ChromeDisabledLow =Color.FromRgb(0x9a, 0x9a, 0x9a ),
                        ChromeGray =Color.FromRgb(0x80, 0x80, 0x80 ),
                        ChromeHigh =Color.FromRgb(0x80, 0x80, 0x80),
                        ChromeLow =Color.FromRgb(0x15, 0x15, 0x15 ),
                        ChromeMedium =Color.FromRgb(0x1d, 0x1d, 0x1d ),
                        ChromeMediumLow =Color.FromRgb(0x2c, 0x2c, 0x2c ),
                        ChromeWhite =Color.FromRgb( 0xff,0xff,0xff),
                        ListLow =Color.FromRgb(0x1d, 0x1d, 0x1d ),
                        ListMedium =Color.FromRgb(0x33, 0x33, 0x33 ),
                        RegionColor =Color.FromRgb( 0,0,0),
                    }
                }
            }, ThemeVariant.Dark
        ),
        ThemeKey.NeoLight =>
        (
            new FluentTheme()
            {
                Palettes =
                {
                    [ThemeVariant.Light] = new ColorPaletteResources()
                    {
                        Accent=Color.FromRgb( 0x89, 0x61, 0xcc),
                        AltHigh=Color.FromRgb(0xff, 0xff, 0xff),
                        AltLow=Color.FromRgb(0xff, 0xff, 0xff),
                        AltMedium=Color.FromRgb(0xff, 0xff, 0xff),
                        AltMediumHigh=Color.FromRgb(0xff, 0xff, 0xff),
                        AltMediumLow=Color.FromRgb(0xff, 0xff, 0xff),
                        BaseHigh=Color.FromRgb(0,0,0),
                        BaseLow=Color.FromRgb(0xee, 0xce, 0xff),
                        BaseMedium=Color.FromRgb(0xa9,0x87,0xbc),
                        BaseMediumHigh=Color.FromRgb(0x7b,0x58,0x90),
                        BaseMediumLow=Color.FromRgb(0x92,0x70,0xa6),
                        ChromeAltLow=Color.FromRgb(0x7b,0x58,0x90),
                        ChromeBlackHigh=Color.FromRgb(0,0,0),
                        ChromeBlackLow=Color.FromRgb(0xee,0xce,0xff),
                        ChromeBlackMedium=Color.FromRgb(0x7b,0x58,0x90),
                        ChromeBlackMediumLow=Color.FromRgb(0xa9,0x87,0xbc),
                        ChromeDisabledHigh=Color.FromRgb(0xee,0xce,0xff),
                        ChromeDisabledLow=Color.FromRgb(0xa9,0x87,0xbc),
                        ChromeGray=Color.FromRgb(0x92,0x70,0xa6),
                        ChromeHigh=Color.FromRgb(0xee,0xce,0xff),
                        ChromeLow=Color.FromRgb(0xfe,0xea,0xff),
                        ChromeMedium=Color.FromRgb(0xfb,0xe4,0xff),
                        ChromeMediumLow=Color.FromRgb(0xfe,0xea,0xff),
                        ChromeWhite=Color.FromRgb(0xff, 0xff, 0xff),
                        ListLow=Color.FromRgb(0xfb,0xe4,0xff),
                        ListMedium=Color.FromRgb(0xee,0xce,0xff),
                        RegionColor=Color.FromRgb(0xfe,0xf6,0xff),
                    },
                }
            },
            ThemeVariant.Light
        ),
        _ =>
        (
            new FluentTheme()
            {
                Palettes =
                {
                    [ThemeVariant.Dark] = new ColorPaletteResources()
                    {
                        Accent=Color.FromRgb( 0x5d, 0x4e, 0xa4),
                        AltHigh=Color.FromRgb(0,0,0),
                        AltLow=Color.FromRgb(0,0,0),
                        AltMedium=Color.FromRgb(0,0,0),
                        AltMediumHigh=Color.FromRgb(0,0,0),
                        AltMediumLow=Color.FromRgb(0,0,0),
                        BaseHigh=Color.FromRgb(0xff, 0xff, 0xff),
                        BaseLow=Color.FromRgb( 0x4d, 0x43, 0x53),
                        BaseMedium=Color.FromRgb( 0xab, 0xa0, 0xb0),
                        BaseMediumHigh=Color.FromRgb( 0xc2, 0xb7, 0xc7),
                        BaseMediumLow=Color.FromRgb( 0x7c, 0x71, 0x81),
                        ChromeAltLow=Color.FromRgb( 0xc2, 0xb7, 0xc7),
                        ChromeBlackHigh=Color.FromRgb(0,0,0),
                        ChromeBlackLow=Color.FromRgb( 0xc2, 0xb7, 0xc7),
                        ChromeBlackMedium=Color.FromRgb(0,0,0),
                        ChromeBlackMediumLow=Color.FromRgb(0,0,0),
                        ChromeDisabledHigh=Color.FromRgb( 0x4d, 0x43, 0x53),
                        ChromeDisabledLow=Color.FromRgb( 0xab, 0xa0, 0xb0),
                        ChromeGray=Color.FromRgb( 0x93, 0x89, 0x99),
                        ChromeHigh=Color.FromRgb( 0x93, 0x89, 0x99),
                        ChromeLow=Color.FromRgb( 0x27, 0x16, 0x34),
                        ChromeMedium=Color.FromRgb( 0x31, 0x21, 0x3c),
                        ChromeMediumLow=Color.FromRgb( 0x44, 0x38, 0x4b),
                        ChromeWhite=Color.FromRgb(0xff, 0xff, 0xff),
                        ListLow=Color.FromRgb( 0x31, 0x21, 0x3c),
                        ListMedium=Color.FromRgb( 0x4d, 0x43, 0x53),
                        RegionColor=Color.FromRgb( 0x26, 0x27, 0x38),
                    },
                }
            },
            ThemeVariant.Dark
        ),
    };
    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView();
        }
        base.OnFrameworkInitializationCompleted();
    }
}