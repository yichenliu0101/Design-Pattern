using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeDemo
{
    public interface ITheme
    {
        string TextColor { get; }
        string BgrColor { get; }
    }

    public class LightTheme : ITheme
    {
        public string TextColor => "black";
        public string BgrColor => "white";
    }

    public class DarkTheme : ITheme
    {
        public string TextColor => "white";
        public string BgrColor => "dark gray";
    }

    public class TrackingThemeFactory
    {
        private readonly List<WeakReference<ITheme>> themes = new();

        public ITheme CreateTheme(bool isDark)
        {
            ITheme theme = isDark ? new DarkTheme() : new LightTheme();
            themes.Add(new WeakReference<ITheme>(theme));
            return theme;
        }

        public string Info
        {
            get
            {
                var sb = new StringBuilder();
                foreach(var reference in themes)
                {
                    if(reference.TryGetTarget(out var theme))
                    {
                        bool isDark = theme is DarkTheme;
                        sb.Append(isDark ? "Dark" : "Light")
                            .AppendLine(" theme");
                    }
                }
                return sb.ToString();
            }
        }
    }

    public class ReplaceableThemeFactory
    {
        private readonly List<WeakReference<Ref<ITheme>>> themes = new();

        private ITheme CreateThemeImp1(bool isDark)
        {
            return isDark ? new DarkTheme() : new LightTheme();
        }

        public Ref<ITheme> CreateTheme(bool isDark)
        {
            var theme = new Ref<ITheme>(CreateThemeImp1(isDark));
            themes.Add(new(theme));
            return theme;
        }

        public void ReplaceTheme(bool isDark)
        {
            foreach(var wr in themes)
            {
                if(wr.TryGetTarget(out var theme))
                {
                    theme.Value = CreateThemeImp1(isDark);
                }
            }
        }
    }
    public class Ref<T> where T : class
    {
        public T Value;
        public Ref(T value)
        {
            Value = value;
        }
    }
}
