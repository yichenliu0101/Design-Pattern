using ThemeDemo;

var factory = new TrackingThemeFactory();
var theme1 = factory.CreateTheme(true);
var theme2 = factory.CreateTheme(false);
Console.WriteLine(factory.Info);

var factory2 = new ReplaceableThemeFactory();
var magicTheme = factory2.CreateTheme(true);
Console.WriteLine(magicTheme.Value.BgrColor);
factory2.ReplaceTheme(false);
Console.WriteLine(magicTheme.Value.BgrColor);