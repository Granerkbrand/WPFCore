using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace WPFCore
{
    public class ViewLocator
    {
        public static FrameworkElement LocateForModel(object rootModel)
        {
            var viewTypeName = rootModel.GetType().FullName;

            string defaultRegex = @"[\p{Lu}\p{Ll}\p{Lt}\p{Lm}\p{Lo}\p{Nl}_][\p{Lu}\p{Ll}\p{Lt}\p{Lm}\p{Lo}\p{Nl}\p{Mn}\p{Mc}\p{Nd}\p{Pc}\p{Cf}_]*";

            Regex regex = new Regex(@$"(?<prenamespace>({defaultRegex}\.)*)" +
                @"(?<replacenamespace>ViewModels\.)" +
                @$"(?<postnamespace>({defaultRegex}\.)*)" +
                @$"(?<basename>{defaultRegex})" +
                @"(?<suffix>ViewModel)$");

            var name = regex.Replace(viewTypeName, @"${prenamespace}Views.${postnamespace}${basename}View");

            var viewType = Assemblies.FindType(name);

            var view = (FrameworkElement)Activator.CreateInstance(viewType);

            var method = view.GetType()
                .GetMethod("InitializeComponent", BindingFlags.Public | BindingFlags.Instance);

            method?.Invoke(view, null);

            return view;
        }
    }
}
